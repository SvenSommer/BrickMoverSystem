using System;
using System.Collections.Generic;
using Xunit;

namespace BrickHandler.Model.Tests
{
    public class BrickTests
    {
        [Fact]
        public void CreateBrick()
        {
            IEnumerable<IImagePrediction> imagePrediction = GetImagePrediction(1);
            ILastPosition lastPosition = GetTestLastPosition();
            Brick brick = new Brick(1, GetTestPrediction(0.5, 0.6), imagePrediction, lastPosition,3);

            Assert.Equal(1, brick.Id);
            Assert.Single(brick.ImagePredictions);
        }

        private static IPrediction GetTestPrediction(double colorConfidence, double partNoConfidence)
        {
            return new Prediction(new ColorPrediction(1, colorConfidence), new PartNoPrediction("", partNoConfidence));
        }

        private static IEnumerable<IImagePrediction> GetImagePrediction(int imagesCount)
        {
            List<IImagePrediction> images = new List<IImagePrediction>();
            for (int i = 0; i < imagesCount; i++)
            {
                images.Add(new ImagePrediction(i, GetTestPrediction(0.6, 0.8)));
            }
            return images;
        }

        private ILastPosition GetTestLastPosition()
        {
            return new LastPosition(3,5,new DateTime(2022,01,30));
        }


    }
}
