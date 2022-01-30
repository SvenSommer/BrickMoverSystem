using System;
using System.Collections.Generic;
using System.Text;

namespace BrickHandler.Model
{
    public class LastPosition : ILastPosition
    {
        public LastPosition(int x, int y, DateTime dateTime)
        {
            X = x;
            Y = y;
            DateTime = dateTime;
        }

        public int X { get;  }
        public int Y { get;  }
        public DateTime DateTime { get; }
    }

    public interface ILastPosition
    {
        public int X { get; }
        public int Y { get;  }
        public DateTime DateTime { get;  }
    }
}
