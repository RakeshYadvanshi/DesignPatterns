using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Domain
{
    public class SamuraiLivingDetail
    {
        public int LivingId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string pinCode { get; set; }
    }
}
