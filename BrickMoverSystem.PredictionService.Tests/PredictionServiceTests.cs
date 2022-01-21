using System.Collections.Generic;
using System.Linq;
using BrickMoverSystem.Model;
using BrickMoverSystem.Model.Contract;
using Xunit;

namespace BrickMoverSystem.PredictionService.Tests
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

            bool predictionPossible = _predictionService.IsPredictionPossible(images);

            Assert.False(predictionPossible);
        }

        [Fact]
        public void NoImagePredictions_NoBrickPrediction()
        {
            IEnumerable<IImage> images = GetTestImages(6);

            bool predictionPossible = _predictionService.IsPredictionPossible(images);

            Assert.False(predictionPossible);
        }

        [Fact]
        public void LowImagePrediction_DenyBrickPrediction()
        {
            List<IImage> images = GetTestImages(6).ToList();
            images.First().Prediction = GetTestPrediction(0.7, 0.8);

            bool isValidBrick = _predictionService.IsPredictionPossible(images);

            Assert.False(isValidBrick);
        }

        [Fact]
        public void CalculateBrickPrediction()
        {
            var imagePrediction = new List<IPrediction>();
            imagePrediction.Add(new Prediction(1, 0.8, "badPartPrediction", 0.2));
            imagePrediction.Add(new Prediction(99, 0.7, "badPartPrediction", 0.2));
            imagePrediction.Add(new Prediction(99, 0.6, "badPartPrediction", 0.2));
            imagePrediction.Add(new Prediction(2, 0.6, "goodPartPrediction", 0.82));
            imagePrediction.Add(new Prediction(2, 0.76, "goodPartPrediction", 0.7));
            imagePrediction.Add(new Prediction(2, 0.1, "bestPartPrediction", 0.9));
            
            IPrediction prediction = _predictionService.CalculateBrickPrediction(imagePrediction);
            
            Assert.Equal(1, prediction.ColorId);
            Assert.Equal(0.8, prediction.ColorConfidence);
            Assert.Equal("goodPartPrediction", prediction.PartNo);
            Assert.Equal(0.82, prediction.PartNoConfidence);
        }

        private static IEnumerable<IImage> GetTestImages(int imagesCount)
        {
            List<Image> images = new List<Image>();
            for (int i = 0; i < imagesCount; i++)
            {
                images.Add(new Image(i, "", Position.BottomCenter, Camera.Brio));
            }
            return images;
        }

        private Prediction GetTestPrediction(double colorConfidence, double partNoConfidence)
        {
            return new Prediction(1, colorConfidence, "", partNoConfidence);
        }
    }
}
