using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Domain
{
    public class Quote
    {
        public Int32 Id { get; set; }
        public string Text { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }

    }
}
