using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrickHandler.Model.Contract
{
    public interface IPredictionService
    {
        Task<IPrediction> GetPrediction(IImage image);
        IPrediction CalculateBrickPrediction(IEnumerable<IPrediction> imagePredictions);
        bool IsPredictionAboveMinConfidences(IEnumerable<IImage> brickImages);
    }
}
