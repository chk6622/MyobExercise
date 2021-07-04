using MyobExercise.Model;
using MyobExercise.Service.Interface;
using System;

namespace MyobExercise.Service
{
    public class TaxHandler : ITaxHandler
    {

        private ITaxHandler next = null;
        private readonly TaxLevel taxLevel;   //Tax level

        public TaxHandler(TaxLevel taxLevel)
        {
            this.taxLevel = taxLevel ?? throw new ArgumentNullException(nameof(taxLevel));
        }
        public int Handle(int annualSalary)
        {
            int tax = 0;
            if (annualSalary >= taxLevel.BottomIncome && annualSalary <= taxLevel.CeilingIncome)
            {
                tax = (int)Math.Round((taxLevel.BaseTax + (annualSalary - taxLevel.BottomIncome - 1) * taxLevel.UnitTax) / 12);  
            }
            else if (this.next != null)
            {
                tax = this.next.Handle(annualSalary);
            }
            return tax;
        }

        public void SetNextHandler(ITaxHandler taxHandler)
        {
            this.next = taxHandler;
        }
    }
}
