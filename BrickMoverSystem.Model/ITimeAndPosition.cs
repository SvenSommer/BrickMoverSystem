using System;
using System.Drawing;

namespace BrickHandler.Model
{
    public class TimeAndPosition : ITimeAndPosition{
        public TimeAndPosition(DateTime datetime, Point position)
        {
            DateTime = datetime;
            Position = position;
        }
        public DateTime DateTime { get; }
        public Point Position { get; }
    }
    

    public interface ITimeAndPosition
    {
        public DateTime DateTime { get;  }
        public Point Position { get;  }

    }
}