namespace BrickHandler.Model
{
    public class Bucket : IBucket
    {
        public Bucket(int id, double pusherDistance, string bucketIp, string scaleIp)
        {
            Id = id;
            Distance = pusherDistance;
            BucketIp = bucketIp;
            ScaleIp = scaleIp;
        }

        public int Id { get; set; }
        public double Distance { get; set; }
        public string BucketIp { get; set; }
        public string ScaleIp { get; set; }
    }
    public interface IBucket
    {
        int Id { get; set; }
        double Distance { get; set; }
        string BucketIp { get; set; }
        string ScaleIp { get; set; }
    }

   
}
