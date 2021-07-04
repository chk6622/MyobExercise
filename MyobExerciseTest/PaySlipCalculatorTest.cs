using MyobExercise.Factory;
using MyobExercise.Factory.Interface;
using MyobExercise.Model;
using MyobExercise.Service;
using Xunit;

namespace MyobExerciseTest
{
    public class PaySlipCalculatorTest
    {
        [Theory]
        [InlineData("David", "Rudd", 60050, 0.09, "01 March – 31 March", 5004, 922, 4082, 450)]
        [InlineData("Ryan", "Chen", 120000, 0.1, "01 March – 31 March", 10000, 2669, 7331, 1000)]
        public void ShouldGeneratePaySlip(string firstName, string lastName, int annualSalary, double superRate, string paymentDate, int expectGrossIncome, int expectIncomeTax, int expectNetIncome, int expectSuper)
        {
            IPaySlipHandlerPipelineFactory paySlipHandlerPipelineFactory = new PaySlipHandlerPipelineFactory();
            PaySlipCalculator paySlipCalculator = new PaySlipCalculator(paySlipHandlerPipelineFactory);

            PaySlip paySlip = paySlipCalculator.GeneratePaySlip(firstName, lastName, annualSalary, superRate, paymentDate);

            Assert.Equal($"{firstName} {lastName}", paySlip.Name);
            Assert.Equal(paymentDate, paySlip.PayPeriod);
            Assert.Equal(expectGrossIncome, paySlip.GrossIncome);
            Assert.Equal(expectIncomeTax, paySlip.IncomeTax);
            Assert.Equal(expectNetIncome, paySlip.NetIncome);
            Assert.Equal(expectSuper, paySlip.Super);
        }

        [Theory]
        [InlineData("David", "Rudd", "60050", "9%", "01 March – 31 March", 5004, 922, 4082, 450)]
        [InlineData("Ryan", "Chen", "120000", "10%", "01 March – 31 March", 10000, 2669, 7331, 1000)]
        public void ShouldGeneratePaySlipByString(string firstName, string lastName, string annualSalary, string superRate, string paymentDate, int expectGrossIncome, int expectIncomeTax, int expectNetIncome, int expectSuper)
        {
            IPaySlipHandlerPipelineFactory paySlipHandlerPipelineFactory = new PaySlipHandlerPipelineFactory();
            PaySlipCalculator paySlipCalculator = new PaySlipCalculator(paySlipHandlerPipelineFactory);

            PaySlip paySlip = paySlipCalculator.GeneratePaySlip(firstName, lastName, annualSalary, superRate, paymentDate);

            Assert.Equal($"{firstName} {lastName}", paySlip.Name);
            Assert.Equal(paymentDate, paySlip.PayPeriod);
            Assert.Equal(expectGrossIncome, paySlip.GrossIncome);
            Assert.Equal(expectIncomeTax, paySlip.IncomeTax);
            Assert.Equal(expectNetIncome, paySlip.NetIncome);
            Assert.Equal(expectSuper, paySlip.Super);
        }
    }
}
