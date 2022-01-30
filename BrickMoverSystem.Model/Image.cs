namespace BrickMoverSystem.Model
{
    public class Image : IImage
    {
        public Image(int id, string path, CameraPosition cameraPosition, Camera camera)
        {
            Id = id;
            ImagePath = path;
            CameraPosition = cameraPosition;
            Camera = camera;
        }

        public void SetImagePrediction(IPrediction prediction)
        {
            Prediction = prediction;
        }

        public int Id { get;  set; }
        public string ImagePath { get; set; }
        public CameraPosition CameraPosition { get; set; }
        public Camera Camera { get; set; }
        public IPrediction Prediction { get; set; }
    }

    public interface IImage
    {
         int Id { get;  set; }
         string ImagePath { get; set; }
         CameraPosition CameraPosition { get; set; }
         Camera Camera { get; set; }
         IPrediction Prediction { get;  set; }
         void SetImagePrediction(IPrediction prediction);
    }
}
