using System;
using System.Configuration;
using System.Collections.Specialized;
using Loader.Searchers;

namespace ConsoleClient
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            ExecuteWithPlugArgs();
            Console.Read();
        }

        private static void ExecuteWithPlugArgs()
        {
            try
            {
                Console.WriteLine("Started");

                var keyArgsCollection = GetKeyArgsCollectionFromConfig();
                var consoleArgs = "-in db.xml -attr tableName=Orders".Split(' ');
                var context = new NodeSearchContext(consoleArgs, keyArgsCollection);

                var service = new SearchDataFileClient(context);
                service.Search();
                Console.WriteLine("Finished!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                Environment.Exit(1);
            }
        }
        private static void ExecuteWithUsingConsoleArgs(string[] args)
        {
            if (args != null)
            {
                try
                {
                    Console.WriteLine("Started");

                    var keyArgsCollection = GetKeyArgsCollectionFromConfig();
                    var searchContext = new NodeSearchContext(args, keyArgsCollection);
                    var service = new SearchDataFileClient(searchContext);
                    service.Search();
                    Console.WriteLine("Finished!");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Read();
                    Environment.Exit(1);
                }
            }
            else
            {
                Console.WriteLine("Incorrect arguments!");
                Console.WriteLine($" Example: -in input.xml -str depth -atr key1=value1 key2=value2 -out out.xml");
            }
        }

        internal static NameValueCollection GetKeyArgsCollectionFromConfig()
        {
            var argCollection = ConfigurationManager.AppSettings;
            return argCollection;
        }
    }
}
