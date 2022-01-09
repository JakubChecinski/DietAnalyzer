using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietAnalyzer.UnitTests.Extensions
{

    /// <remarks>
    /// 
    /// Moq and ILogger don't like each other (extension method error), so I am writing my own mock class
    /// For other possible solutions, see answers to this:
    /// https://stackoverflow.com/questions/52707702/how-do-you-mock-ilogger-loginformation/64616141
    /// 
    /// </remarks>
    public class CustomMockLogger<T> : ILogger, ILogger<T>
    {
        public IDisposable BeginScope<TState>(TState state) => default!;
        public bool IsEnabled(LogLevel logLevel) => true;

        public string LogDump { get; private set; }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            // very minimalistic, but I think that's all I need right now
            LogDump = "Last call:";
            if (state != null) 
                LogDump += " " + state.ToString();
            if (exception != null) 
                LogDump += " " + exception.ToString() + ": " + exception.Message;
            if (state == null && exception == null)
                LogDump += " null";
        }
    }

}
