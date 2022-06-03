using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PartOne
{
     class Rent : Expenses
    {
        private double rentAmt;


        override public void avaliableMoney(double grossIncome)
        {
            Console.WriteLine("\n\n=========================================================================" +
               "\n\nRenting : \n");

            //prompt user 
            Console.Write("Enter the month Rental amount : ");
            rentAmt = Convert.ToDouble(Console.ReadLine());

            double avaMoney = grossIncome - (rentAmt + GetTotalExp());//cal avaliable money

            //---control speed of program----
            Console.Write("\nCalculating");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            //------------------------------


            //display
            Console.WriteLine("\nAvaliable monthly money : R" + Math.Round(avaMoney, 2));

            //add to dictionary
            exp.Add("Rent", Math.Round(rentAmt, 2));
            
        }

    }
}

