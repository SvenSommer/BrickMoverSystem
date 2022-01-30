using System;
using System.Collections.Generic;

namespace BrickHandler.Model
{
    public class PushTimeCalculator : IPushTimeCalculator
    {
        public double CalculatePushTime(IEnumerable<ITimeAndPosition> sightings, double bucketDistance)
        {
            long currentUnixTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            double speed = CalculateSpeed(sightings);
            double lastPostionY = GetLastPosition(sightings);
                double pushTime =  (currentUnixTime + (bucketDistance - lastPostionY) / speed) * 1000;
            return pushTime;
        }

        private double GetLastPosition(IEnumerable<ITimeAndPosition> sightings)
        {
            throw new NotImplementedException();
        }

        private double CalculateSpeed(IEnumerable<ITimeAndPosition> sightings)
        {
            throw new NotImplementedException();
        }

      
    }

    public interface IPushTimeCalculator
    {
        double CalculatePushTime(IEnumerable<ITimeAndPosition> sightings, double bucketDistance);
    }
}
