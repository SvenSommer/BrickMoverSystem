using Xunit;

namespace BrickMoverSystem.Model.Tests
{
    public class PredictionTests {

        [Fact]
        public void CreatePrediction()
        {
            Prediction prediction = new Prediction(1, 0.6,"partNo",0.8);

            Assert.Equal(1, prediction.ColorId);
            Assert.Equal(0.6, prediction.ColorConfidence);
            Assert.Equal("partNo", prediction.PartNo);
            Assert.Equal(0.8, prediction.PartNoConfidence);
        }

    }
}
