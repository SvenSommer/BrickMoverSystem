using System;
using System.Collections.Generic;
using BrickHandler.Model;
using BrickHandler.Model.Contract;

namespace BrickHandler.MySqlRepository
{
    public class BrickMySqlRepository : IBrickRepository
    {
        public BrickMySqlRepository(LegoSorterDbConnection con)
        {
            LegoSorterDbConnection connection = con;
            connection.Server = "mysqlserver:3306";
            connection.UserName = "BrickmoverSystem";
            connection.Password = "passwort";
            connection.DatabaseName = "LegoSorterDB";
        }

        public void Save(IBrick brick)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBrick> BricksByBucket(int bucketNumber)
        {
            throw new NotImplementedException();
        }

        public void SavePushResult(IPushResult pushResult)
        {
            throw new NotImplementedException();
        }

        public IBucket GetBucketForBrick(IBrick brick)
        {
            throw new NotImplementedException();
        }

       
    }
}
