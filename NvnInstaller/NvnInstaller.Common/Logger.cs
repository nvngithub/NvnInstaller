using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using System.Data.SQLite;

namespace NvnInstaller {
    public class BuildLogger {
        public static event EventHandler<BuildLogMessage> MessageLogged;
        static int errorCount = 0, warningCount = 0;


        public static int ErrorCount {
            get { return errorCount; }
        }

        public static int WarningCount {
            get { return warningCount; }
        }

        public static void Initialize() {
            errorCount = warningCount = 0;
        }

        public static void Add(BuildLogMessage message) {
            switch (message.Type) {
                case LogType.ERROR: errorCount++; break;
                case LogType.Warning: warningCount++; break;
            }
            AddToLogDatabase(message);
            NotifyLogMessage(message);
        }

        public static void Add(List<BuildLogMessage> messages) {
            foreach (BuildLogMessage message in messages) {
                switch (message.Type) {
                    case LogType.ERROR: errorCount++; break;
                    case LogType.Warning: warningCount++; break;
                }
                AddToLogDatabase(message);
                NotifyLogMessage(message);
            }
        }

        private static void NotifyLogMessage(BuildLogMessage message) {
            if (MessageLogged != null) {
                MessageLogged(null, message);
            }
        }

        private static void AddToLogDatabase(BuildLogMessage log) {
            //if (File.Exists(Common.applicationLogsDb) == false && File.Exists("Logs.s3db")) {
            //    File.Copy("Logs.s3db", Common.applicationLogsDb, true);
            //}

            //string connectionString = String.Format(@"Data Source = {0}", Common.applicationLogsDb);
            //SQLiteConnection connection = new SQLiteConnection(connectionString);
            //connection.Open();
            //string sql = String.Format("INSERT INTO log VALUES('{0}','{1}','{2}','{3}','{4}')",
            //    log.LogTime.ToString("yyyy-MM-dd"), log.LogTime.ToString("HH:mm:ss"), log.Module + ":" + log.Type + ":" + log.Message, "", "N");
            //SQLiteCommand command = new SQLiteCommand(sql, connection);
            //command.ExecuteNonQuery();
            //connection.Close();
        }
    }

    public class BuildLogMessage : EventArgs {
        private string message;
        private string helpText;
        private string sourceDescription;
        private string destinationDescription;
        private object source;
        private object destination;
        private LogType type;
        private Modules module;
        private DateTime logTime;

        public BuildLogMessage() {
            logTime = DateTime.Now;
        }

        public string Message {
            get { return message; }
            set { message = value; }
        }

        public string HelpText {
            get { return helpText; }
            set { helpText = value; }
        }

        public string SourceDescription {
            get { return sourceDescription; }
            set { sourceDescription = value; }
        }

        public string DestinationDescription {
            get { return destinationDescription; }
            set { destinationDescription = value; }
        }

        public object Source {
            get { return source; }
            set { source = value; }
        }

        public object Destination {
            get { return destination; }
            set { destination = value; }
        }

        public LogType Type {
            get { return type; }
            set { type = value; }
        }

        public Modules Module {
            get { return module; }
            set { module = value; }
        }

        public DateTime LogTime {
            get { return logTime; }
            set { logTime = value; }
        }

        //public override string ToString()
        //{
        //    return time.ToShortDateString() + "::" + time.ToLongTimeString() + "::" + type.ToString() + "::" + message;
        //}
    }

    public class Logger {
        public static void BuildSchedulerLog(LogMessage logMessage) {
            //SQLiteConnection connection = ConnectDb();
            //AddLog(logMessage, "B", connection);
            //connection.Close();
        }

        public static void ApplicationLog(LogMessage logMessage) {
            //SQLiteConnection connection = ConnectDb();
            //AddLog(logMessage, "N", connection);
            //connection.Close();
        }

        public static void ConsoleLog(LogMessage logMessage) {
            //SQLiteConnection connection = ConnectDb();
            //AddLog(logMessage, "C", connection);
            //connection.Close();
        }

        //private static SQLiteConnection ConnectDb() {
        //    if (File.Exists(Common.applicationLogsDb) == false && File.Exists("Logs.s3db")) {
        //        File.Copy("Logs.s3db", Common.applicationLogsDb, true);
        //    }

        //    string connectionString = String.Format(@"Data Source = {0}", Common.applicationLogsDb);
        //    SQLiteConnection connection = new SQLiteConnection(connectionString);
        //    connection.Open();

        //    return connection;
        //}

        //private static void AddLog(LogMessage log, string type, SQLiteConnection connection) {
        //    string sql = String.Format("INSERT INTO log VALUES('{0}','{1}','{2}','{3}','{4}')",
        //        log.LogTime.ToString("yyyy-MM-dd"), log.LogTime.ToString("HH:mm:ss"), log.Message.Replace('\'', ' '), log.Exception != null ? log.Exception.Message.Replace('\'', ' ')
        //        + Environment.NewLine + (log.Exception.StackTrace == null ? "" : log.Exception.StackTrace.Replace('\'', ' ')) : string.Empty, type);
        //    SQLiteCommand command = new SQLiteCommand(sql, connection);
        //    command.ExecuteNonQuery();
        //}
    }

    public class LogMessage {
        string message;
        DateTime logTime;
        Exception exception;

        private LogMessage() {
            logTime = DateTime.Now;
        }

        public LogMessage(string message, Exception exception)
            : this() {
            if (message == null)
                throw new Exception("Message cannot be NULL. Use string.Empty instead.");
            this.message = message;
            this.exception = exception;
        }

        public string Message {
            get { return message; }
            set { message = value; }
        }

        public DateTime LogTime {
            get { return logTime; }
            set { logTime = value; }
        }

        public Exception Exception {
            get { return exception; }
            set { exception = value; }
        }

        public override string ToString() {
            string outMessage = logTime.ToString("dddd, dd MMMM yyyy HH:mm:ss:fff") + "::" + message + "\n";
            if (exception != null) {
                outMessage += exception.Message + "\n" + exception.StackTrace;
            }
            return outMessage;
        }
    }
}

