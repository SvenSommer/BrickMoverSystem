using System;
using BrickHandler.Model;
using BrickHandler.Model.Contract;

namespace BrickHandler.BucketService
{
    public class BucketService : IBucketService
    {
        public IBucket GetBucketForBrick(string partno, int colorid)
        {
            throw new NotImplementedException();
        }

        public void Push(int bucketId, IBrick brick, double pushTime)
        {
            //TODO: Send command to ValveController to push the brick into the bucket at the given time
            throw new NotImplementedException();
        }
    }
}
