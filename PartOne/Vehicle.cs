using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PartOne
{
     class Vehicle : Expenses
    {
        private string model; //model of vehicle
        private string make; //make of vehicle
        private double purPrice; //purchase price of vehicle
        private double totDep; //total deposit for vehicle
        private double intRate; //interest rate
        private double insurance; //Estimate insurance premium

        override public void avaliableMoney(double grossIncome)
        {
            Console.WriteLine("\n\n=========================================================================" +
             "\n\nBuying a vehicle : \n");

            //----------Prompt user for input-------
            Console.Write("Enter vehicle make :");
            make = Console.ReadLine();

            Console.Write("Enter vehicle model :");
            model = Console.ReadLine();

            Console.Write("Enter vehicle purchase price : ");
            purPrice = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Total deposit : ");
            totDep = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter interest rate (without %) : ");
            intRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter estimated insurance premium : ");
            insurance = Convert.ToDouble(Console.ReadLine());
            //---------------------------------------------------------------

            //declare and initialise variables
            double vehicleCost = 0;
            double monthlyPayment = 0;

            //--------------------------calculation for vehicle payments----------------------------
            double principleAmt = purPrice - totDep; //calc amount to be paid
            intRate = intRate / 100; //converts rate into correct format
            vehicleCost = principleAmt * (1 + (intRate * 5)); // formula: A=P(1+(ixn)
            monthlyPayment = (vehicleCost / 60) + insurance; //monthly payments including insurance
            //--------------------------------------------------------------------------------------

            //-----------calculating available money at the end of the month-------
            double avaMoney = grossIncome - (monthlyPayment + GetTotalExp());
            //---------------------------------------------------------------------

            //-----control speed of program----
            Console.Write("\nCalculating");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            //---------------------------------

            //---------------------------------Display-----------------------------------
            Console.WriteLine("\n Vehicle Monthly Repayment: R" + Math.Round(monthlyPayment, 2));
            Console.WriteLine("\nAvaliable monthly money : R" + Math.Round(avaMoney, 2));
            //---------------------------------------------------------------------------

            //--------Store in dictionary-----
            exp.Add("Vehicle", Math.Round(monthlyPayment, 2));
            
            //--------------------------------
        }
    }
}

