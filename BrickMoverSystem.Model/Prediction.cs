namespace BrickMoverSystem.Model
{
    public class Prediction : IPrediction
    {
        public Prediction(int colorId, double colorConfidence, string partNo, double partNoConfidence)
        {
            ColorId = colorId;
            ColorConfidence = colorConfidence;
            PartNo = partNo;
            PartNoConfidence = partNoConfidence;
        }

        public int ColorId { get; set; }
        public double ColorConfidence { get; set; }
        public string PartNo { get; set; }
        public double PartNoConfidence { get; set; }
        public bool isValid()
        {
            return ColorId > 0 && !string.IsNullOrEmpty(PartNo);
        }
    }


    public interface IPrediction
    {
        public int ColorId { get; set; }
        public double ColorConfidence { get; set; }
        public string PartNo { get; set; }
        public double PartNoConfidence { get; set; }
        bool isValid();
    }
}