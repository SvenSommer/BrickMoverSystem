namespace BrickHandler.Model
{
    public class Prediction : IPrediction
    {
        public Prediction(IColorPrediction colorPrediction, IPartNoPrediction partNoPrediction)
        {
            Color = colorPrediction;
            Part = partNoPrediction;
        }

        public IColorPrediction Color { get; set; }
        public IPartNoPrediction Part { get; set; }

        public bool IsValid()
        {
            return Color.Id > 0 && !string.IsNullOrEmpty(Part.No);
        }
    }


    public interface IPrediction
    {
        public IColorPrediction Color { get; set; }
        public IPartNoPrediction Part { get; set; }
        bool IsValid();
    }
}