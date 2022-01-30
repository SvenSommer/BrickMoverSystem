namespace BrickMoverSystem.Model
{
    public class PushResult : IPushResult
    {
        public int BrickId { get; set; }
        public bool IsPushed { get; set; }
    }

    public interface IPushResult
    {
        public int BrickId { get; set; }
        public bool IsPushed { get; set; }
}

}
