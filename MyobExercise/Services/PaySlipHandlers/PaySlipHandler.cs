using MyobExercise.Model;
using MyobExercise.Service.Interface;

namespace MyobExercise.Service
{
    /// <summary>
    /// Pay slip handler template class
    /// </summary>
    public abstract class PaySlipHandler : IPaySlipHandler
    {
        protected IPaySlipHandler next = null;
        public void Handle(PaySlip paySlip)
        {
            if(paySlip == null)
            {
                return;
            }
            Process(paySlip);
            if (this.next != null)
            {
                this.next.Handle(paySlip);
            }
        }

        public void SetNextHandler(IPaySlipHandler paySlipHandler)
        {
            this.next = paySlipHandler;
        }

        /// <summary>
        /// Process bussiness logic
        /// </summary>
        /// <param name="paySlip">The pay slip object to be processed</param>
        public abstract void Process(PaySlip paySlip);
    }
}
