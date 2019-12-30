using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Domain
{
    public class Battle
    {
        public int Id { get; set; }
        public string BattleName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public List<Samurai> Samurais { get; set; }
        public List<SamuraiBattle> SamuraiBattles { get; set; }
    }
}
