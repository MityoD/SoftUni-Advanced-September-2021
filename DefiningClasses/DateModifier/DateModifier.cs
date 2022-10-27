using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifierDemo
{
    public class DateModifier
    {
        //private int days;
        public static double GetDaysBetweenDates(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);

            var days = Math.Abs((dateOne- dateTwo).Days);
            return days;
        }
    }
}
