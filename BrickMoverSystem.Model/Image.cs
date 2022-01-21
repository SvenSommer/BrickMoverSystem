namespace BrickMoverSystem.Model
{
    public class Image : IImage
    {
        public Image(int id, string path, Position position, Camera camera)
        {
            Id = id;
            ImagePath = path;
            Position = position;
            Camera = camera;
        }

        public void SetPrediction(IPrediction prediction)
        {
            Prediction = prediction;
        }

        public int Id { get;  set; }
        public string ImagePath { get; set; }
        public Position Position { get; set; }
        public Camera Camera { get; set; }
        public IPrediction Prediction { get; set; }
    }

    public interface IImage
    {
         int Id { get;  set; }
         string ImagePath { get; set; }
         Position Position { get; set; }
         Camera Camera { get; set; }
         IPrediction Prediction { get;  set; }
         void SetPrediction(IPrediction prediction);
    }
}
