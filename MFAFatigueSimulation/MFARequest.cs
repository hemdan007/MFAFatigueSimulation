using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFAFatigueSimulation
{
    internal class MFARequest
    {
        public int RequestId { get; set; }

        public bool IsLegitimate { get; set; }

        public bool IsApproved { get; set; }

        public int MatchingNumber { get; set; }
    }
}