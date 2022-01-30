namespace BrickMoverSystem.Model.Contract
{
    public interface IBucketService
    {
        IBucket GetBucketForBrick(IBrick brick);
        void Push(int bucketId, IBrick brick, double pushTime);
    }
}
