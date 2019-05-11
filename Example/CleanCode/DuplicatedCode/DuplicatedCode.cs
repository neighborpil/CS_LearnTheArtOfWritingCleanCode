
using System;

namespace CleanCode.DuplicatedCode
{
    class DuplicatedCode
    {
        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            var time = Time.Parse(admissionDateTime);

            // Some more logic 
            // ...
            if (time.Hour < 10)
            {

            }
        }

        public void UpdateAdmission(int admissionId, string name, string admissionDateTime)
        {
            var time = Time.Parse(admissionDateTime);

            // Some more logic 
            // ...
            if (time.Hour < 10)
            {

            }
        }
    }

    public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

        public static Time Parse(string str)
        {
            int hours;
            int minutes;
            if (!String.IsNullOrWhiteSpace(str))
            {
                if (Int32.TryParse(str.Replace(":", ""), out int time))
                {
                    hours = time / 100;
                    minutes = time % 100;
                }
                else
                {
                    throw new ArgumentException("str");
                }
            }
            else
                throw new ArgumentNullException("str");

            return new Time { Hour = hours, Minute = minutes };
        }
    }
}
