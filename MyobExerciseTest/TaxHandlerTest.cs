using MyobExercise.Model;
using MyobExercise.Service;
using MyobExercise.Service.Interface;
using Xunit;

namespace MyobExerciseTest
{
    public class TaxHandlerTest
    {
        [Theory]
        [InlineData(50,0)]
        [InlineData(501, 0)]
        [InlineData(101,4)]
        [InlineData(200, 8)]
        [InlineData(500, 21)]
        public void ShouldProcessAnnualSalaryWithinTaxLevel(int annualSalary, int expectTax)
        {
            int bottomIncome = 100;
            int ceilingIncome = 500;
            int baseTax = 50;
            double unitTax = 0.5;
            TaxLevel taxLevel = new TaxLevel()
            {
                BottomIncome = bottomIncome,
                CeilingIncome = ceilingIncome,
                BaseTax = baseTax,
                UnitTax = unitTax
            };
            ITaxHandler taxHandler = new TaxHandler(taxLevel);

            Assert.Equal(expectTax,taxHandler.Handle(annualSalary));
        }
    }
}
