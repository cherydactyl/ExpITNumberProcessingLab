using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpITNumberProcessingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Accumulation
             * 
             * Every day, a woman deposits $35.00 in her bank account.  Write a program that
             * prints out how much money she has after 1 year, 2 years, 5 years, and 10 years.
             * Assume she starts her deposits on January 1, 2015
             */

            // Question: What numberic type should be used?
            // My answer: per the reccomendation we were given, fixed point is a good type for currency,
            // however, I have used a double for this solution.

            Console.WriteLine("**PART 1: Accumulation");
            Console.WriteLine("A woman deposits $35.00 in her bank account every day.");
            Console.WriteLine("(Note: this solution assumes no interest is earned on the deposits.)");
            Console.WriteLine();    //whitespace
            //define datetime for January 1, 2015
            DateTime startDate = new DateTime(2015, 1, 1);
            double perDiem = 35.00;

            Console.WriteLine("If she starts on " + startDate.ToShortDateString() + ",\n" +
                "depositing $" + perDiem.ToString("c2") + " each day, then,");

            //after 1 year
            DateTime endDate = new DateTime(2015, 12, 31);
            Console.WriteLine("after 1 year, she will have " + calculateBalance(perDiem, startDate, endDate).ToString("c2"));

            //after 2 years
            endDate = new DateTime(2016, 12, 31);

            //check if DateTime functionality seems to be correctly treating the leap years
            //Console.WriteLine((new DateTime (2015,12,31) - new DateTime(2015,1,1)).TotalDays);
            //Console.WriteLine((new DateTime(2016, 12, 31) - new DateTime(2016, 1, 1)).TotalDays);
            //Console.WriteLine((new DateTime(2024, 12, 31) - new DateTime(2024, 1, 1)).TotalDays);
            //seems to work as expected
            
            Console.WriteLine("after 2 years, she will have " + calculateBalance(perDiem, startDate, endDate).ToString("c2"));

            //after 5 years
            endDate = new DateTime(2019, 12, 31);
            Console.WriteLine("after 5 years, she will have " + calculateBalance(perDiem, startDate, endDate).ToString("c2"));

            //after 10 years
            endDate = new DateTime(2024, 12, 31);
            Console.WriteLine("after 10 years, she will have " + calculateBalance(perDiem, startDate, endDate).ToString("c2"));

            Console.WriteLine();    //whitespace
            Console.WriteLine();    //whitespace
            Console.WriteLine("Press any key to continue to Part 2.");
            Console.ReadKey();
            Console.WriteLine();    //whitespace
            Console.WriteLine();    //whitespace

            /* Land Cost Calculator
             * 
             * In a far away land, people pay for land by a combination of the parcel's area and its perimeter.
             * Land costs $5 per square yard plus $0.75 per foot of the perimeter.
             */
            Console.WriteLine("**Part 2: Land Cost Calculator");
            Console.WriteLine();    //Whitespace

            Console.WriteLine("To calculate the cost of a parcel, please input its dimensions in whole feet\n" + "(numbers only please):");
            Console.WriteLine("What is the length in feet?");
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the width in feet?");
            int width = int.Parse(Console.ReadLine());

            //calculate area in square feet
            int area = length * width;

            //calculate perimeter in feet
            int perimeter = 2 * (length + width);

            //calculate cost; take care with units
            decimal areaInSqYards = (decimal)area / 9;
            decimal cost = Math.Round((areaInSqYards * 5) + (decimal)(perimeter * .75), 2);

            Console.WriteLine("The cost for a parcel " + width + " feet  by " + length + " feet is $" + cost + ".");

            Console.WriteLine();    //whitespace
            Console.WriteLine();    //whitespace
            Console.WriteLine("Press any key to continue to Part 3.");
            Console.ReadKey();
            Console.WriteLine();    //whitespace
            Console.WriteLine();    //whitespace

            Console.WriteLine("**Part 3: Space Exploration");
            Console.WriteLine();    //Whitespace

            /*Space Exploration
             * Once in space, a space ship can increase its velocity by 5% by firing its boosters for 30 seconds.
             * Assume the space craft is travelleing at 10,000 miles per hour.
             * 
             * How fast will it be traveling after 2 hours
            */

            //define velocity and initiate starting value
            double velocity = 10000;

            Console.WriteLine("For a ship starting at velocity 10,000 mph,\n" +
                "if it can increase its velocity by 5% for each 30 seconds,");

            //loop over t, where t is time in seconds
            //remember that 5 minutes is 300 seconds
            for (int t = 0; t < 300; t += 30)
            {
                velocity *= 1.05;    //adding 5% is like multiplying by 105%
                //Console.WriteLine(velocity);  //used for debugging checks
            }
            Console.WriteLine("Then after 5 minutes of firing its boosters, \nthe craft will be traveling at " +
                Math.Round(velocity, 0) + " miles per hour");

            Console.WriteLine();    //whitespace
            Console.WriteLine("For a ship starting at velocity 10,000 mph,\n" +
                "if it can increase its velocity by 5% for each 30 seconds,\n" +
                "but cannot fire continuously, imagine that the craft fires boosters\n" +
                "for 5 minutes, then coasts for 10 minutes, and repeats the cycle \n" +
                "for a total of two hours.");

            //reset the velocity for the new situation
            velocity = 10000;

            //loop over t, where t is time in seconds
            //remember that 5 minutes is 300 seconds, and 10 minutes is 600 seconds
            int endTime = 2 * 60 * 60;  //calculate two hours in seconds, for convience and readability
            //Console.WriteLine("Two hours in seconds is " + endTime);    //for debugging help

            //each cycle is 15 minutes: 5 of burn and 10 of coast
            //outer loop will increment t for coasting
            for (int t = 0; t < endTime; t += 600)
            {
                //Console.WriteLine("At time " + t + " seconds, the velocity is " + velocity);

                //burn for 5 minutes
                //inner loop will increment t for burn time
                for (int endBurn = t + 300; t < endBurn; t += 30)
                {
                    velocity *= 1.05;    //adding 5% is like multiplying by 105%
                    //Console.WriteLine(velocity);  //used for debugging checks
                }
                //Console.WriteLine("At time " + t + " seconds, the velocity is " + velocity);
            }

            Console.WriteLine();    //Whitespace
            Console.WriteLine("At then end of the two hours, the craft is traveling at "
                + Math.Round(velocity, 0) + " miles per hour.");


            //Hold the console open until the user is ready to exit.
            Console.WriteLine();    //whitespace
            Console.WriteLine();    //whitespace
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        //helper method for Part 1
        //takes a daily increment amount, a start date, and end date
        static double calculateBalance(double increment, DateTime startDate, DateTime endDate)
        {
            //calculate days between start and end date
            //add one to account for a deposit on the end date
            //multiply by increment per day, and return the value
            return (((endDate - startDate).TotalDays + 1) * increment);
        }
    }
}