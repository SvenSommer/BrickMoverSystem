using System;
using System.Collections.Generic;

namespace BrickHandler.Model
{
    public class PushTimeCalculator : IPushTimeCalculator
    {
        public double CalculatePushTime(double bucketDistance, ILastPosition brickLastPosition, double speed)
        {
            long currentUnixTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();

            double pushTime = (currentUnixTime + (bucketDistance - brickLastPosition.Y) / speed) * 1000;
            return pushTime;
        }
    }

    public interface IPushTimeCalculator
    {
        double CalculatePushTime(double bucketdistance, ILastPosition brickLastPosition, double speed);
    }
}
