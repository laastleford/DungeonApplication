using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //new classes default to internal.  We must make it public in order to access it outside the project.
    public class Player : Character//Now a child of character
    {

        //fields
        //only need to create fields for the ones we will have business rules on- life

        //private int _life;
         

        //properties
        //Automatic properties are a shortcut syntax that allows you to create a shortened version of a public property.
        //They have an open getter and setter, which means the "guard" is asleep.
        //These automatically create default fields for us at runtime.

        //public string Name { get; set; }
        //public int HitChance { get; set; }
        //public int MaxLife { get; set; }
        //public int Block { get; set; }
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        //public int Life
        //{
        //    get { return _life; }
        //    set
        //    {
        //        if (value <= MaxLife)
        //        {//good to go
        //            _life = value;

        //        }//if
        //        else
        //        {
        //            _life = MaxLife;
        //        }//else
        //        //life should not be more than max
        //    }//set
        //}//life property


        //You cannot have business rules with an automatic property
         
        //ctors
        //ONLY make FQCTOR since we do not want anytone to make a blank player.  they must give us all the info.

        public Player(string name, int life, int maxLife, int hitChance, int block, Race characterRace, Weapon equippedWeapon)
        {

            //Mini lab  finish FQCTOR by assigning the values

            Name = name;
            MaxLife = maxLife;
            Life = life;
            HitChance = hitChance;
            Block = block;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
            Type = Type;
            //life depends on maxlife, set maxlife FIRST!

        }//player ctor

        //methods
        public override string ToString()
        {
            string description = "";
            //string description = string.Empty;
            //return base.ToString();
            switch (CharacterRace)
            {
                case Race.Bulbasaur:
                    description = "It is a Grass/Poison type Pokémon with a big flower on its back.";
                    Name = "Bulbasaur";
                    Type = "Grass/Poison";
                    break;
                case Race.Squirtle:
                    description = "Squirtle is a cute turtle Pokémon that uses water as its form of attack.";
                    Name = "Squirtle";
                    Type = "Water";
                    break;
                case Race.Charmander:
                    description = "Charmander is a red Pokémon that has powerful fire abilities. If its fire tip on its tail burns out, it will die.";
                    Name = "Charmander";
                    Type = "Fire";
                    break;
                
                default:
                    description = "Congrats! You're Will Ferrell";
                    break;
            }




            return string.Format("-=-=-= Name: {0} =-=-=-=\nLife: {1} of {2}\nHit Chance: {3} %\nWeapon:\n{4}\nDescription: {5}",
                Name,
                Life,
                MaxLife,
                HitChance,
                EquippedWeapon,
                description);
        }//override tostring()

        //Overriding the CalcDamage() and CalcHitChance() to use the EquippedWeapon's properties
        //MinDamage, MaxDamage

        public override int CalcDamage()
        {
            //return base.CalcDamage();
            //Don't want this... would return 0.
            //Create a Random

            Random rand = new Random();
            //Determin the damage
            
            return rand.Next(EquippedWeapon.MinDmg, EquippedWeapon.MaxDmg + 1);

            
        }

        public override int CalcHitChance()
        {
            //return base.CalcHitChance();
            return HitChance + EquippedWeapon.BonusHitChance;
        }


    }
}
