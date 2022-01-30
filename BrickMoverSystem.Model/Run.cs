using System;
using System.Collections.Generic;
using System.Text;

namespace BrickMoverSystem.Model
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
