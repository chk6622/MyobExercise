using MyobExercise.Model;
using System;

namespace MyobExercise.Service
{
    /// <summary>
    /// This class calculates super for pay slip.
    /// </summary>
    public class SuperHandler : PaySlipHandler
    {
        public override void Process(PaySlip paySlip)
        {
            paySlip.Super = (int)Math.Round(paySlip.GrossIncome * paySlip.SuperRate);
        }
    }
}
