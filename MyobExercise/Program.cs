using MyobExercise.Factory;
using MyobExercise.Factory.Interface;
using MyobExercise.Model;
using MyobExercise.Service;
using System;

namespace MyobExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            IPaySlipHandlerPipelineFactory paySlipHandlerPipelineFactory = new PaySlipHandlerPipelineFactory();
            PaySlipCalculator paySlipCalculator = new PaySlipCalculator(paySlipHandlerPipelineFactory);

            PaySlip paySlip = paySlipCalculator.GeneratePaySlip("David", "Rudd", "60050", "9%", "01 March – 31 March");
            Console.WriteLine(paySlip);

            paySlip = paySlipCalculator.GeneratePaySlip("David", "Rudd", 60050, 0.09, "01 March – 31 March");
            Console.WriteLine(paySlip);

            paySlip = paySlipCalculator.GeneratePaySlip("Ryan", "Chen", "120000", "10%", "01 March – 31 March");
            Console.WriteLine(paySlip);

            paySlip = paySlipCalculator.GeneratePaySlip("Ryan", "Chen", 120000, 0.1, "01 March – 31 March");
            Console.WriteLine(paySlip);
        }
    }
}
