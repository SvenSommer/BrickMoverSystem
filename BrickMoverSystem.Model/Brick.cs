using System.Collections.Generic;

namespace BrickHandler.Model
{
    public class Brick : IBrick
    {
        public Brick(int id, IPrediction brickPrediction, IEnumerable<IImagePrediction> imagePredictions,
            ILastPosition lastPosition, double speed)
        {
            Id = id;
            BrickPrediction = brickPrediction;
            ImagePredictions = imagePredictions;
            LastPosition = lastPosition;
            Speed = speed;
        }

        public int Id { get;  }
        public IPrediction BrickPrediction { get; }
        public IEnumerable<IImagePrediction> ImagePredictions { get; }
        public ILastPosition LastPosition { get; }
        public double Speed { get; }
        public IBucket Bucket { get; internal set; }
        public void SetBucket(IBucket bucket)
        {
            Bucket = bucket;
        }
    }
    
    public interface IBrick
    {
        int Id { get;  }
        public IPrediction BrickPrediction { get; }
        IEnumerable<IImagePrediction> ImagePredictions { get;  }
        ILastPosition LastPosition { get;  }
        double Speed { get; }
        void SetBucket(IBucket bucket);
        public IBucket Bucket { get;  }
}
}
