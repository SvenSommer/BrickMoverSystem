namespace BrickHandler.Model
{
    public class Run : IRun
    {
        public int RunId { get; set; }
    }

    public interface IRun
    {
        int RunId { get; set; }
    }
}
