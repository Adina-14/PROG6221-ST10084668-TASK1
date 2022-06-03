using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PartOne
{
     class HomeLoan : Expenses
    {
        //declare variables
        private double propertyPrice;
        private double totalDeposit;
        private double interestRate;
        private int months;



        override public void avaliableMoney(double grossIncome)
        {
            Console.WriteLine("\n\n=========================================================================" +
              "\n\nBuying a property : \n");

            //prompt for price of the property and reads
            Console.Write("Enter Purchase price of the property : ");
            propertyPrice = Convert.ToDouble(Console.ReadLine());

            //prompt for deposit and reads
            Console.Write("Enter Total deposit : ");
            totalDeposit = Convert.ToDouble(Console.ReadLine());

            //prompt for interest in percentage and reads
            Console.Write("Enter interest rate (percentage) : ");
            interestRate = Convert.ToDouble(Console.ReadLine());

            //prompt for time period in months and reads
            Console.Write("Enter number of months to repay (between 240 and 360) : ");
            months = Convert.ToInt32(Console.ReadLine());

            //if user input is invalid-----------------------------------------------
            while ((months != 240) && (months != 360))
            {
                Console.WriteLine("InValid Entry ! Please try again >>>");
                Console.Write("Enter number of months to repay (between 240 and 360) : ");
                months = Convert.ToInt32(Console.ReadLine());
            }
            //-----------------------------------------------------------------------

            //formula using simple interest A = P(1+i*n)

            double PrincipleAmt = propertyPrice - totalDeposit;
            double interest = interestRate / 100; //decimal
            int years = months / 12; //in years

            //monthly repayment
            double monthlyRepay = (PrincipleAmt * (1 + (interest * years))) / months;


            //if homeloan is unlikely-----------------------------------
            if (monthlyRepay > (grossIncome / 3))
            {
                //change color of text
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nApproval of home loan is unlikey!!!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                //------------------------------------------------------
            }

            //control speed of program----
            Console.Write("\nCalculating");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }//--------------------------

            //-------------------------output------------------------------------------
            double avaMoney = grossIncome - (monthlyRepay + GetTotalExp());
            Console.WriteLine("\nMonthly Repayment: R" + Math.Round(monthlyRepay, 2));
            Console.WriteLine("\nAvaliable monthly money : R" + Math.Round(avaMoney, 2));
            //------------------------------------------------------------------------

            //add to dictionary
            exp.Add("Home Loan Repayment", Math.Round(monthlyRepay, 2));
            
        }


    }
}
