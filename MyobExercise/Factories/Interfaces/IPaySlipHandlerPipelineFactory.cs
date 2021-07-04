using MyobExercise.Service.Interface;

namespace MyobExercise.Factory.Interface
{
    /// <summary>
    /// Pay slip handler pipeline factory interface
    /// </summary>
    public interface IPaySlipHandlerPipelineFactory
    {
        /// <summary>
        /// Create a pay slip handler pipeline
        /// </summary>
        /// <returns>The fist handler of the pipeline</returns>
        IPaySlipHandler Create();
    }
}
