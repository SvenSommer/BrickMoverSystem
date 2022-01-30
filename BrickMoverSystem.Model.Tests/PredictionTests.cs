using Xunit;

namespace BrickHandler.Model.Tests
{
    public class PredictionTests {

        [Fact]
        public void CreatePrediction()
        {
            Prediction prediction = new Prediction(new ColorPrediction(1, 0.6),new PartNoPrediction("partNo",0.8));

            Assert.Equal(1, prediction.Color.Id);
            Assert.Equal(0.6, prediction.Color.Confidence);
            Assert.Equal("partNo", prediction.Part.No);
            Assert.Equal(0.8, prediction.Part.Confidence);
        }

    }
}
