using System;
using Loader;
using System.Collections.Specialized;
using System.Configuration;
using Loader.Searchers;

namespace DbClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Logger.Log.Info("Start execution");
            Logger.Log.Info(Environment.OSVersion.ToString());
            Logger.Log.Info(Environment.MachineName.ToString());
            Logger.Log.Info(Environment.UserName.ToString());

            ExecuteWithDbArgs();
            Console.Read();
        }

        private static void ExecuteWithDbArgs()
        {
            const string connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security=true;";

            try
            {
                Console.WriteLine("Started!");

                var keyArgsCollection = GetKeyArgsCollectionFromConfig();
                var consoleArgs = $"-in {connection} -out db.xml".Split(' ');
                var context = new NodeSearchContext(consoleArgs, keyArgsCollection);

                var service = new SearchDataDbClient(context);
                service.Search();

                Console.WriteLine("Finished!");
            }
            catch(Exception ex)
            {
                Logger.Log.Error($"{ex.Message}", ex);
            }
        }

        internal static NameValueCollection GetKeyArgsCollectionFromConfig()
        {
            var argCollection = ConfigurationManager.AppSettings;
            return argCollection;
        }
    }
}
