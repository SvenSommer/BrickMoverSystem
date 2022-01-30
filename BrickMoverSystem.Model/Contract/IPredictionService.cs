using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrickMoverSystem.Model.Contract
{
    public interface IPredictionService
    {
        Task<IPrediction> GetPrediction(IImage image);
        IPrediction CalculateBrickPrediction(IEnumerable<IPrediction> imagePredictions);
        bool IsPredictionPossible(IEnumerable<IImage> brickImages);
    }
}
