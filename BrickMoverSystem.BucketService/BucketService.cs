using System;
using BrickHandler.Model;
using BrickHandler.Model.Contract;

namespace BrickHandler.BucketService
{
    public class BucketService : IBucketService
    {
        public IBucket GetBucketForBrick(IBrick brick)
        {
            //TODO: Request the bucket the brick needs to pushed
            string partno = brick.Prediction.Part.No;
            int colorId = brick.Prediction.Color.Id;
            throw new NotImplementedException();
        }

        public void Push(int bucketId, IBrick brick, double pushTime)
        {
            //TODO: Send command to ValveController to push the brick into the bucket at the given time
            throw new NotImplementedException();
        }
    }
}
