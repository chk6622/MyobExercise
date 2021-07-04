using MyobExercise.Model;

namespace MyobExercise.Service.Interface
{
    /// <summary>
    /// Pay slip handler interface
    /// </summary>
    public interface IPaySlipHandler
    {
        /// <summary>
        /// Set the next handler
        /// </summary>
        /// <param name="paySlipHandler">the next handler</param>
        void SetNextHandler(IPaySlipHandler paySlipHandler);

        /// <summary>
        /// Process pay slip
        /// </summary>
        /// <param name="paySlip">The pay slip object to be handled</param>
        void Handle(PaySlip paySlip);
    }
}
