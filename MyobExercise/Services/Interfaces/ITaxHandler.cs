namespace MyobExercise.Service.Interface
{
    /// <summary>
    /// Tax handler interface
    /// </summary>
    public interface ITaxHandler
    {
        /// <summary>
        /// Set the next handler
        /// </summary>
        /// <param name="paySlipHandler">the next handler</param>
        void SetNextHandler(ITaxHandler taxHandler);

        /// <summary>
        /// Get tax according to annual salary
        /// </summary>
        /// <param name="annualSalary">Annual salary</param>
        int Handle(int annualSalary);
    }
}
