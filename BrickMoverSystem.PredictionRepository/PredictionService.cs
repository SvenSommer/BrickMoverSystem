using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrickHandler.Model;
using BrickHandler.Model.Contract;

namespace BrickHandler.PredictionService
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

        public Task<IPrediction> GetPrediction(IImage image)
        {
            //TODO: Load the pretrained Model do get a prediction for colorId and partNo
            throw new NotImplementedException();
        }

        public IPrediction CalculateBrickPrediction(IEnumerable<IPrediction> imagePredictions)
        {
            List<IPrediction> predictionList = imagePredictions.ToList();

            IColorPrediction predictedColor = GetColorIdWithHighestRating(predictionList);
            IPartNoPrediction predictedPartno = GetMaxRepeatedPartnumberFromValidPredictions(predictionList);

            return new Prediction(predictedColor, predictedPartno);
        }

        private static IPartNoPrediction GetMaxRepeatedPartnumberFromValidPredictions(IList<IPrediction> predictionList)
        {
           List<IPrediction> validPartNoPredictions =
                predictionList.Where(s => s.Part.Confidence > _minPartNoConfidence).ToList();
            IPrediction predictedPartno = validPartNoPredictions.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .First().Key;
            return predictedPartno.Part;
        }

        private static IColorPrediction GetColorIdWithHighestRating(IList<IPrediction> predictions)
        {
            double maxColorConfidence = predictions.Max(s => s.Color.Confidence);
            IColorPrediction predictedColor = predictions.First(x => x.Color.Confidence.Equals(maxColorConfidence)).Color;
            return predictedColor;
        }

        public bool IsPredictionAboveMinConfidences(IEnumerable<IImage> images)
        {
           return images.Any(image => image.Prediction != null && image.Prediction.Part.Confidence >= _minPartNoConfidence && image.Prediction.Color.Confidence >= _minColorConfidence);
        }

        
    }
}
