using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BrickMoverSystem.Model.Tests
{
    public class BrickTests
    {
        [Fact]
        public void CreateBrick()
        {
            IEnumerable<IImage> images = GetTestImages(1);
            Brick brick = new Brick(1, images, 0.5, 0.6);

            Assert.Equal(1, brick.Id);
            Assert.Single(brick.Images);
            Assert.Equal(0.5, brick.Speed);
            Assert.Equal(0.6, brick.LastPosition);
        }

    
        
        [Fact]
        public void SetBrickPrediction()
        {
            Brick brick = GetTestBrick(6);
            brick.Images.First().Prediction = GetTestPrediction(0.9, 0.9);

            brick.SetBrickPrediction(new Prediction(1, 0.9, "Partno", 0.8));
            
            Assert.Equal(1, (int)brick.Prediction.ColorId);
            Assert.Equal("Partno", (string)brick.Prediction.PartNo);
            Assert.Equal(0.9, brick.Prediction.ColorConfidence);
            Assert.Equal(0.8, brick.Prediction.PartNoConfidence);
        }

        private Brick GetTestBrick(int imagesCount)
        {
            IEnumerable<IImage> images = GetTestImages(imagesCount);
            return new Brick(1, images, 0, 0);
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
            return new Prediction(1, colorConfidence, "", partNoConfidence);
        }


    }
}
