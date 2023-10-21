using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01618250_Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// Calculates the total calories of a meal based on menu choices.
        /// </summary>
        /// <param name="burger">Index representing the burger choice</param>
        /// <param name="drink">Index representing the drink choice</param>
        /// <param name="side">Index representing the side order choice</param>
        /// <param name="dessert">Index representing the dessert choice</param>
        /// <returns>A string indicating the total calorie count of the meal.</returns>
        /// <example>
        /// GET: /api/J1/Menu/4/4/4/4
        /// -> "Your total calorie count is 0"
        /// </example>
        /// <example>
        /// GET: /api/J1/Menu/1/2/3/4
        /// -> "Your total calorie count is 691"
        /// </example>
        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public string Menu(int burger, int drink, int side, int dessert)
        {
            // Define calorie values for each menu item
            int[] burgerCalories = { 461, 431, 420, 0 };
            int[] drinkCalories = { 130, 160, 118, 0 };
            int[] sideCalories = { 100, 57, 70, 0 };
            int[] dessertCalories = { 167, 266, 75, 0 };

            // Validate input choices
            bool isValidBurger = (burger >= 1 && burger <= burgerCalories.Length + 1);
            bool isValidDrink = (drink >= 1 && drink <= drinkCalories.Length + 1);
            bool isValidSide = (side >= 1 && side <= sideCalories.Length + 1);
            bool isValidDessert = (dessert >= 1 && dessert <= dessertCalories.Length + 1);

            string message = "";


            if (!isValidBurger || !isValidDrink || !isValidSide || !isValidDessert)
            {
                message = "Invalid menu choice";
                return message;
            }

            // Calculate total calories
            int totalCalories = burgerCalories[burger - 1] + 
                                drinkCalories[drink - 1] +
                                sideCalories[side - 1] + 
                                dessertCalories[dessert - 1];
            message = "Your total calorie count is " + totalCalories;

            return message;
        }
    }
}
