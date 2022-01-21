namespace BrickMoverSystem.Model
{
    public class PushResultMessage : IPushResultMessage
    {
        public int BrickId { get; set; }
        public bool IsPushed { get; set; }
    }

    public interface IPushResultMessage
    {
        public int BrickId { get; set; }
        public bool IsPushed { get; set; }
}

}
