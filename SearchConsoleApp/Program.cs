using SearchConsoleApp.Interfaces;
using System;

using Unity;

namespace SearchConsoleApp
{
    class Program
    {
        private static string firstQuery;
        private static string secondQuery;

        static void Main(string[] args)
        {
            FancyRead();
            FancyWrite(Search());
        }
        public static void FancyRead()
        {
            Console.WriteLine("How to determine the popularity of programming languages on the internet? EASY! Just type them below");
            Console.WriteLine("First: ");
            firstQuery = Console.ReadLine();
            Console.WriteLine("Second: ");
            secondQuery = Console.ReadLine();
            Console.WriteLine("------SEARCH IS BEING MADE, PLEASE ALLOW UP TO 5 SEC------");
        }

        public static void FancyWrite(Tuple<int, int, int, int> results)
        {
            var firstGoogleResult = results.Item1;
            var firstBingResult = results.Item2;
            var secondGoogleResult = results.Item3;
            var secondBingResult = results.Item4;

            var result = $"Total Search Results(Google + Bing):{firstQuery}: {firstGoogleResult + firstBingResult} ";
            result += $"{secondQuery}: {secondGoogleResult + secondBingResult} ";
            if (firstGoogleResult + firstBingResult > secondGoogleResult + secondBingResult)
            {
                result += $"Winner: {firstQuery}";
            }
            else
            {
                result += $"Winner: {secondQuery}";
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static Tuple<int, int, int, int> Search()
        {
            var container = new UnityContainer();
            container.RegisterType<ISearch, GoogleSearch>();
            var googleSearch = container.Resolve<UserSearch>();
            var firstGoogleResult = googleSearch.MakeSearch(firstQuery);
            var secondGoogleResult = googleSearch.MakeSearch(secondQuery);

            container.RegisterType<ISearch, BingSearch>();
            var bingSearch = container.Resolve<UserSearch>();
            var firstBingResult = bingSearch.MakeSearch(firstQuery);
            var secondBingResult = bingSearch.MakeSearch(secondQuery);
            var tuple = new Tuple<int, int, int, int>(firstGoogleResult, firstBingResult, secondGoogleResult, secondBingResult);

            return tuple;
        }

    }
}
