using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //fields
        private int _minDmg;
        private int _maxDmg;
        private string _name;
        private int _bonusHitChance;
        //private bool _isTwoHanded;



        //properties
        //propterties with business rules go last
        public int MaxDmg
        {
            get { return _maxDmg; }
            set { _maxDmg = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }

        //public bool IsTwoHanded
        //{
        //    get { return _isTwoHanded; }
        //    set { _isTwoHanded = value; }
        //}

        public int MinDmg
        {
            get { return _minDmg; }
            set
            {
                //can't be more than the Maxdmg and cannot be less than 1
                if (value > 0 && value <= MaxDmg)
                {
                    //let it pass
                    _minDmg = value;

                }//if
                else
                {
                    //tried to set the value outside our range
                    _minDmg = 1;
                }//else


            }//set

        }//mindmg

        //ctors

        public Weapon() { }//default

        public Weapon(int minDmg, int maxDmg, int bonusHitChance, string name)//FQCTOR setting a parameter for every property
        {
            //if you have ANY properties that have business rules that based on any OTHER properties, set the OTHER
            //properties first (maxdmg)

            MaxDmg = maxDmg;
            MinDmg = minDmg;
            BonusHitChance = bonusHitChance;
            Name = name;
            //IsTwoHanded = isTwoHanded;

        }
        //methods

        public override string ToString()
        {
            //return base.ToString();
            return string.Format("{0}\t{1} to {2} Damage\nBonus Hit: {3}%",
                Name,
                MinDmg,
                MaxDmg,
                BonusHitChance);

        }//tostring() override
    }//class
}//namespace
