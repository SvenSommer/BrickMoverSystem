using System;
using System.Collections.Generic;
using System.Text;

namespace BrickHandler.Model
{
    public class ImagePrediction : IImagePrediction
    {
        public ImagePrediction(int id, IPrediction prediction)
        {
            Id = id;
            Prediction = prediction;
        }

        public int Id { get; }
        public IPrediction Prediction { get;  }
    }

    public interface IImagePrediction
    {
        int Id { get;  }
        IPrediction Prediction { get;  }
    }
}
