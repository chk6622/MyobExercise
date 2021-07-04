using MyobExercise.Factory.Interface;
using MyobExercise.Model;
using MyobExercise.Service;
using MyobExercise.Service.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace MyobExercise.Factory
{
    /// <summary>
    /// The factory which uses json to create tax handler pipeline
    /// </summary>
    public class TaxHandlerPipelineJsonFactory : ITaxHandlerPipelineFactory
    {
        private readonly string jsonFilePath;

        public TaxHandlerPipelineJsonFactory(string jsonFilePath)
        {
            this.jsonFilePath = jsonFilePath;
        }

        public ITaxHandler Create()
        {
            ITaxHandler taxHandler = null;
            if (File.Exists(jsonFilePath))
            {
                using (StreamReader file = File.OpenText(jsonFilePath))
                {
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject jsonObject = (JObject)JToken.ReadFrom(reader);

                        List<TaxLevel> taxLevels = jsonObject["TaxTable"].ToObject<List<TaxLevel>>(new JsonSerializer() { NullValueHandling = NullValueHandling.Ignore });
                        /*
                         Build pipeline
                         */
                        ITaxHandler previousHandler = null;
                        foreach (var taxLevel in taxLevels)
                        {
                            if (taxHandler == null)
                            {
                                taxHandler = new TaxHandler(taxLevel);
                                previousHandler = taxHandler;
                            }
                            ITaxHandler tempHandler = new TaxHandler(taxLevel);
                            previousHandler.SetNextHandler(tempHandler);
                            previousHandler = tempHandler;
                        }
                    }
                }
            }
            return taxHandler;
        }
    }
}
