using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace SaleApi.Log
{
    public static class Logger
    {
        private static readonly string LOG_CONFIG_FILE = @"log4net.config";
        // Define log4net
        private static readonly ILog _log = LogManager.GetLogger(typeof(Logger));

        /// <summary>
        /// xuất log lỗi
        /// </summary>
        /// <param name="classLog"></param>
        /// <param name="method"></param>
        /// <param name="message"></param>
        public static void LogError()
        {
            _log.Error("log error");
        }

        /// <summary>
        /// xuất log thông tin
        /// </summary>
        /// <param name="classLog"></param>
        /// <param name="method"></param>
        /// <param name="message"></param>
        public static void LogInfo()
        {
            _log.Info("log Info");
        }

        


        public static void Debug(object message)
        {
            SetLog4NetConfiguration();
            _log.Debug(message);
        }

        private static void SetLog4NetConfiguration()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(LOG_CONFIG_FILE));

            var repo = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        }
    }
}
