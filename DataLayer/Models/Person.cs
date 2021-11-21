using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Person
    {
        private DateTime _dateOfBirth;

        public void SetDateOfBirth(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
        }

        public int AgeYears => Years(_dateOfBirth, DateTime.Today);

        private static int Years(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
            (((end.Month > start.Month) ||
            ((end.Month == start.Month)
            && (end.Day >= start.Day)))
            ? 1 : 0);
        }
    }
}


                                                                                                              