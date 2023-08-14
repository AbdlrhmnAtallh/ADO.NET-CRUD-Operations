using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO2
{
    internal class STUDENT2
    {
        public int ID { get; set; }
        public string FNAME { get; set; }

        public override string ToString()
        {
            return $"{ID} , , {FNAME} . . .";
        }
    }
}
