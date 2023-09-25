using Serilog;

namespace Common.Infrastructure
{
    public static class Logger
    {
        private static ILogger __log;

        public static void Init(ILogger log)
        {
            __log = log;
        }

        public static void Debug(string format, params object[] args) => __log?.Debug(format, args);
        public static void Information(string format, params object[] args) => __log?.Information(format, args);
        public static void Warning(string format, params object[] args) => __log?.Warning(format, args);
        public static void Error(string format, params object[] args) => __log?.Error(format, args);
        public static void Fatal(string format, params object[] args) => __log?.Fatal(format, args);

    }
}
