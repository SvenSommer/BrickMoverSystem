using System.Collections.Generic;
using System.Linq;
using BrickHandler.Model;
using BrickHandler.Model.Contract;
using Xunit;

namespace BrickHandler.PredictionService.Tests
{
    public class PredictionServiceTests
    {
        private readonly IPredictionService _predictionService;
        public PredictionServiceTests()
        {
            _predictionService = new PredictionService(0.8, 0.9);
        }

        [Fact]
        public void NoImages_NoBrickPrediction()
        {
            IEnumerable<IImage> images = GetTestImages(0);

            bool predictionPossible = _predictionService.IsPredictionAboveMinConfidences(images);

            Assert.False(predictionPossible);
        }

        [Fact]
        public void NoImagePredictions_NoBrickPrediction()
        {
            IEnumerable<IImage> images = GetTestImages(6);

            bool predictionPossible = _predictionService.IsPredictionAboveMinConfidences(images);

            Assert.False(predictionPossible);
        }

        [Fact]
        public void LowImagePrediction_DenyBrickPrediction()
        {
            List<IImage> images = GetTestImages(6).ToList();
            images.First().Prediction = GetTestPrediction(0.7, 0.8);

            bool isValidBrick = _predictionService.IsPredictionAboveMinConfidences(images);

            Assert.False(isValidBrick);
        }

        [Fact]
        public void CalculateBrickPrediction()
        {
            List<IPrediction> imagePrediction = new List<IPrediction>();
            imagePrediction.Add(new Prediction(new ColorPrediction(1, 0.8), new PartNoPrediction("badPartPrediction", 0.2)));
            imagePrediction.Add(new Prediction(new ColorPrediction(99, 0.7), new PartNoPrediction("badPartPrediction", 0.2)));
            imagePrediction.Add(new Prediction(new ColorPrediction(99, 0.6), new PartNoPrediction("badPartPrediction", 0.2)));
            imagePrediction.Add(new Prediction(new ColorPrediction(2, 0.6), new PartNoPrediction("goodPartPrediction", 0.82)));
            imagePrediction.Add(new Prediction(new ColorPrediction(2, 0.76), new PartNoPrediction("goodPartPrediction", 0.7)));
            imagePrediction.Add(new Prediction(new ColorPrediction(2, 0.1), new PartNoPrediction("bestPartPrediction", 0.9)));
            
            IPrediction prediction = _predictionService.CalculateBrickPrediction(imagePrediction);
            
            Assert.Equal(1, prediction.Color.Id);
            Assert.Equal(0.8, prediction.Color.Confidence);
            Assert.Equal("goodPartPrediction", prediction.Part.No);
            Assert.Equal(0.82, prediction.Part.Confidence);
        }

        private static IEnumerable<IImage> GetTestImages(int imagesCount)
        {
            List<Image> images = new List<Image>();
            for (int i = 0; i < imagesCount; i++)
            {
                images.Add(new Image(i, "", CameraPosition.BottomCenter, Camera.Brio));
            }
            return images;
        }

        private Prediction GetTestPrediction(double colorConfidence, double partNoConfidence)
        {
            return new Prediction(new ColorPrediction(1, colorConfidence), new PartNoPrediction("", partNoConfidence));
        }
    }
}
