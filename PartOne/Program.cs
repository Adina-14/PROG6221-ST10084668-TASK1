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
        //global varible
        
        static void Main(string[] args)
        {
           //method call to display welcome text
            beginText();

            Console.WriteLine("Income : \n");
            //Gross monthly income(before deductions)
            Console.Write("Enter Gross monthly income : ");
            double grossIncome = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n\n=========================================================================" +
               "\n\nExpenses : \n");
            //method calls
            double[] userExpense = (double[])allExpenses();

            Console.WriteLine("\n\n=========================================================================" +
                "\n\nAccomodation : \n");
            int choice = rentOrBuy();

            if (choice == 1)
            {
                //user is renting

                Rent r = new Rent();
                r.SetExp(userExpense);
                r.avaliableMoney(grossIncome);

            }
            else
            //User is buying a property
            if (choice == 2)
            {
                HomeLoan hl = new HomeLoan();
                hl.SetExp(userExpense);
                hl.avaliableMoney(grossIncome);
            }
            


            Console.ReadLine();


        }

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


        //Renting or buying
        public static int rentOrBuy()
        {
            

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
        public static Array allExpenses()
        { 

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
            
            //expenses stored in array
            double[] userExpense = {tax,groceries,rates,travel,phone,other };
            return userExpense;
        }
    }
}
