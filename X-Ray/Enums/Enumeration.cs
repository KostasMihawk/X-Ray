using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace X_Ray.Enums
{
    public class Enumeration
    {
        public enum Gender
        {
            Male,
            Female
        }
        public enum Priority
        {
            Zero,
            Normal,
            Top
        }

        public enum Status
        {
            Pending,
            Completed,
            Canceled
        }
    }
}