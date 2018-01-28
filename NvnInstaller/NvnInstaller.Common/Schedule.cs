using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace NvnInstaller
{
    [Serializable]
    public class Schedules
    {
        List<Schedule> scheduleList = new List<Schedule>();

        public List<Schedule> ScheduleList
        {
            get { return scheduleList; }
        }
    }

    [Serializable]
    public class Schedule
    {
        List<string> days = new List<string>();
        List<string> months = new List<string>();
        List<DateTime> excludeDates = new List<DateTime>();
        List<DateTime> executionTimes = new List<DateTime>();
        string rootFolder = string.Empty;
        string projectFile = string.Empty;
        NameFormat nameFormat;
        string dateFormat;

        public List<string> Days
        {
            get { return days; }
            set { days = value; }
        }

        public List<string> Months
        {
            get { return months; }
            set { months = value; }
        }

        public List<DateTime> ExcludeDates
        {
            get { return excludeDates; }
            set { excludeDates = value; }
        }

        public List<DateTime> ExecutionTimes
        {
            get { return executionTimes; }
            set { executionTimes = value; }
        }

        public string RootFolder
        {
            get { return rootFolder; }
            set { rootFolder = value; }
        }

        public string ProjectFile
        {
            get { return projectFile; }
            set { projectFile = value; }
        }

        public NameFormat NameFormat
        {
            get { return nameFormat; }
            set { nameFormat = value; }
        }

        public string DateFormat
        {
            get { return dateFormat; }
            set { dateFormat = value; }
        }
    }

    [Serializable]
    public class DateFormat
    {
        string format;
        string example;

        public DateFormat(string format, string description)
        {
            this.format = format;
            this.example = description;
        }

        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        public string Example
        {
            get { return example; }
            set { example = value; }
        }

        // create list of formats
        [NonSerialized]
        static List<DateFormat> formats = new List<DateFormat>() { 
      new DateFormat("MM-dd-yyyy","08-22-2006")
      ,new DateFormat("dddd dd MMMM yyyy","Tuesday 22 August 2006")
      ,new DateFormat("dddd dd MMMM yyyy HH-mm","Tuesday 22 August 2006 06-30")
      ,new DateFormat("dddd dd MMMM yyyy hh-mm tt","Tuesday 22 August 2006 06-30 AM")
      ,new DateFormat("dddd dd MMMM yyyy H-mm","Tuesday 22 August 2006 6-30")
      ,new DateFormat("dddd dd MMMM yyyy h-mm tt","Tuesday 22 August 2006 6-30 AM")
      ,new DateFormat("dddd dd MMMM yyyy HH-mm-ss","Tuesday 22 August 2006 06-30-07")
      ,new DateFormat("MM-dd-yyyy HH-mm","08-22-2006 06-30")
      ,new DateFormat("MM-dd-yyyy hh-mm tt","08-22-2006 06-30 AM")
      ,new DateFormat("MM-dd-yyyy H-mm","08-22-2006 6-30")
      ,new DateFormat("MM-dd-yyyy h-mm tt","08-22-2006 6-30 AM")
      ,new DateFormat("MM-dd-yyyy h-mm tt","08-22-2006 6-30 AM")
      ,new DateFormat("MM-dd-yyyy h-mm tt","08-22-2006 6-30 AM")
      ,new DateFormat("MM-dd-yyyy HH-mm-ss","08-22-2006 06-30-07")
      ,new DateFormat("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss.fffffffK","2006-08-22T06-30-07.7199222-04-00")
      ,new DateFormat("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss.fffffffK","2006-08-22T06-30-07.7199222-04-00")
      ,new DateFormat("ddd dd MMM yyyy HH'-'mm'-'ss 'GMT'","Tue 22 Aug 2006 06-30-07 GMT")
      ,new DateFormat("ddd dd MMM yyyy HH'-'mm'-'ss 'GMT'","Tue 22 Aug 2006 06-30-07 GMT")
      ,new DateFormat("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss","2006-08-22T06-30-07")
      ,new DateFormat("yyyy'-'MM'-'dd HH'-'mm'-'ss'Z'","2006-08-22 06-30-07Z")
      ,new DateFormat("dddd dd MMMM yyyy HH-mm-ss","Tuesday 22 August 2006 06-30-07")
    };

        [XmlIgnoreAttribute]
        public static List<DateFormat> Formats
        {
            get { return formats; }
        }
    }

    //TODO: allow more formats
    public enum NameFormat
    {
        Name_DateFormat,
        Name_Number
    }
}
