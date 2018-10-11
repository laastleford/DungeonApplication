using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //fields
        private int _minDmg;
        //properties
        //auto properties first, the ones that don't have business rules

        public int MaxDmg { get; set; }
        public string Description { get; set; }
        public bool IsGrassType { get; set; }
        public bool IsGroundType{ get; set; }
        public bool IsWaterType { get; set; }
        public bool IsPoisonType { get; set; }
        public bool IsElectricType { get; set; }
        public int MinDmg
        {
            get { return _minDmg; }
            set
            {
                if (value <= MaxDmg && value > 1)
                {
                    _minDmg = value;

                }//if
                else
                {
                    _minDmg = 1;
                }//else

                //can't be more than max Dmg and cannot be less than 1
            }//set

          
        }
        //ctors

        public Monster()
        {

        }//default

        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDmg, int maxDmg, string description,
            string type)
        {
            //No FQTOR in the parent (character), so we have to handle all of the property = parameter assignments here.
            //set MaxLife and MaxDmg first, since other properties depend on them.

            MaxLife = maxLife;
            MaxDmg = maxDmg;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDmg = minDmg;
            Description = description;
            Type = Type;
            
        }

        //methods
        public override string ToString()
        {
            //return base.ToString(); 
            return string.Format("\n ***** Opposing Pokemon *****\n"
                + "{0}\nLife: {1} of {2}\nDamage: {3} to {4}\n"
                + "Block: {5}\nDescription:\n{6}\n",
                Name,
                Life,
                MaxLife,
                MinDmg,
                MaxDmg,
                Block,
                Description);
        }//tostring() override

        //We are overrideiing the CalcDmg() to use the properties of Mindmg and MaxDmg
        public override int CalcDamage()
        {
            //return base.CalcDamage(); would return 0
            return new Random().Next(MinDmg, MaxDmg + 1);

        }

        //public override int CalcBlock()
        //{//typically when dealing with a method that has a return type, you want to create a variable of the datatype
        // //that needs to be returned with some default value.  Next, you want to write the return line, and finally
        // //write the logic/functionality/code in between.


        //    //if (IsSmelly)
        //    //{
        //    //    calculatedBlock += calculatedBlock /2;
        //    //}//if

           



        //    return Block;

        //}//calculatedBlock() override


    }//class
}
