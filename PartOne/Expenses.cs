using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartOne
{
     abstract class Expenses
    {
       //variables
       protected double [] expense = new double [5];
       protected double totalExp = 0;


        public void SetExp(double[] userExpense)
        {
            expense = userExpense;
        }

        public double GetTotalExp()
        {
            totalExp = expense.Sum();
            return totalExp;
        }

        //abstract class
        public abstract void avaliableMoney(double grossIncome);
    }
}
