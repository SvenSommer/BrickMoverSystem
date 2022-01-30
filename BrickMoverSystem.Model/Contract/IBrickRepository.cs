using System.Collections.Generic;

namespace BrickMoverSystem.Model.Contract
{
    public interface IBrickRepository
    {
        void Save(IBrick brick);
        IEnumerable<IBrick> BricksByBucket(int bucketNumber);

        void SavePushResult(IPushResult pushResult);
    }
}
