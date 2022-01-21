using System;
using System.Collections.Generic;
using System.Linq;
using BrickMoverSystem.Model;
using BrickMoverSystem.Model.Contract;

namespace BrickMoverSystem.PredictionService
{
    public class PredictionService : IPredictionService
    {
        private static double _minPartNoConfidence = 0.8;
        private static double _minColorConfidence = 0.9;


        public PredictionService(double minPartNoConfidence, double minColorConfidence)
        {
            _minPartNoConfidence = minPartNoConfidence;
            _minColorConfidence = minColorConfidence;
        }

        public IPrediction GetPrediction(IImage image)
        {
            //TODO: Load the pretrained Model do get a prediction for colorId and partNo
            throw new NotImplementedException();
        }

        public IPrediction CalculateBrickPrediction(IEnumerable<IPrediction> imagePredictions)
        {
            List<IPrediction> predictionList = imagePredictions.ToList();

            // Get colorId with the highest rating
            double maxColorConfidence = predictionList.Max(s => s.ColorConfidence);
            IPrediction predictedColor = predictionList.First(x => x.ColorConfidence == maxColorConfidence);

            //Get the max repeated partnumber from the valid predictions
            List<IPrediction> validPartNoPredictions = predictionList.Where(s => s.PartNoConfidence > _minPartNoConfidence).ToList();
            IPrediction predictedPartno = validPartNoPredictions.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .First().Key;

            return new Prediction(predictedColor.ColorId, predictedColor.ColorConfidence, predictedPartno.PartNo,
                predictedPartno.PartNoConfidence);
        }

        public bool IsPredictionPossible(IEnumerable<IImage> images)
        {
           return images.Any(image => image.Prediction != null && image.Prediction.PartNoConfidence >= _minPartNoConfidence && image.Prediction.ColorConfidence >= _minColorConfidence);
        }

        
    }
}
