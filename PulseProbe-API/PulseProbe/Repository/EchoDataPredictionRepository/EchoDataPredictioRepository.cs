using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using PulseProbe.Model;

namespace PulseProbe.Repository
{
    public class EchoDataPredictioRepository : IEchoDataPredictionRepsoitory
    {
        private readonly ILogger<EchoDataPredictioRepository> _logger;
        public EchoDataPredictioRepository(ILogger<EchoDataPredictioRepository> logger)
        {

            _logger = logger;

        }
        public OutputDataModel EchoDataPredict(InputDataModel model)
        {
            var Prediction = new OutputDataModel();
            var inputdata = new float[]
            {
                (float)model.age,
                (float)model.sex,
                (float)model.cp,
                (float)model.trestbps,
                (float)model.chol,
                (float)model.fbs,
                (float)model.restecg,
                (float)model.thalach,
                (float)model.exang,
                (float)model.oldpeak,
                (float)model.slope,
                (float)model.ca,
                (float)model.thal,
            };
/*            {
                "age": 70,
              "sex": 1,
              "cp": 3,
              "trestbps": 200,
              "chol": 200,
              "fbs": 0,
              "restecg": 1,
              "thalach": 600,
              "exang": 0,
              "oldpeak": 1,
              "slope": 2,
              "ca": 2,
              "thal": 3
            }*/
            var path = @"C:\PulseProbeAPi\Ml Model Ecg\Decision tree\model.onnx";
            var inputTensor = new DenseTensor<float>(inputdata,new int[] {1,13});
            var input = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor<float>("float_input",inputTensor)};
            var session = new InferenceSession(path);
            var output = session.Run(input);
            Prediction.Result = output.ToArray()[0].Value;
            _logger.LogInformation("--------Predicition Result---{0}", Prediction.Result);

            var probability = output.ToArray()[1].Value;
            List<DisposableNamedOnnxValue> list = (List<DisposableNamedOnnxValue>)probability;
            var check = list.ToArray()[0].Value;
            Dictionary<long, float> probabilitiesValue = (Dictionary<long, float>)check;
            Prediction.ClassZeroProbability = probabilitiesValue[0];
            Prediction.ClassOneProbability = probabilitiesValue[1];
            _logger.LogInformation("Class 1 probability:-{0} and class 0 probability:- {1}", Prediction.ClassOneProbability, Prediction.ClassZeroProbability);
            return Prediction;
        }
        

      
    }
}
