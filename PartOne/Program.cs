using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PartOne
{
    public class Program
    {
        //Delegate declaration
        public delegate void notifyUserDelegate(double incomeDel, double totalExpenseDel);

        static void Main(string[] args)
        {
            try
            {
                //method call to display welcome text
                beginText();

                //method call get income
                double grossIncome = getGrossIncome();


                //method call to get all expenses
                Dictionary<string, double> e = (Dictionary<string, double>)allExpenses();

                //method call to rent or buy
                int choice = rentOrBuy();

                if (choice == 1)
                {
                    //user is renting

                    Rent r = new Rent();
                    r.SetExp(e);
                    r.avaliableMoney(grossIncome);

                }
                else
                //User is buying a property
                if (choice == 2)
                {
                    HomeLoan hl = new HomeLoan();
                    hl.SetExp(e);
                    hl.avaliableMoney(grossIncome);
                }


                int option = buyingVehicle();//method call

                //instant vehicle class
                Vehicle v = new Vehicle();
                v.SetExp(e);
                //user is buying a vehicles
                if (option == 1)
                {
                    v.avaliableMoney(grossIncome);
                }

                v.SetExp(e);

                //--delegate to notify the user when expenses exceed 75% for their gross income-------
                notifyUserDelegate nud = delegate (double incomeDel, double totalExpenseDel)
                {
                    if (totalExpenseDel > (incomeDel * 0.75))
                    {
                        //change color of text
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        //display message
                        Console.WriteLine("\nALERT: Your total Expenses exceed 75% of your monthly income");
                        //change color of text back
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                };
                nud.Invoke(grossIncome, v.GetTotalExp());
                //---------------------------------------------------------------------------------------


                //call method to display all expenses
                displayExp(e);

            }//try
            //exception handling
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;

            }


        }//end main

        public static void beginText()
        {
            //controls speed of program
            Console.Write("Loading");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            //change color of text
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t\t\tWelcome to Budget Planner" +
                "\n=========================================================================");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        //get income 
        public static double getGrossIncome()
        {
            Console.WriteLine("Income : \n");
            //Gross monthly income(before deductions)
            Console.Write("Enter Gross monthly income : ");
            double grossIncome = Convert.ToDouble(Console.ReadLine());
            return grossIncome;
        }


        //Renting or buying
        public static int rentOrBuy()
        {
            Console.WriteLine("\n\n=========================================================================" +
               "\n\nAccomodation : \n");

            Console.Write("Enter '1' if you are renting or '2' if you are buying a property : ");
            int choice = Convert.ToInt32(Console.ReadLine());

            //loops if the users input is invalid
            while ((choice <= 0) || (choice > 2))
            {
                Console.WriteLine("InValid Entry please try again .");
                Console.Write("Enter '1' if you are renting or '2' if you are buying a property : ");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            return choice;
        }

        //gets all the expenses and store them in an array -->then returns the array
        public static Dictionary<string, double> allExpenses()
        {
            Console.WriteLine("\n\n=========================================================================" +
               "\n\nExpenses : \n");

            //Estimated monthly tax deducted
            Console.Write("Enter estimated monthly tax deducted : ");
            double tax = Convert.ToDouble(Console.ReadLine());


            //Estimated monthly expenditure for :
            //Groceries
            Console.Write("Enter cost of groceries : ");
            double groceries = Convert.ToDouble(Console.ReadLine());

            //water and lights
            Console.Write("Enter cost of water and lights : ");
            double rates = Convert.ToDouble(Console.ReadLine());

            //Travel costs (including petrol)
            Console.Write("Enter cost of travel (including petrol) : ");
            double travel = Convert.ToDouble(Console.ReadLine());

            //Cellphone and telephone
            Console.Write("Enter cost of Cell phone and telephone : ");
            double phone = Convert.ToDouble(Console.ReadLine());

            //other expenses
            Console.Write("Enter the cost of any other expenses : ");
            double other = Convert.ToDouble(Console.ReadLine());

            //expenses stored as a pair in a generic collection (dictionary)
            Dictionary<string, double> e = new Dictionary<string, double>();
            e.Add("Tax", Math.Round(tax, 2));
            e.Add("Groceries", Math.Round(groceries, 2));
            e.Add("Rates", Math.Round(rates, 2));
            e.Add("Travel", Math.Round(travel, 2));
            e.Add("Phone", Math.Round(phone, 2));
            e.Add("Other", Math.Round(other, 2));
            //---------------------------------------------------------------

            //return the dictionary
            return e;
        }

        public static int buyingVehicle()
        {
            Console.WriteLine("\n\n=========================================================================" +
              "\n\nVehicle : \n");
            //prompt user for input
            Console.Write("Enter '1' if you are buying a vehicle or any other digit to continue: ");
            int option = Convert.ToInt32(Console.ReadLine());

            return option;
        }

        public static void displayExp(Dictionary<string, double> e)
        {
            // arranges the expenses in the dictionary in descending order 
            var dec = from expe in e orderby expe.Value descending select expe;

            //displays the expenses
            Console.WriteLine("\n=====================================\nExpenses:\n=====================================");
            foreach (KeyValuePair<string, double> expe in dec)
            {
                Console.WriteLine(" {0} : R{1}", expe.Key, expe.Value);
            }
            Console.ReadLine();

        }
    }
}
