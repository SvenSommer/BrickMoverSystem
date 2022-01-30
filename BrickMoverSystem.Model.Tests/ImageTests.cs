using Xunit;

namespace BrickMoverSystem.Model.Tests
{
    public class ImageTests
    {
        [Fact]
        public void CreateImage()
        {
            Image image = new Image(1, $"//192.186.110.1/pathToImage.png", CameraPosition.BottomCenter, Camera.Brio);

            Assert.Equal(1, image.Id);
            Assert.Equal("//192.186.110.1/pathToImage.png", image.ImagePath);
            Assert.Equal(CameraPosition.BottomCenter, image.CameraPosition);
            Assert.Equal(Camera.Brio, image.Camera);
        }

        [Fact]
        public void SetPrediction()
        {
            Image image = GetTestImage(2, "3020a", 0.6, 0.8);

            Assert.Equal(2, image.Prediction.ColorId);
            Assert.Equal(0.6,image.Prediction.ColorConfidence);
            Assert.Equal("3020a", image.Prediction.PartNo);
            Assert.Equal(0.8, image.Prediction.PartNoConfidence);
        }

        private Image GetTestImage(int colorId, string partNo, double colorConfidence, double partConfidence)
        {
            Image image = new Image(1, "", CameraPosition.BottomCenter, Camera.Brio);
            image.SetImagePrediction(new Prediction(colorId, colorConfidence, partNo, partConfidence));
            return image;
        }

    }
}
