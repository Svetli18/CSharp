using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Date_Modifier
{
    public class DateModifier
    {
        private int day1;
        private int month1;
        private int year1;
        private int day2;
        private int month2;
        private int year2;

        public DateModifier()
        {
        }

        public DateModifier(int day1, int month1, int Year1, int day2, int month2, int year2)
            :this()
        {
            this.Day1 = day1;
            this.Month1 = month1;
            this.Year1 = Year1;
            this.day2 = day2;
            this.month2 = month2;
            this.Year2 = year2;
        }

        public int Day1 { get => this.day1; set => this.day1 = value; }
        public int Month1 { get => this.month1; set => this.month1 = value; }
        public int Year1 { get => this.year1; set => this.year1 = value; }
        public int Day2 { get => this.day2; set => this.day2 = value; }
        public int Month2 { get => this.month2; set => this.month2 = value; }
        public int Year2 { get => this.year2; set => this.year2 = value; }

        public long DaysBetweenTwoDates()
        {
            var date1 = new DateTime(this.Year1, this.Month1, this.Day1);
            var date2 = new DateTime(this.Year2, this.Month2, this.Day2);

            long days = Math.Abs(((TimeSpan)(date2 - date1)).Days);

            return days;
        }
    }
}
