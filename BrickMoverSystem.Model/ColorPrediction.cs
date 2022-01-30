namespace BrickHandler.Model
{
    public class ColorPrediction : IColorPrediction
    {
        public ColorPrediction(int colorId, double confidence)
        {
            Id = colorId;
            Confidence = confidence;
        }

        public int Id { get; }
        public double Confidence { get; }
    }

    public interface IColorPrediction
    {
        int Id { get;  }
        double Confidence { get; }
    }
}