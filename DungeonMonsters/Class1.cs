using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMonsters
{
    public class Onix : DungeonLibrary.Monster
    {
        //filed

        //properties
        //public bool IsSmelly { get; set; }
        //ctors

        //public Onix(string name, int life, int maxLife, int hitChance, int block, int minDmg, int maxDmg, string description)
        //    : base(name, life, maxLife, hitChance, block, minDmg, maxDmg, description);
        ////{
        //    IsSmelly = isSmelly;
        //}
        //set some values for a basic Goblin in the default ctor
        public Onix()
        {
            //SET MAX values first!!!
            MaxLife = 6;
            MaxDmg = 3;
            Name = "Onix";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDmg = 1;
            Description = "Rock snake";
            Type = "Ground";


        }
        public class Starmie : DungeonLibrary.Monster
        {
            public Starmie()
            {
                //SET MAX values first!!!
                MaxLife = 6;
                MaxDmg = 3;
                Name = "Starmie";
                Life = 6;
                HitChance = 20;
                Block = 20;
                MinDmg = 1;
                Description = "Water-based star";
                Type = "Water";


            }
        }

        public class Raichu : DungeonLibrary.Monster
        {
            public Raichu()
            {
                //SET MAX values first!!!
                MaxLife = 6;
                MaxDmg = 3;
                Name = "Raichu";
                Life = 6;
                HitChance = 20;
                Block = 20;
                MinDmg = 1;
                Description = "Electric-type";
                Type = "Electric";


            }
        }

        public class Victreebel : DungeonLibrary.Monster
        {
            public Victreebel()
            {
                //SET MAX values first!!!
                MaxLife = 6;
                MaxDmg = 3;
                Name = "Victreebel";
                Life = 6;
                HitChance = 20;
                Block = 20;
                MinDmg = 1;
                Description = "Grass-type";
                Type = "Grass";



            }
        }

        public class Koffing : DungeonLibrary.Monster
        {
            public Koffing()
            {
                //SET MAX values first!!!
                MaxLife = 6;
                MaxDmg = 3;
                Name = "Koffing";
                Life = 6;
                HitChance = 20;
                Block = 20;
                MinDmg = 1;
                Description = "Poison-type";
                Type = "Poison";
            }
        }
        //methods
        public override string ToString()
        {
            return base.ToString();


        }//tostring()

        //override the Block to say that if they ARE smelly, they get a bonus 50% chance to their Block value

    }//class
}//namespace
