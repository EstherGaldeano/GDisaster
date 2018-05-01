using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.DataBase
{
    class Monstruo
    {
        // ATRIBUTOS
        private int id;
        private Random rnd;
        private string name;
        private string desc;
        private string type;
        private int hp;
        private char locked;

        // CONSTRUCTOR
        public Monstruo()
        {

        }

        // SETTERS
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
        public void setVida()
        {
            this.hp = getVidaMax(this.type);
        }
        public void setType(string type)
        {
            this.type = type;
        }
        public void setLocked(char locked)
        {
            this.locked = locked;
        }
        
        // FUNCION PARA GENERAR LA VIDA ALEATORIAMENTE
        private int getVidaMax(string type)
        {
            int vida = 10;
            if (type.Equals("NO"))
            {
                vida = rnd.Next(10, 25);
            }else if (type.Equals("RA"))
            {
                vida = rnd.Next(25, 50);
            }else if (type.Equals("BO"))
            {
                vida = rnd.Next(100, 250);
            }else if (type.Equals("UN"))
            {
                vida = 400;
            }

            return vida;
        }
    }
}
