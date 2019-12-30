using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; }
        //public int BattleId { get; set; }
        public List<SamuraiBattle> SamuraiBattles { get; set; }

        public Samurai()
        {
            Quotes=new List<Quote>();
        }
    }
}
