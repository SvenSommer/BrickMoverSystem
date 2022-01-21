using System.Collections.Generic;

namespace BrickMoverSystem.Model
{
    public class Brick : IBrick
    {
        public Brick(int id, IEnumerable<IImage> images, double speed, double lastPosition)
        {
            Id = id;
            Images = images;
            Speed = speed;
            LastPosition = lastPosition;
        }

        public void SetPrediction(IPrediction prediction)
        {
            Prediction = prediction;
        }


        public int Id { get; set; }
        public IEnumerable<IImage> Images { get; set; }
        public double Speed { get; set; }
        public double LastPosition { get; set; }
        public IPrediction Prediction { get; set; }
    }

    public interface IBrick
    {
        int Id { get; set; }
        IEnumerable<IImage> Images { get; set; }
        double Speed { get;  set; }
        double LastPosition { get; set; }
        public IPrediction Prediction { get; }
        void SetPrediction(IPrediction prediction);
    }
}
