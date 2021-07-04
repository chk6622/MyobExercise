using MyobExercise.Factory.Interface;
using MyobExercise.Model;
using MyobExercise.Service.Interface;
using System;

namespace MyobExercise.Service
{
    /// <summary>
    /// Pay slip calculator class
    /// </summary>
    public class PaySlipCalculator
    {
        private readonly IPaySlipHandler paySlipHandler;
        public PaySlipCalculator(IPaySlipHandlerPipelineFactory paySlipHandlerPipelineFactory)
        {
            paySlipHandler = paySlipHandlerPipelineFactory?.Create()??throw new ArgumentNullException(nameof(paySlipHandlerPipelineFactory));
        }

        /// <summary>
        /// Generate a pay slip
        /// </summary>
        /// <param name="firstName">employee's first name</param>
        /// <param name="lastName">employee's last name</param>
        /// <param name="annualSalary">employee's annual salary : int</param>
        /// <param name="superRate">super rate : double</param>
        /// <param name="paymentDate">payment date</param>
        /// <returns></returns>
        public PaySlip GeneratePaySlip(string firstName, string lastName, int annualSalary, double superRate, string paymentDate)
        {
            PaySlip employeePaySlip = new PaySlip()
            {
                Name = $"{firstName} {lastName}",
                PayPeriod = paymentDate,
                AnnualSalary = annualSalary,
                SuperRate = superRate,
            };

            paySlipHandler.Handle(employeePaySlip);

            return employeePaySlip;
        }

        /// <summary>
        /// Generate a pay slip
        /// </summary>
        /// <param name="firstName">employee's first name</param>
        /// <param name="lastName">employee's last name</param>
        /// <param name="annualSalary">employee's annual salary : string</param>
        /// <param name="superRate">super rate : string</param>
        /// <param name="paymentDate">payment date</param>
        /// <returns></returns>
        public PaySlip GeneratePaySlip(string firstName, string lastName, string annualSalary, string superRate, string paymentDate)
        {
            int intAnnualSalary = int.Parse(annualSalary);
            string p = superRate.TrimEnd('%');
            double doubleSuperRate = int.Parse(p) * 0.01;
            return GeneratePaySlip(firstName, lastName, intAnnualSalary, doubleSuperRate, paymentDate);
        }
    }
}
