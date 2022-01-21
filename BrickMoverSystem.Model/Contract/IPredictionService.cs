using System.Collections.Generic;

namespace BrickMoverSystem.Model.Contract
{
    public interface IPredictionService
    {
        IPrediction GetPrediction(IImage image);
        IPrediction CalculateBrickPrediction(IEnumerable<IPrediction> imagePredictions);
        bool IsPredictionPossible(IEnumerable<IImage> brickImages);
    }
}
