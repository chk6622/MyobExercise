using MyobExercise.Factory.Interface;
using MyobExercise.Model;
using MyobExercise.Service.Interface;
using System;

namespace MyobExercise.Service
{
    /// <summary>
    /// This class calculates income tax for pay slip
    /// </summary>
    public class IncomeTaxHandler : PaySlipHandler
    {
        private readonly ITaxHandler taxHandler;
        public IncomeTaxHandler(ITaxHandlerPipelineFactory taxHandlerPipelineFactory)
        {
            taxHandler = taxHandlerPipelineFactory?.Create() ?? throw new ArgumentNullException(nameof(taxHandlerPipelineFactory));
        }
        public override void Process(PaySlip paySlip)
        {
            paySlip.IncomeTax = taxHandler.Handle(paySlip.AnnualSalary);
        }
    }
}
