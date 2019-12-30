using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Domain
{
    public class SamuraiLiving
    {
        public int LivingId { get; set; }
        public int SamuraiId { get; set; }

        public List<Samurai> Samurais { get; set; }
        public List<SamuraiLivingDetail> SamuraiLivingDetails { get; set; }

    }
}
