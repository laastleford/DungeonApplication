using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //this class will not have any fields, props, or any custom ctors as it is just a warehouse for different methods
        
        public static void DoAttack(Character attacker, Character defender)
        {

            

            //get a random number from 1-100 as our "dice roll"
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(60);
            //sleep puts the system to "sleep", this will help randomize the damage/diceroll between our attacks

            if (diceRoll<= (attacker.CalcHitChance() - defender.CalcBlock( attacker, defender)))
            {
                //if the attacker hit
                //calculate the damage
                int damageDealt = attacker.CalcDamage();

                //assign the damage
                defender.Life -= damageDealt;

                //write it to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");

                //OPTIONAL: you could alert the user to any hit (\a alert or Beep)
                Console.ResetColor();
            }//if
            else
            {
                //the attacker missed!
                Console.WriteLine($"{attacker.Name} missed!");
            }//else

        }//DoAttack()

        public static void DoBattle(Player player, Monster monster)
        {
            //player attacks first
            DoAttack(player, monster);
                //monster attacks second if they are alive
                if (monster.Life > 0)
            {
                DoAttack(monster,player);

            }//if
        }//DoBattle()
    }//class
}//namespace
