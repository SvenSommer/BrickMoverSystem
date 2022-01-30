namespace BrickHandler.Model.Contract
{
    public interface IBucketService
    {
        IBucket GetBucketForBrick(string partno, int colorid);
        void Push(int bucketId, IBrick brick, double pushTime);
    }
}
