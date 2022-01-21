using System;

namespace BrickMoverSystem.Model
{
    public class PushTimeCalculator : IPushTimeCalculator
    {
        public double CalculatePushTime(IBrick brick, IBucket bucket)
        {
            var currentUnixTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            double pushTime =  (currentUnixTime + (bucket.PusherDistance - brick.LastPosition) / brick.Speed) * 1000;
            return pushTime;
        }
    }

    public interface IPushTimeCalculator
    {
        double CalculatePushTime(IBrick brick, IBucket bucket);
    }
}
