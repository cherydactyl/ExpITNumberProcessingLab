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
             * Problem definition:
             * Every day, a woman deposits $35.00 in her bank account.  Write a program that
             * prints out how much money she has after 1 year, 2 years, 5 years, and 10 years.
             * Assume she starts her deposits on January 1, 2015
             */

            // Question: What numberic type should be used?
            // My answer: per the reccomendation we were given, fixed point is a good type for currency,
            // however, I have used a float for this solution.

            Console.WriteLine("Accumulation");
            Console.WriteLine("A woman deposits $35.00 in her bank account every day.");
            Console.WriteLine("(Note: this solution assumes no interest is earned on the deposits.)");
            Console.WriteLine();    //whitespace
            //define datetime for January 1, 2015
            DateTime startDate = new DateTime(2015, 1, 1);
            float perDiem = (float) 35.00;
            
            Console.WriteLine("If she starts on " + startDate.ToShortDateString() + " then,");

            //after 1 year
            DateTime endDate = new DateTime(2015, 12, 31);
            Console.WriteLine("after 1 year, she will have $" + calculateBalance(perDiem, startDate, endDate));

            //after 2 years
            endDate = new DateTime(2016, 12, 31);
            Console.WriteLine("after 2 years, she will have $" + calculateBalance(perDiem, startDate, endDate));

            //after 5 years
            endDate = new DateTime(2019, 12, 31);
            Console.WriteLine("after 5 years, she will have $" + calculateBalance(perDiem, startDate, endDate));

            //after 10 years
            endDate = new DateTime(2024, 12, 31);
            Console.WriteLine("after 10 years, she will have $" + calculateBalance(perDiem, startDate, endDate));

            Console.WriteLine();    //whitespace
            Console.WriteLine();    //whitespace

            /* Land Cost Calculator
             * 
             * In a far away land, people pay for land by a combination of the parcel's area and its perimeter.
             * Land costs $5 per square yard plus $0.75 per foot of the perimeter.
             */
            Console.WriteLine("Land Cost Calculator");
            Console.WriteLine();    //Whitespace

            Console.WriteLine("To calculate the cost of a parcel, please input its dimensions in whole feet (numbers only please):");
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
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        static double calculateBalance(float increment, DateTime startDate, DateTime endDate )
        {
            return ((endDate - startDate).TotalDays * increment);
        }

        



        
    
        

        //Land Cost Calculator


        //Space Exploration

    
    
}

    


}
