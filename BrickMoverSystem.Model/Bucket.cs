namespace BrickMoverSystem.Model
{
    public class Bucket : IBucket
    {
        public Bucket(int number, double pusherDistance, string bucketIp, string scaleIp)
        {
            Number = number;
            PusherDistance = pusherDistance;
            BucketIp = bucketIp;
            ScaleIp = scaleIp;
        }

        public int Number { get; set; }
        public double PusherDistance { get; set; }
        public string BucketIp { get; set; }
        public string ScaleIp { get; set; }
    }
    public interface IBucket
    {
        int Number { get; set; }
        double PusherDistance { get; set; }
        string BucketIp { get; set; }
        string ScaleIp { get; set; }
    }

   
}
