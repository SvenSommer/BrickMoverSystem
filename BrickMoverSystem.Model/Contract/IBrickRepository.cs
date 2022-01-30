using System.Collections.Generic;

namespace BrickHandler.Model.Contract
{
    public interface IBrickRepository
    {
        void Save(IBrick brick);
        IEnumerable<IBrick> BricksByBucket(int bucketNumber);

        void SavePushResult(IPushResult pushResult);
    }
}
