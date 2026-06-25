using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberAwarenessBotGUI1
{
    public static class ActivityLogger
    {
        // this method saves the activity to the log file.

        private static List<string> logs = new List<string>();

        public static void LogAction(string action)
        {
            string entry = $"[{DateTime.Now:HH:mm:ss}] {action}";
            logs.Add(entry);
        }

        public static List<string> GetRecentLogs(int count = 10)
        {
            // Returns the last N actions
            return logs.AsEnumerable().Reverse().Take(count).ToList();
        }
    }
}
