using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.DataBase
{
    class Monstruo
    {
        private int id;
        private string name;
        private string desc;
        private string type;

        public Monstruo()
        {
          
        }

        public void setID(int id)
        {
            this.id = id;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setDesc(string desc)
        {
            this.desc = desc;
        }
        public void setType(string type)
        {
            this.type = type;
        }

    }
}
