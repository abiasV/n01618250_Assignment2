using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01618250_Assignment2.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// Determines the number of ways to roll the value of 10 with two dice.
        /// </summary>
        /// <param name="m">Number of sides on the first die.</param>
        /// <param name="n">Number of sides on the second die.</param>
        /// <returns>A string number of ways to get the sum 10.</returns>
        /// <example>
        /// GET: /api/J2/DiceGame/6/8
        /// -> "There are 5 total ways to get the sum 10."
        /// </example>
        /// <example>
        /// GET: /api/J2/DiceGame/12/4
        /// -> "There are 4 ways to get the sum 10."
        /// </example>
        /// <example>
        /// GET: /api/J2/DiceGame/3/3
        /// -> "There are 0 ways to get the sum 10."
        /// </example>
        /// <example>
        /// GET: /api/J2/DiceGame/5/5
        /// -> "There is 1 way to get the sum 10."
        /// </example>
        [HttpGet]
        [Route("api/J2/DiceGame/{m}/{n}")]
        public string DiceGame(int m, int n)
        {
            string msg = "";
            if (m <= 0 || n <= 0)
            {
                return msg + "Number of sides should be greater than zero";
            }

            int target = 10;
            int counter = 0;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i + j == target) {
                    counter++;
                    }
                }
            }
            if (counter == 0)
            {
                msg = "There are 0 ways to get the sum 10.";
                return msg;
            }
            else if (counter == 1)
            {
                msg = "There is 1 way to get the sum 10.";
                return msg;
            }
            else
            {
                msg = "There are " + counter + " ways to get the sum 10.";
                return msg;
            }
        }
    }
}
