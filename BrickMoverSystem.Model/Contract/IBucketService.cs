namespace BrickMoverSystem.Model.Contract
{
    public interface IBucketService
    {
        IBucket GetBucketForBrick(IBrick brick);
        void Push(IBucket bucket, IBrick brick, double pushTime);
    }
}
