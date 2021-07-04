using MyobExercise.Factory.Interface;
using MyobExercise.Service;
using MyobExercise.Service.Interface;

namespace MyobExercise.Factory
{
    public class PaySlipHandlerPipelineFactory : IPaySlipHandlerPipelineFactory
    {
        public IPaySlipHandler Create()
        {
            IPaySlipHandler grossIncomeHandler = new GrossIncomeHandler();
            IPaySlipHandler incomeTaxHandler = new IncomeTaxHandler(new TaxHandlerPipelineJsonFactory(Constant.TAX_TABLE_CONFIG_FILE_PATH));
            IPaySlipHandler netIncomeHandler = new NetIncomeHandler();
            IPaySlipHandler superHandler = new SuperHandler();
            grossIncomeHandler.SetNextHandler(incomeTaxHandler);
            incomeTaxHandler.SetNextHandler(netIncomeHandler);
            netIncomeHandler.SetNextHandler(superHandler);
            return grossIncomeHandler;
        }
    }
}
