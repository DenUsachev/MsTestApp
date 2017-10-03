using System;

namespace TestApp.Domain
{
    public class LogEntry
    {
        public DateTime EventDate { get; set; }
        public string EventMessage { get; set; }

        public LogEntry(DateTime eventDate, string eventMessage)
        {
            EventDate = eventDate;
            EventMessage = eventMessage;
        }
    }
}
