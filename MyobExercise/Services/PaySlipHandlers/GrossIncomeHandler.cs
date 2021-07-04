using MyobExercise.Model;
using System;

namespace MyobExercise.Service
{
    /// <summary>
    /// This class calculate gross income for pay slip
    /// </summary>
    public class GrossIncomeHandler : PaySlipHandler
    {
        public override void Process(PaySlip paySlip)
        {
            paySlip.GrossIncome = (int)Math.Round(paySlip.AnnualSalary / 12.0);
        }
    }
}
