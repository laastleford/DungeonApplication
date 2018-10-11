using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //The abstract modifier indicates that the thing being modified has an incomplete implementation.
    //The abstract modifier can be used with classes, methods, and properties.  Use the abstract modifier
    //in a class declaration to indicate that the class is intended to only be a base (parent) class of other classes.
    public abstract class Character
    {
        //we will bring all of the fields/properties between player and monster, then comment them out in Player.
        //This will allow us to use inheritance and optimize our code reusability.  
        //(This process is commonly referred ot as "refactoring")

        //fields
        private int _life;
        //properties
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public string Type { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {//good to go
                    _life = value;

                }//if
                else
                {
                    _life = MaxLife;
                }//else
                //life should not be more than max
            }//set
        }//life property
      
        //ctors
        //Since we don't inherit constructors and we've already done a lot of work defining the Player FQCTOR, we will
        //NOT create any here. We still get the free, default, parameterless one, but we will be unable to use it since 
        //this
        //class is abstract.

            
        //methods
        //No need to override the ToString().  We will never create a Character object, it will ALWAYS be a Player or 
        //a Monster.

        //Below are methods that we want to be inherited by player and monster, so we will default versions of each
        //method here that the child classes will use if they do NOT override it.

        public int CalcBlock(Character attacker, Character defender)
        {
            //to be able to override this in a child class, make it virtual.
            //this basic version jsut return Block.  However this will give us the option to do something different in
            //child classes.
            int calculatedBlock = Block;
            if (attacker.Name == "Bulbasaur")
            {
                //reduced block(strong against) ground, rock, grass, water
                //weak against poison

                if (defender.Name == "Onix")
                {
                    calculatedBlock -= calculatedBlock / 4;
                }
                if(defender.Name == "Starmie")
                {
                    calculatedBlock -= calculatedBlock / 4;
                }
                if(defender.Name == "Victreebel")
                {
                    calculatedBlock -= calculatedBlock / 4;
                }
                if(defender.Name == "Koffing")
                {
                    calculatedBlock += calculatedBlock / 4;
                }
              
            }
            if (attacker.Name == "Charmander")
            {//   Weak against water,ground.  Grass weak to fire.
                if (defender.Name== "Victreebel")
                {
                    calculatedBlock -= calculatedBlock / 4;
                }

                if (defender.Name == "Starmie")
                {
                    calculatedBlock += calculatedBlock / 4;
                }
                if(defender.Name == "Onix")
                {
                    calculatedBlock += calculatedBlock / 4;
                }
            }
            if (attacker.Name == "Squirtle")
            {
                //strong against ground, rock, fire
                //weak against grass and electric
                if (defender.Name == "Onix")
                {
                    calculatedBlock -= calculatedBlock / 4;
                }
                if(defender.Name == "Victreebel")
                {
                    calculatedBlock += calculatedBlock / 4;
                }
                if(defender.Name == "Raichu")
                {
                    calculatedBlock += calculatedBlock / 4;
                }
            }
            return Block;

        }//CalcBlock()
        //MINI LAB, Make CalcHitChance() return HitChance.  Make it overridable.

        public virtual int CalcHitChance()
        {
            return HitChance; 
        }
        //Make calcDamage and return 0
        public virtual int CalcDamage()
        {
            return 0;
            //starting with just returning 0.  This is so that we can use this method from an instance of a "Character".
            //We will override it in the child classes of Monster and Player. Later ihn the track, we will learn about
            //abstract methods which is another way to accomplish this.
        }
    }//class
}
