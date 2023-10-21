using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01618250_Assignment2.Controllers
{
    /// <summary>
    /// Tis is my J3 Problem: From 1987 to 2013 (https://cemc.math.uwaterloo.ca/contests/computing/past_ccc_contests/2013/stage1/juniorEn.pdf)
    /// Finds the next year with distinct digits after the given year.
    /// </summary>
    /// <param name="year">The starting year.</param>
    /// <returns>The next year after the given year with distinct digits.</returns>
    /// <example>
    /// GET: api/J3/DistinctDigits/1987
    /// -> 2013
    /// </example>
    /// <example>
    /// GET: api/J3/DistinctDigits/999
    /// -> 1023
    /// </example>
    public class J3Controller : ApiController
    {
        [HttpGet]
        [Route("api/J3/DistinctDigits/{year}")]
        public string DistinctDigits(int year)
        {
            string msg = "";

            bool isValidYear = (year > 0) || (year < 10000);

            if (!isValidYear)
            {
                msg = "Invalid Year! Please try again";
            }
            else {
                year++;

                while (!HasDistinctDigits(year))
                {
                    year++;
                }

                msg =  year.ToString() + msg ;
            }

            return msg;
        }

        private bool HasDistinctDigits(int year)
        {
            char[] digits = year.ToString().ToCharArray();
            Array.Sort(digits);

            char previousDigit = ' ';
            foreach (char digit in digits)
            {
                if (previousDigit == digit)
                {
                    return false;
                }
                previousDigit = digit;
            }

            return true;
        }
    }
}
