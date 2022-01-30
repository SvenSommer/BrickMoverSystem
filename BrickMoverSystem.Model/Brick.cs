using System;
using System.Collections.Generic;
using System.Drawing;

namespace BrickMoverSystem.Model
{
    public class Brick : IBrick
    {
        public Brick(int id, IEnumerable<IImage> images, IEnumerable<ITimeAndPosition> sightings, double lastPosition)
        {
            Id = id;
            Images = images;
            Sightings = sightings;
        }

        public void SetBrickPrediction(IPrediction prediction)
        {
            Prediction = prediction;
        }


        public int Id { get; set; }
        public IEnumerable<IImage> Images { get; set; }
        public double Speed { get; set; }
        public IEnumerable<ITimeAndPosition> Sightings { get; set; }
        public IPrediction Prediction { get; set; }
    }

    public interface ITimeAndPosition
    {
        public DateTime DateTime { get; set; }
        public Point Position { get; set; }

    }


    public interface IBrick
    {
        int Id { get; set; }
        IEnumerable<IImage> Images { get; set; }
        double Speed { get;  set; }
        IEnumerable<ITimeAndPosition> Sightings { get; set; }
        public IPrediction Prediction { get; }
        void SetBrickPrediction(IPrediction prediction);
    }
}
