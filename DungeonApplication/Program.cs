using DungeonLibrary;
using DungeonMonsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonApplication
{
    class Program
    {
        static void ConsoleDraw(IEnumerable<string> lines, int x, int y)
        {
            if (x > Console.WindowWidth) return;
            if (y > Console.WindowHeight) return;

            var trimLeft = x < 0 ? -x : 0;
            int index = y;

            x = x < 0 ? 0 : x;
            y = y < 0 ? 0 : y;

            var linesToPrint =
                from line in lines
                let currentIndex = index++
                where currentIndex > 0 && currentIndex < Console.WindowHeight
                select new
                {
                    Text = new String(line.Skip(trimLeft).Take(Math.Min(Console.WindowWidth - x, line.Length - trimLeft)).ToArray()),
                    X = x,
                    Y = y++
                };

            Console.Clear();
            foreach (var line in linesToPrint)
            {
                Console.SetCursorPosition(line.X, line.Y);
                Console.Write(line.Text);
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;


            #region ASCII
            var arr = new[]
{
@"                                  ,'\                               ",
@"    _.----.        ____         ,'  _\   ___    ___     ____        ",
@"_,-'       `.     |    |  /`.   \,-'    |   \  /   |   |    \  |`.  ",
@"\      __    \    '-.  | /   `.  ___    |    \/    |   '-.   \ |  | ",
@" \.   \   \   |  __ |  |/    ,',' _  `. |          | __  |    \|  | ",
@"  \    \  /   /,'_`.|       ,'/  / / /  |          ,' _`.|     |  | ",
@"   \    \/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  | ",
@"    \     ,-'/  /   \    ,'   | \/ / ,`.|         /  /   \  |     | ",
@"     \    \ |   \_/  |   `-.  \    `'  /|  |    ||   \_/  | |\    | ",
@"      \    \ \      /       `-.`.___,-' |  |\  /| \      /  | |   | ",
@"       \    \ `.__,'|  |`-._    `|      |__| \/ |  `.__,'|  | |   | ",
@"        \_.-'       |__|    `-._ |              '-.|     '-.| |   | ",
@"                                `'                            '-._| ",
        };

            var maxLength = arr.Aggregate(0, (max, line) => Math.Max(max, line.Length));
            var x = Console.BufferWidth / 2 - maxLength / 2;
            for (int y = -arr.Length; y < Console.WindowHeight + arr.Length; y++)
            {
                ConsoleDraw(arr, x, y);
                Thread.Sleep(100);
            }
            Console.Write("");







            





            #endregion

            Console.Title = "POKEMON!";
            Console.WriteLine("Welcome to POKEMON Trainer Gym!");

            //TODO 1. Create a player, need to learn about custom classes
            //Weapon sword = new Weapon(1, 8, 5, "Broadsword", false);

            Player player = InitializePlayer();
            //new Player("Leeroy Jenkins", 100, 100, 65, 20, Race.HalfOrc, sword);

            int defeatedMonsterCount = 0;//#defeated

            //TODO 2. Create loop for the room
            bool exit = false;// counter
            do
            {
                //! original code
                // create GetRoom() code
                //Console.WriteLine(GetRoom());

                string currentRoom = GetRoom();

                // create a monster
                Monster monster = GetMonster();
                //need to learn about custom classes, creating objects and probably randomly selecting one

                // create a loop for the menu
                bool reload = false;//counter
                do
                {

                    //!ADDED
                    Console.WriteLine($"{currentRoom}\n\nIn this room {monster.Name}");

                    //Create menu
                    #region MENU
                    Console.WriteLine("Please choose an action:\nA) Attack\nR) Run Away!\nP) Pokemon Info\nO) Opposing Pokemon Info\nX) Exit\nEnter your choice: ");

                    //user choice
                    string userChoice = Console.ReadLine().ToUpper();
                    if (userChoice.Length > 0)
                    {
                        //call substring() to get the first letter of userChoice
                        userChoice = userChoice.Substring(0, 1);

                    }//if

                    //clear
                    Console.Clear();

                    //switch for userChoice
                    switch (userChoice)
                    {
                        case "A":
                            Console.WriteLine("Attack!");
                            Combat.DoBattle(player, monster);

                            //Need to handle if player wins
                            // Need to handle if player loses
                            if (monster.Life <= 0)
                            {
                                //OPTIONAL: you could put logic here to gain items, life, xp, etc for defeating the monster
                                Console.WriteLine($"{monster.Name} fainted! You won this Pokemon battle!\n\n");
                                defeatedMonsterCount++;
                                Console.WriteLine($"{player.Name} is victorious!!!!");
                                //Console.WriteLine("Number pokemon defeated: " + defeatedMonsterCount);
                                reload = true;
                            }
                            break;

                        case "R":
                            Console.WriteLine("Run away!");
                            //handle running away and getting a new room, monster gets free attack
                            Combat.DoAttack(monster, player);
                            reload = true;//update (menu)
                            break;

                        case "P":
                            Console.WriteLine("Pokemon Info");
                            //Need to add players info and write it to screen
                            Console.WriteLine(player);
                            //Console.WriteLine.ToString());
                            break;

                        case "O":
                            Console.WriteLine("Opposing Pokemon Info");
                            Console.WriteLine(monster);
                            // Need to add monsters info
                            break;

                        case "X":
                        case "E":
                            Console.WriteLine("Quitting the gym... Goodbye!");
                            exit = true;//update
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }//switch

                    #endregion

                    // Ultimate place to address Player's life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine($"Your Pokemon, {player.Name}, has fainted.\n\nNumber of Pokemon battles won: {defeatedMonsterCount}");
                        exit = true;
                    }//if

                } while (!exit && !reload);//cond menu
            } while (!exit);// cond


        }//Main()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "This room oddly has pewter walls--a sight you've never seen before.  The floor has loose gravel that crunches with your every step...Trainer Brock is in the distance!",
            //Brock,onix
            "As the door opens, you feel a sweltering warm humidity hit your face.  There are ominous bubbling pools of water that surround the room, creating narrow dirt path throughout the room. Trainer Misty is waiting to battle!",
            //starmie, misty
            "Walking into the room, you instantly grow concerned.  The walls are a deep vermillion....  You see bright sparks emanating from something in the back of the room. Lt. Surge wants to battle!",
            //lt. surge, raichu
            "As you enter, there are elephantine leaves that hit you in the face!  It looks like you walked into a rainforest with the tangles of vibrant green foliage.  There's a slim path that winds to Erika!",
            //vileplume,victreebel erika
            "When you open the door, you instantly feel a tightness in your chest!  There are fuschia bioluminescent spores that fall like gentle snow within the dark room.  Despite this, Koga stands ready for battle!",
                //koga weezing,koffing
            };

            //for (int i = 0; i < rooms.Length; i++)
            //{
            //    string room = rooms[i];
            //    return room;
            //}
            Random rand = new Random();
            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];
            return room;

        }//GetRoom()

        private static Monster GetMonster()
        {
            //a collection of monsters
            List<Monster> monsterslist = new List<Monster>()
            {
                new Onix(),
                //new Onix()
                new Onix.Starmie(),

                new Onix.Raichu(),

                new Onix.Victreebel(),

                new Onix.Koffing()
                //new Goblin(),
                //new Goblin()
                    //if you were to have more custom monster types, and wanted to possibly see one 
                    //of them in the game, you would create those objects here
            };
            //shortuct is called Object iniitialization syntax^

            //1. Set up a random
            Random rand = new Random();
            //2. get a random integer from 0 to the max # of monsters in my monsterslist
            int indexNbr = rand.Next(monsterslist.Count);
            //3. Return the random monster
            return monsterslist[indexNbr];


            //ALL 3 STEPS in 1
            // return monsterslist[new Random().Next(monsterslist.Count)];

        }//GetMonster()

        private static Player InitializePlayer()
        {
            //info to capture
            //name, characterRace, equippedweapon
            string name = string.Empty;//container with default value
            Race characterRace;
            Weapon equippedWeapon;

            int life, maxLife;

            #region Initial Weapons, assigned by Race
            Weapon ember = new Weapon(4, 6, 15, "Ember");
            Weapon acquaTail = new Weapon(4, 6, 15, "Acqua Tail");
            Weapon vineWhip = new Weapon(4, 6, 15, "Vine Whip");
            //Weapon mastersword = new Weapon(6, 12, 20, "Master Sword", false);
            #endregion

            Console.WriteLine("You've entered a Pokemon Trainer Gym.  Are you ready? Y/N");
            string userReady = Console.ReadLine().ToUpper().Substring(0, 1);

            if (userReady == "Y")
            {
                Console.WriteLine("\n\nGood, you've prepared your Pokemon.  This will benefit you in your future battles!");
                //COULD ADD logic here to increase stats, give items, etc
                life = 60;
                maxLife = 60;

            }
            else
            {
                Console.WriteLine("\n\nUnfortunately, your Pokemon are not well prepared...Come back when you're better prepared");
                life = 35;
                maxLife = 35;
                //COULD ADD LOGIC to decrease stats or have event happen
            }//else

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();//pause before clearing the screen
            Console.Clear();

            #region Player customization, Name, and CharacterRace
            //Name
            // Console.WriteLine("What is your name?");
            //name = Console.ReadLine().ToUpper();
            // Console.Clear();

            //CharacterRAce
            Console.Write($"Trainer, choose your Pokemon: \n\n\n" +
                "S) Squirtle\nC) Charmander\nB) Bulbasaur\n" +
                "Enter your choice: ");
            string userRace = Console.ReadLine().ToUpper().Substring(0, 1);

            switch (userRace)
            {
                case "S":
                    characterRace = Race.Squirtle;
                    equippedWeapon = acquaTail;
                    name = "Squirtle";
                    Console.WriteLine("\n\n\n");

                    Console.WriteLine(
                    #region SquirtleASCII

                    
@"              _,........__                                    
             ,-'            '`-.                                              
           ,'                   `-.                      
         ,'                        \\                          
       ,'                           .                   
       .'\               ,''.       `                           
      ._.'|             / |  `       \                 
      |   |            `-.'  ||       `.                       
      |   |           '-._,' ||       | \                            
      .`.,'             `..,'.'       , |`-.                    
      l                       .'`.  _/  |   `.                                   
      `-.._'-   ,          _ _'  - ' \  .     `            
 `.''''''-.`-...,---------','         `. `....__.            
 .'        `' -..___      __,'\\        \\  \\    \\            
 \_.            |   `'''''    `.           .  \     \                   
   `.           |               `.         |  .      L                        
     `.         |`--...________.'.        j   |       |                  
       `._     .'      |          `.     .|   ,       |                    
          `--,\        .            `7''' |  ,        |                    
             ` `       `            /     |  |        |    _, -''''`-.             
              \ `.      .          /      |  '        |  ,'          `.           
               \  v.__  .         '       .   \      /| /              \            
                \/    `--\'''''''`.        \   \    /.''                |                            
                 `        .        `._ ___,j.   `  /.-       , ---.     |             
                 ,`-.      \         .'     `.  |/          j      `    |          
                /    `.     \       /         \ /           |     /    j                   
               |       `-.   7 -.._.          |'            '         /                               
               |          `./_    `|          |             ,     _, '                        
               `.           / `----|          | -............`---'                        
                 \          \      |          |                                            
               , '           )     `.         |                                                      
                7____,,..--'      /           |                                        
                                  `---.__, --.''                                        ");

                    #endregion

                    break;
                case "C":
                    characterRace = Race.Charmander;
                    equippedWeapon = ember;
                    name = "Charmander";
                    Console.WriteLine("\n\n\n");
                    Console.WriteLine(
                    #region CharmanderASCII



@"                _.--''`-..                                          
              , '           `.                                       
            ,'          __    `.                                     
           /|          ' __    \\                                     
          , |           / |.    .                                     
          |, '         !_.'|    |                                     
        , '            '   |    |                                      
       /              |`--'|    |                                     
      |                `---'    |                                      
       .   ,                    |                       , '.           
        ._     '           _'   |                    , '  \\ `         
    `.. `.`-...___,...---''     |        __,.        ,`'   L,|         
    |, `- .`._        _,-,.'    .   __.-' -. /        .   ,    \\       
  -:..     `. `-..-- _.,.<       `'       / `.        `-/ |    .         
   `,          '''''     `.                ,'         |   |   ',,         
     `.      '             '              /          '    |'. |/        
        `.   |              \\       _, -'           |       ''         
          `._'               \\   ''\\                .      |          
             |                '      \\                `._  ,'          
             |                 '      \\                .' |            
             |                 .       \\                | |          
             |                 |       L               ,'  |            
             `                 |       |              /    '         
              \\               |       |           , '    //            
            ,' \\              |  _.._ ,-..___,..-'     , '                
           /     .             .      `!              , j'               
          /       `.          /        .            .'/                  
         .          `.       /         |         _.'.'                          
          `.          7`'---'          | ------''_.'                             
         _,.`, _     _'                ,''-----''                     
     _,- _    '       `.     .'      ,\\                                  
      ''--'---''''''        `' '! | ! /                               
                              `' ' - '                              ");




                    #endregion

                    break;

                case "B":
                    characterRace = Race.Bulbasaur;
                    equippedWeapon = vineWhip;
                    name = "Bulbasaur";
                    Console.WriteLine("\n\n\n");

                    Console.WriteLine(
                    #region BulbasaurASCII



@"                                            /                       
                         _,.------....___,.' ',.-.                  
                     , -'          _,.--'       |                        
                   , '         _.-'.                               
                  /   ,     , '                   `                
                 .   /     /                       ``.               
                 |  |     .                        \\.\\               
       ____      | ___._. |        __               \\ `.                      
     .'    `---''       ``' -.--''`  \\              .  \\           
    .   ,             __              `              |   .                     
    `, '         ,-+'   .              \\            |     L             
   , '          '    _.'                -._          /     |              
  ,`-.    ,+.   `--'                       >.      ,'      |                 
 . .'\'   `-'       __     , , -.         /  `.__.-       ,'               
 ||:, .           '    ;  / / \\ `        `.    .       .'/                 
 j|:D   \\          `--' ',' _  . .         `.__,  \\  , /              
/ L:_   |                .      :_;                 `.'.'                
.    '''                  '''''''                     V                 
 `.                                    .    `.   _,..  `                 
   `, _      .    .              _, -'/    .. `,'   __  `                                  
    ) \\`._         ___....----='  ,'   .'  \\ |   '  \\  .                        
   /   `.   '`-.--''         _,' ,'     `---'  |    `./   |                   
  .   _  `'''--.._____..--'   , '                         |                     
  | .' `. `-.                /-.           /              ,                         
  | `._.'    `,_            ;  /         ,'              .                                     
 .'          /| `-.        . ,'         ,               ,                             
 '-.__ __ _,','    '`-..___; -...__   ,.'\\   ____.___.'                             
 `+ ^ --'..'   '-`-^-' +-- `-^ -'`.''   +++++`.,^.`.--'                           ");




                    #endregion

                    break;

                default:
                    Console.WriteLine("You can't cheat the system");
                    characterRace = Race.Bulbasaur;
                    equippedWeapon = vineWhip;
                    name = "Bulbasaur";
                    Console.WriteLine("\n\n\n");

                    Console.WriteLine(
                    #region BulbasaurASCII



@"                                            /                       
                         _,.------....___,.' ',.-.                  
                     , -'          _,.--'       |                        
                   , '         _.-'.                               
                  /   ,     , '                   `                
                 .   /     /                       ``.               
                 |  |     .                        \\.\\               
       ____      | ___._. |        __               \\ `.                      
     .'    `---''       ``' -.--''`  \\              .  \\           
    .   ,             __              `              |   .                     
    `, '         ,-+'   .              \\            |     L             
   , '          '    _.'                -._          /     |              
  ,`-.    ,+.   `--'                       >.      ,'      |                 
 . .'\'   `-'       __     , , -.         /  `.__.-       ,'               
 ||:, .           '    ;  / / \\ `        `.    .       .'/                 
 j|:D   \\          `--' ',' _  . .         `.__,  \\  , /              
/ L:_   |                .      :_;                 `.'.'                
.    '''                  '''''''                     V                 
 `.                                    .    `.   _,..  `                 
   `, _      .    .              _, -'/    .. `,'   __  `                                  
    ) \\`._         ___....----='  ,'   .'  \\ |   '  \\  .                        
   /   `.   '`-.--''         _,' ,'     `---'  |    `./   |                   
  .   _  `'''--.._____..--'   , '                         |                     
  | .' `. `-.                /-.           /              ,                         
  | `._.'    `,_            ;  /         ,'              .                                     
 .'          /| `-.        . ,'         ,               ,                             
 '-.__ __ _,','    '`-..___; -...__   ,.'\\   ____.___.'                             
 `+ ^ --'..'   '-`-^-' +-- `-^ -'`.''   +++++`.,^.`.--'                           ");




                    #endregion

                    break;
            }//switch
            #endregion
            Console.ReadLine();
            Console.Clear();

            //create palyer with objects captured through above logic
            Player player = new Player(name, life, maxLife, 30, 30, characterRace, equippedWeapon);

            Console.Write($"****** {player.Name}'S DETAILS ******\n\n" +
                $"Pokemon: {player.Name}\nHP: {player.Life}" +
                $" of {player.MaxLife}\nAttack Type: {player.EquippedWeapon}\n\nPrepare for battle...");

            Console.ReadKey();
            Console.Clear();
            return player;
        }//initializeplayer()

    }//class
}//namespace
