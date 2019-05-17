using System;
using System.Collections.Generic;
using System.Text;
using CfgDoc.Log;

namespace CfgDoc
{
    class Global
    {
        private Global() { }

        private static ILog logSingleton = new ConsoleLog();

        public static ILog Log { get { return logSingleton; } }
    }
}
