namespace BrickHandler.Model
{
    public class PartNoPrediction : IPartNoPrediction
    {
        public PartNoPrediction(string partNo, double confidence)
        {
            No = partNo;
            Confidence = confidence;
        }

        public string No { get;  }
        public double Confidence { get;  }
    }

    public interface IPartNoPrediction
    {
        string No { get;  }
        double Confidence { get;  }
    }
}