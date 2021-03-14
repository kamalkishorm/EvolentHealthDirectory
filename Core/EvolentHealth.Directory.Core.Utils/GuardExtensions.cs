using System;
using Microsoft.Extensions.Logging;

namespace EvolentHealth.Directory.Core.Utils
{
    public static class GuardExtensions
    {
        public static void ThrowIfNullOrEmpty(this string parameter, string parameterName, string errorMessage, ILogger logger)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                var argumentNullException = new ArgumentNullException(parameterName, errorMessage);
                logger.LogException(argumentNullException);
                throw argumentNullException;
            }
        }
    }
}