using MyobExercise.Model;

namespace MyobExercise.Service
{
    /// <summary>
    /// This class calculates net income for pay slip
    /// </summary>
    public class NetIncomeHandler : PaySlipHandler
    {
        public override void Process(PaySlip paySlip)
        {
            paySlip.NetIncome = paySlip.GrossIncome - paySlip.IncomeTax;
        }
    }
}
