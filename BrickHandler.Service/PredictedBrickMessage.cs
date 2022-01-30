using System.Collections.Generic;
using BrickHandler.Messages.Messages;
using BrickHandler.Model;

namespace BrickHandler.Service
{
    public class PredictedBrickMessage : IMessage
    {
        public int BrickId { get; set; }
        public IPrediction BrickPrediction { get; set; }
        public IEnumerable<IImagePrediction> ImagePredictions { get; set; }
        public int Speed { get; set; }
        public LastPosition LastPosition { get; set; }
    }
}