using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace EvolentHealth.Directory.Core.Utils
{
    public static class LoggerExtensions
    {
        public static void LogException(this ILogger logger, Exception exception)
        {
            const string template = "An exception of type {Type} occurred with the message {Message}";
            logger.LogError(exception, template, exception.GetType(), exception.Message);
            Console.WriteLine("An exception of type {0} occurred with the message {1}", exception.GetType(), exception.Message);
        }

        public static void LogArgument<T>(this ILogger logger, LogLevel level, string @class, string method, T argument)
        {
            const string template = "Method {Method} in class {Class} was called with argument {@Argument}";
            var serializeObject = JsonConvert.SerializeObject(argument);
            logger.Log(level, template, method, @class, serializeObject);
        }

    }
}
