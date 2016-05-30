using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Ui
    {
        public int id;
        public string css;

        public Ui(int id, string css)
        {
            this.id = id;
            this.css = css;
        }
    }
}
