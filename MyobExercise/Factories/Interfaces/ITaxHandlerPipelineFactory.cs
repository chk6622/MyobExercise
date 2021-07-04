using MyobExercise.Service.Interface;

namespace MyobExercise.Factory.Interface
{
    /// <summary>
    /// Tax handler pipeline factory interface
    /// </summary>
    public interface ITaxHandlerPipelineFactory
    {
        /// <summary>
        /// Create a tax handler pipeline
        /// </summary>
        /// <returns>The fist handler of the pipeline</returns>
        ITaxHandler Create();
    }
}
