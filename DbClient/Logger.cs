using log4net;
using log4net.Config;

namespace DbClient
{
    public static class Logger
    {
        public static readonly ILog Log = LogManager.GetLogger("DbClientLogger");
        static Logger()
        {
            XmlConfigurator.Configure();
        }
    }
}
