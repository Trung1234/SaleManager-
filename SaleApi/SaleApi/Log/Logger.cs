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
    }
}
