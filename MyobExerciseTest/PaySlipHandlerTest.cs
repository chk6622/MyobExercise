using MyobExercise.Factory;
using MyobExercise.Factory.Interface;
using MyobExercise.Model;
using MyobExercise.Service;
using MyobExercise.Service.Interface;
using Xunit;

namespace MyobExerciseTest
{
    public class PaySlipHandlerTest
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(1200,100)]
        [InlineData(2400,200)]
        [InlineData(12000,1000)]
        [InlineData(24000,2000)]
        public void ShouldHandleGrossIncome(int annualSalary, int expectValue)
        {
            PaySlip paySlip = new PaySlip()
            {
                AnnualSalary = annualSalary,
            };
            IPaySlipHandler grossIncomeHandler = new GrossIncomeHandler();
            grossIncomeHandler.Handle(paySlip);

            Assert.Equal(expectValue, paySlip.GrossIncome);
        }

        [Theory]
        [InlineData(10000,0)]
        [InlineData(20000, 28)]
        [InlineData(60050,922)]
        [InlineData(120000, 2669)]
        [InlineData(200000, 5269)]
        public void ShouldHandleIncomeTax(int annualSalary, int expectValue)
        {
            PaySlip paySlip = new PaySlip()
            {
                AnnualSalary = annualSalary,
            };
            ITaxHandlerPipelineFactory factory = new TaxHandlerPipelineJsonFactory("./TaxTableConfig.json");
            IPaySlipHandler incomeTaxHandler = new IncomeTaxHandler(factory);

            incomeTaxHandler.Handle(paySlip);

            Assert.Equal(expectValue, paySlip.IncomeTax);
        }

        [Theory]
        [InlineData(1000, 0, 1000)]
        [InlineData(1000,100,900)]
        [InlineData(1000,500,500)]
        public void ShouldHandleNetIncome(int grossIncome, int incomeTax, int expectValue)
        {
            PaySlip paySlip = new PaySlip()
            {
                GrossIncome = grossIncome,
                IncomeTax = incomeTax
            };
            IPaySlipHandler netIncomeHandler = new NetIncomeHandler();
            netIncomeHandler.Handle(paySlip);

            Assert.Equal(expectValue, paySlip.NetIncome);
        }

        [Theory]
        [InlineData(10000, 0.05, 500)]
        [InlineData(200, 0.5, 100)]
        [InlineData(50000,0.25,12500)]
        public void ShouldHandleSuper(int grossIncome, double superRate, int expectValue)
        {
            PaySlip paySlip = new PaySlip()
            {
                GrossIncome = grossIncome,
                SuperRate = superRate
            };
            IPaySlipHandler netIncomeHandler = new SuperHandler();
            netIncomeHandler.Handle(paySlip);

            Assert.Equal(expectValue, paySlip.Super);
        }
    }
}
