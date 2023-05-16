using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj
{
    class Game
    {
        public Maps maps = new Maps();
        private Player currentPlayer;
        private NextLevelPortal currentPortal;
        private CashDrop currentCash, currentCash1;
        private TreasureBox currentBox, currentBox1;
        private Traps Trap;
        private Vendor currentVendor;
        private Enemy currentEnemy, currentEnemy1, currentEnemy2;
        private Lever currentLever;
        public int currentLevel;
        bool playerCanLeaveLVL;
        bool enemyDead = false;
        public Queue<string> Log = new Queue<string>();

        public void Start()
        {
            currentPlayer.currentHP = currentPlayer.maxHP;
            Console.WriteLine("Hello there! welcome to the dungeon.");
            Console.WriteLine("please, what is your name?");
            currentPlayer.Name = Console.ReadLine();
            Console.WriteLine($"Perfect! {currentPlayer.Name} get ready, the game is about to start.");
            Console.WriteLine("press any key to continue..");
            Console.ReadLine();
            GameLoop();
            Console.ReadKey(true);
        }

        private void PrintCurrentFrame()
        {
            Console.Clear();
            maps.PrintCurrentLevel(maps.currentLevel);
            currentPlayer.Print();
            currentPortal.Print();
            Console.SetCursorPosition(14, 0);
            Console.WriteLine($"{currentPlayer.Name} Health: {currentPlayer.currentHP} / {currentPlayer.maxHP} | {currentPlayer.Name} Elixirs: {currentPlayer.Elixir} | {currentPlayer.Name} Gold: {currentPlayer.Gold} | {currentPlayer.Name} score: {currentPlayer.Score} | {currentPlayer.Name} exp: {currentPlayer.exp} | {currentPlayer.Name} level: {currentPlayer.Level}");
            Console.SetCursorPosition(14, 1);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");

            if (currentLevel == 1)
            {
                Console.SetCursorPosition(14, 2);
                Console.WriteLine("use the arrow keys to move, '@' represents your avatar, 'X' represents the next level portal.");
            }

            if(currentLevel == 2)
            {
                Console.SetCursorPosition(14, 2);
                Console.WriteLine("'B' represents a treasure box, walk on it to obtain its treasures.");
            }

            if(currentLevel == 3)
            {
                Console.SetCursorPosition(14, 2);
                Console.WriteLine("Markers of the color Red represent enemies. once in range, Enemies will start chasing you.");
                Console.SetCursorPosition(14, 3);
                Console.WriteLine("If an enemy reaches you, or you reach an enemy, A battle will start.");
            }

            if (currentLevel == 4)
            {
                Console.SetCursorPosition(14, 2);
                Console.WriteLine("'V' represents Vendor, use it to buy essentials.");
                Console.SetCursorPosition(14, 3);
                Console.WriteLine("'G' represents Gold, Gold can sometimes be found through out the dungeon on the ground.");
            }

            if (currentLevel == 5)
            {
                Console.SetCursorPosition(14, 2);
                Console.WriteLine("Some levels will acquire you to defeat all enemies before moving on to the next one.");
            }

            if(currentLevel == 6)
            {
                Console.SetCursorPosition(14, 2);
                Console.WriteLine("'L' represents a Lever, can be used to move walls or change the level's layout.");
            }

            if (currentLevel == 9)
            {
                Console.SetCursorPosition(14, 2);
                Console.WriteLine("Please kill all enemies to move to the next level.");
            }

            if (currentLevel == 10)
            {
                Console.SetCursorPosition(14, 2);
                Console.WriteLine("This is the last level, defeat the boss to win the game.");
            }

            Console.SetCursorPosition(0, 10);
            
            for (int i = 0; i < Log.Count; i++)
            {
                string count = Log.Dequeue();
                Console.WriteLine(count);
                Log.Enqueue(count);
            }
            
            if (Log.Count > 5)
                Log.Dequeue();

            Console.SetCursorPosition(0, 16);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

            Console.SetCursorPosition(0, 9);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");




            if (currentCash != null)
                currentCash.Print();

            if(currentCash1 != null)
                currentCash1.Print();

            if(currentBox != null)
                currentBox.Print();

            if(currentBox1 != null)
                currentBox1.Print();

            if (currentVendor != null)
                currentVendor.Print();

            if (currentEnemy != null)
                currentEnemy.Print();

            if (currentEnemy1 != null)
                currentEnemy1.Print();

            if (currentEnemy2 != null)
                currentEnemy2.Print();

            if (currentLever != null)
                currentLever.Print();

        }

        private void PlayerMovementInput()
        {
            ConsoleKeyInfo keyinfo = Console.ReadKey(true);
            ConsoleKey input = keyinfo.Key;
            switch(input)
            {
                case ConsoleKey.UpArrow:
                     if (maps.isPositionMoveable(currentPlayer.X, currentPlayer.Y - 1, maps.currentLevel ))
                     {
                         currentPlayer.Y -= 1;
                     }
                    break;

                case ConsoleKey.DownArrow:
                    if (maps.isPositionMoveable(currentPlayer.X, currentPlayer.Y + 1, maps.currentLevel))
                    {
                        currentPlayer.Y += 1;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (maps.isPositionMoveable(currentPlayer.X - 1, currentPlayer.Y, maps.currentLevel))
                    {
                        currentPlayer.X -= 1;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (maps.isPositionMoveable(currentPlayer.X + 1, currentPlayer.Y, maps.currentLevel))
                    {
                        currentPlayer.X += 1;
                    }
                    break;

                default:
                    break;
            }
            
        }

        public void MoveToNextLevel()
        {
            switch(currentLevel)
            {
                case 1:
                    {
                        SetCLTo2();
                        currentPlayer.exp += 5;
                        currentPlayer.Score += 10;
                        break;
                    }
                case 2:
                    {
                        SetCLTo3();
                        currentPlayer.exp += 5;
                        currentPlayer.Score += 10;
                        break;
                    }
                case 3:
                    {
                        SetCLTo4();
                        currentPlayer.exp += 5;
                        currentPlayer.Score += 10;
                        break;
                    }
                case 4:
                    {
                        SetCLTo5();
                        currentPlayer.exp += 5;
                        currentPlayer.Score += 10;
                        break;
                    }
                case 5:
                    {
                        SetCLTo6();
                        currentPlayer.exp += 5;
                        currentPlayer.Score += 10;
                        break;
                    }
                case 6:
                    {
                        SetCLTo7();
                        currentPlayer.exp += 5;
                        currentPlayer.Score += 10;
                        break;
                    }
                case 7:
                    {
                        SetCLTo8();
                        currentPlayer.exp += 5;
                        currentPlayer.Score += 10;
                        break;
                    }
                case 8:
                    {
                        SetCLTo9();
                        currentPlayer.exp += 5;
                        currentPlayer.Score += 10;
                        break;
                    }
                case 9:
                    {
                        SetCLTo10();
                        currentPlayer.exp += 5;
                        currentPlayer.Score += 10;
                        break;
                    }
                case 10:
                    {
                        Console.SetCursorPosition(14, 3);
                        Log.Enqueue("GG's, you have kicked DBD's ass!");
                        Log.Enqueue($"{currentPlayer.Name} final score: {currentPlayer.Score}, {currentPlayer.Name} final level: {currentPlayer.Level}");
                        Log.Enqueue("Thanks for playing! hope you enjoyed.");
                        Log.Enqueue("Special thanks - Dor Ben Dor, Nadav Litver");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public void VendorMenu()
        {
            bool shopOpen = true;
            while (shopOpen)
            {
                Console.WriteLine("Hello! welcome to the shop would you like to purchase Elixirs?");
                Console.WriteLine("Elixir restores your HP to the max, costs 10 Gold per unit");
                Console.WriteLine("Please answer with 'yes' or 'no'");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "yes":
                        {
                            Console.WriteLine($"You have {currentPlayer.Gold} gold, how manny would you like to buy?");
                            int amount = int.Parse(Console.ReadLine());
                            if (currentPlayer.Gold / 10 < amount)
                            {
                                Console.WriteLine("It seems like you dont have enough gold to buy that amount of Elixirs, please try again");
                                Console.WriteLine("press any key to continue");
                                Console.ReadLine();
                                shopOpen = false;
                                currentPlayer.X += 1;
                            }
                            else
                            {
                                currentPlayer.Gold -= amount * 10;
                                currentPlayer.Elixir += amount;
                                Console.WriteLine($"You have succesfully bought {amount} Elixirs, you now have {currentPlayer.Elixir} Elixirs.");
                                Console.WriteLine("Thank you for purchasing with us :]");
                                Console.WriteLine("press any key to continue");
                                Console.ReadLine();
                                shopOpen = false;
                                currentPlayer.X += 1;
                            }
                            break;
                        }

                    case "no":
                        {
                            shopOpen = false;
                            currentPlayer.X += 1;
                            break;
                        }
                    default:
                        break;
                }

            }
        }

        public void BattleLoop(Enemy enemyNum)
        {
            var battleEnded = false;
            enemyDead = false;

            while (!battleEnded)
            {
                Console.WriteLine($"You have encountered an agressive {enemyNum.Name}!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1.Attack");
                Console.WriteLine("2.Heal");
                Console.WriteLine("3.Run");
                Console.WriteLine("please select an option by writing its number..");

                var input = int.Parse(Console.ReadLine());                
                var playerAction = true;

                while (playerAction)
                {
                    switch (input)
                    {
                        case 1:
                            {
                                switch (currentPlayer.PlayerHit(currentPlayer.hitChance))
                                {
                                    case true:
                                        {
                                            switch (currentPlayer.CriticalHit(currentPlayer.critChance))
                                            {
                                                case true:
                                                    {
                                                        enemyNum.HP -= currentPlayer.Damage * currentPlayer.critMultyplier;
                                                        Console.WriteLine($"{currentPlayer.Name} hit {enemyNum.Name} for {currentPlayer.Damage * currentPlayer.critMultyplier} damage, Critical hit!");
                                                        Console.WriteLine($"{enemyNum.Name} hp is now {enemyNum.HP}.");
                                                        playerAction = false;
                                                        break;
                                                    }

                                                case false:
                                                    {
                                                        enemyNum.HP -= currentPlayer.Damage;
                                                        Console.WriteLine($"{currentPlayer.Name} hit {enemyNum.Name} for {currentPlayer.Damage} damage!");
                                                        Console.WriteLine($"{enemyNum.Name} hp is now {enemyNum.HP}.");
                                                        playerAction = false;
                                                        break;
                                                    }
                                            }
                                            break;
                                        }

                                    case false:
                                        {
                                            Console.WriteLine($"{currentPlayer.Name} attack missed!");
                                            playerAction = false;
                                            break;
                                        }
                                }
                                break;

                            }

                        case 2:
                            {
                                if (currentPlayer.Elixir > 0 && currentPlayer.currentHP != currentPlayer.maxHP)
                                {
                                    currentPlayer.Elixir--;
                                    currentPlayer.currentHP = currentPlayer.maxHP;
                                    Console.WriteLine($"{currentPlayer.Name} used an Elixir, {currentPlayer.Name} HP is now {currentPlayer.currentHP}!");
                                    playerAction = false;
                                }
                                else
                                {
                                    Console.WriteLine($"Either you do not have enough Elixirs to heal, or your hp is already full.");
                                    playerAction = false;
                                }
                                break;
                            }

                        case 3:
                            {
                                Console.WriteLine($"{currentPlayer.Name} fleed from battle.");
                                Console.ReadLine();
                                Console.WriteLine("press any key to continue..");
                                playerAction = false;
                                battleEnded = true;
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("cannot parse input..");
                                break;
                            }
                    }
                }

                if(enemyNum.HP <= 0)
                {
                    Console.WriteLine($"Well done, you have defeated {enemyNum.Name}.");
                    Console.WriteLine("You are awarded with 5 exp and 10 score!");
                    currentPlayer.exp += 5;
                    currentPlayer.Score += 10;
                    Console.ReadLine();
                    Console.WriteLine("press any key to continue..");
                    battleEnded = true;
                    enemyDead = true;
                }


                if (enemyNum != null)
                {
                    Console.WriteLine($"it is {enemyNum.Name}'s turn!");
                    switch (enemyNum.EnemyHit(enemyNum.hitChance))
                    {
                        case true:
                            {
                                switch (enemyNum.CriticalHit(enemyNum.critChance))
                                {
                                    case true:
                                        {
                                            currentPlayer.currentHP -= enemyNum.Damage * enemyNum.critMultyplier;
                                            Console.WriteLine($"{enemyNum.Name} hit {currentPlayer.Name} for {enemyNum.Damage * enemyNum.critMultyplier} damage, critical hit!");
                                            Console.WriteLine($"{currentPlayer.Name} hp is now {currentPlayer.currentHP}.");
                                            break;
                                        }

                                    case false:
                                        {
                                            currentPlayer.currentHP -= enemyNum.Damage;
                                            Console.WriteLine($"{enemyNum.Name} hit {currentPlayer.Name} for {enemyNum.Damage} damage!");
                                            Console.WriteLine($"{currentPlayer.Name} hp is now {currentPlayer.currentHP}.");
                                            break;
                                        }
                                }
                                break;
                            }

                        case false:
                            {
                                Console.WriteLine($"{enemyNum.Name} attack missed!");
                                break;
                            }
                    }
                }

                if(currentPlayer.currentHP <= 0)
                {
                    Console.WriteLine("Oh no, you have died..");
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine("to restart game press any key..");
                    Console.ReadLine();
                    SetCLTo1();
                    currentPlayer.currentHP = currentPlayer.maxHP;
                    Log.Enqueue("Game restarted.");
                    battleEnded = true;
                }
            }
        }

        public void EnemyMovement(Player currentPlayer, Enemy enemyNum)
        {            
            if (this.currentPlayer.X - 2 == enemyNum.X && maps.isPositionMoveable(enemyNum.X +1, enemyNum.Y, maps.currentLevel))
                enemyNum.X += 1;

            if (this.currentPlayer.X + 2 == enemyNum.X && maps.isPositionMoveable(enemyNum.X - 1, enemyNum.Y, maps.currentLevel))
                enemyNum.X -= 1;

            if (this.currentPlayer.Y - 2 == enemyNum.Y && maps.isPositionMoveable(enemyNum.X, enemyNum.Y + 1, maps.currentLevel))
                enemyNum.Y += 1;

            if (this.currentPlayer.Y + 2 == enemyNum.Y && maps.isPositionMoveable(enemyNum.X, enemyNum.Y - 1, maps.currentLevel))
                enemyNum.Y -= 1;
        }

        public void BossEnemyMovement(Player currentPlayer, Enemy enemyNum)
        {
            if (this.currentPlayer.X - 3 == enemyNum.X && maps.isPositionMoveable(enemyNum.X + 2, enemyNum.Y, maps.currentLevel))
                enemyNum.X += 1;

            if (this.currentPlayer.X + 1 == enemyNum.X && maps.isPositionMoveable(enemyNum.X - 1, enemyNum.Y, maps.currentLevel))
                enemyNum.X -= 1;

            if (this.currentPlayer.Y - 2 == enemyNum.Y && maps.isPositionMoveable(enemyNum.X, enemyNum.Y + 1, maps.currentLevel))
                enemyNum.Y += 1;

            if (this.currentPlayer.Y + 2 == enemyNum.Y && maps.isPositionMoveable(enemyNum.X, enemyNum.Y - 1, maps.currentLevel))
                enemyNum.Y -= 1;
        }

        public void SetCLTo1()
        {
            for (int i = 0; i < maps.level1.GetLength(0); i++)
            {
                for (int j = 0; j < maps.level1.GetLength(1); j++)
                {
                    maps.currentLevel[i, j] = maps.level1[i, j];
                }
            }
            currentPlayer = new Player(1, 7);
            currentPortal = new NextLevelPortal(12, 1);
            playerCanLeaveLVL = true;

            if (currentEnemy != null)
                currentEnemy = null;

            if (currentEnemy1 != null)
                currentEnemy1 = null;

            if (currentEnemy2 != null)
                currentEnemy2 = null;

            if (currentVendor != null)
                currentVendor = null;

            if (currentLever != null)
                currentLever = null;

            if (currentBox != null)
                currentBox = null;

            if (currentBox1 != null)
                currentBox1 = null;

            if (currentCash != null)
                currentCash = null;

            if (currentCash1 != null)
                currentCash1 = null;

            currentLevel = 1;
        }

        public void SetCLTo2()
        {
            for (int i = 0; i < maps.level2.GetLength(0); i++)
            {
                for (int j = 0; j < maps.level2.GetLength(1); j++)
                {
                    maps.currentLevel[i, j] = maps.level2[i, j];
                }
            }
            currentPlayer.X = 1;
            currentPlayer.Y = 7;
            currentBox = new TreasureBox(6, 1);
            currentBox1 = new TreasureBox(6, 7);
            Trap = new Traps(8, 4);
            playerCanLeaveLVL = true;
            currentLevel = 2;
            Log.Enqueue("Congrats, you have moved to level 2, awarded 10 score points and 5 exp points.");

        }

        public void SetCLTo3()
        {
            for (int i = 0; i < maps.level3.GetLength(0); i++)
            {
                for (int j = 0; j < maps.level3.GetLength(1); j++)
                {
                    maps.currentLevel[i, j] = maps.level3[i, j];
                }
            }
            currentPlayer.X = 1;
            currentPlayer.Y = 7;            
            Trap = new Traps(8, 7);
            currentEnemy = new Enemy("Snake", "S", 7, 1, 8, 4);
            playerCanLeaveLVL = true;
            currentLevel = 3;
            Log.Enqueue("Congrats, you have moved to level 3, awarded 10 score points and 5 exp points.");

            if (currentBox != null)
                currentBox = null;
            if (currentBox1 != null)
                currentBox1 = null;

        }

        public void SetCLTo4()
        {
            for (int i = 0; i < maps.level4.GetLength(0); i++)
            {
                for (int j = 0; j < maps.level4.GetLength(1); j++)
                {
                    maps.currentLevel[i, j] = maps.level4[i, j];
                }
            }
            currentPlayer.X = 1;
            currentPlayer.Y = 7;
            currentCash = new CashDrop(11, 7);
            currentCash1 = new CashDrop(6, 3);
            currentBox = new TreasureBox(1, 5);
            currentVendor = new Vendor(6, 1);
            playerCanLeaveLVL = true;
            currentLevel = 4;
            Log.Enqueue("Congrats, you have moved to level 4, awarded 10 score points and 5 exp points.");

            if (currentEnemy != null)
                currentEnemy = null;

        }

        public void SetCLTo5()
        {
            for (int i = 0; i < maps.level5.GetLength(0); i++)
            {
                for (int j = 0; j < maps.level5.GetLength(1); j++)
                {
                    maps.currentLevel[i, j] = maps.level5[i, j];
                }
            }
            currentPlayer.X = 1;
            currentPlayer.Y = 7;
            currentEnemy = new Enemy("Snake", "S", 7, 1, 6, 6);            
            playerCanLeaveLVL = false;
            currentLevel = 5;
            Log.Enqueue("Congrats, you have moved to level 5, awarded 10 score points and 5 exp points.");

            if (currentCash != null)
                currentCash = null;

            if (currentCash1 != null)
                currentCash1 = null;

            if (currentBox != null)
                currentBox = null;

            if (currentVendor != null)
                currentVendor = null;

        }

        public void SetCLTo6()
        {
            for (int i = 0; i < maps.level6.GetLength(0); i++)
            {
                for (int j = 0; j < maps.level6.GetLength(1); j++)
                {
                    maps.currentLevel[i, j] = maps.level6[i, j];
                }
            }
            currentPlayer.X = 1;
            currentPlayer.Y = 7;            
            currentLever = new Lever(1, 1);
            currentBox = new TreasureBox(11, 7);
            if (currentEnemy != null)
                currentEnemy = null;
            currentLevel = 6;
            Log.Enqueue("Congrats, you have moved to level 6, awarded 10 score points and 5 exp points.");                        
        }

        public void SetCLTo6a()
        {
            for (int i = 0; i < maps.level6a.GetLength(0); i++)
            {
                for (int j = 0; j < maps.level6a.GetLength(1); j++)
                {
                    maps.currentLevel[i, j] = maps.level6a[i, j];
                }
            }            
            if(currentBox != null)
            {
                currentBox.X = 11;
                currentBox.Y = 7;
            }
            currentLevel = 6;
            Log.Enqueue("A wall that blocked the path to the next level has been removed.");
        }

        public void SetCLTo7()
        {
            for (int i = 0; i < maps.level7.GetLength(0); i++)
            {
                for (int j = 0; j < maps.level7.GetLength(1); j++)
                {
                    maps.currentLevel[i, j] = maps.level7[i, j];
                }
            }
            currentPlayer.X = 1;
            currentPlayer.Y = 7;            
            currentLever = new Lever(1, 1);
            currentBox = new TreasureBox(7, 7);
            currentBox1 = new TreasureBox(7, 6);
            currentVendor = new Vendor(7, 2);
            currentEnemy = new Enemy("Snake", "S", 7, 1, 6, 4);
            currentLevel = 7;
            Log.Enqueue("Congrats, you have moved to level 7, awarded 10 score points and 5 exp points.");
        }

        public void SetCLTo7a()
        {
            for (int i = 0; i < maps.level7a.GetLength(0); i++)
            {
                for (int j = 0; j < maps.level7a.GetLength(1); j++)
                {
                    maps.currentLevel[i, j] = maps.level7a[i, j];
                }
            }
            currentPortal.X = 12;
            currentPortal.Y = 1;            
            currentLevel = 7;
            Log.Enqueue("A wall that blocked the path to the next level has been removed.");
        }

        public void SetCLTo8()
        {
            for (int i = 0; i < maps.level8.GetLength(0); i++)
            {
                for (int j = 0; j < maps.level8.GetLength(1); j++)
                {
                    maps.currentLevel[i, j] = maps.level8[i, j];
                }
            }
            currentPlayer.X = 1;
            currentPlayer.Y = 7;

            if (currentEnemy != null)
                currentEnemy = null;

            currentEnemy = new Enemy("Snake" ,"S" ,7 , 1, 11, 7);
            currentEnemy1 = new Enemy("Orc", "O", 10, 2, 11, 5);

            if (currentBox != null)
                currentBox = null;

            currentBox = new TreasureBox(11, 3);
            currentLevel = 8;
            Log.Enqueue("Congrats, you have moved to level 8, awarded 10 score points and 5 exp points.");

            if (currentVendor != null)
                currentVendor = null;

        }

        public void SetCLTo9()
        {
            for (int i = 0; i < maps.level9.GetLength(0); i++)
            {
                for (int j = 0; j < maps.level9.GetLength(1); j++)
                {
                    maps.currentLevel[i, j] = maps.level9[i, j];
                }
            }
            currentPlayer.X = 1;
            currentPlayer.Y = 7;

            if (currentBox != null)
                currentBox = null;

            currentBox = new TreasureBox(1, 2);
            currentBox1 = new TreasureBox(11, 6);
            currentCash = new CashDrop(11, 7);
            currentCash1 = new CashDrop(1, 1);
            Trap = new Traps(10, 2);

            if (currentEnemy != null)
                currentEnemy = null;

            if (currentEnemy1 != null)
                currentEnemy1 = null;

            currentEnemy1 = new Enemy("Orc", "O", 10, 2, 9, 6);
            currentEnemy = new Enemy("Orc", "O", 10, 2, 3, 1);
            playerCanLeaveLVL = false;
            currentLevel = 9;
            Log.Enqueue("Congrats, you have moved to level 9, awarded 10 score points and 5 exp points.");
        }

        public void SetCLTo10()
        {
            for (int i = 0; i < maps.level10.GetLength(0); i++)
            {
                for (int j = 0; j < maps.level10.GetLength(1); j++)
                {
                    maps.currentLevel[i, j] = maps.level10[i, j];
                }
            }
            currentPlayer.X = 1;
            currentPlayer.Y = 7;


            if (currentBox != null)
                currentBox = null;

            if (currentBox1 != null)
                currentBox = null;

            if (currentCash != null)
                currentCash = null;

            if (currentCash1 != null)
                currentCash1 = null;

            if (Trap != null)
                Trap = null;

            currentVendor = new Vendor(6, 6);
            currentEnemy2 = new Enemy("Dor Ben Dor", "DBD", 20, 4, 5, 2);
            playerCanLeaveLVL = true;
            currentLevel = 10;
            Log.Enqueue("Congrats, you have moved to the last level, awarded 10 score points and 5 exp points.");
        }

        public void GameLoop()
        {
            while(true)
            {
                PrintCurrentFrame();
                
                PlayerMovementInput();

                if (currentPlayer.X == currentPortal.X && currentPlayer.Y == currentPortal.Y && playerCanLeaveLVL == true)
                    MoveToNextLevel();

                else if (currentPlayer.X == currentPortal.X && currentPlayer.Y == currentPortal.Y && playerCanLeaveLVL == false)
                    Log.Enqueue("please kill all enemies to move to the next level.");

                if (currentBox != null)
                {
                    if (currentPlayer.X == currentBox.X && currentPlayer.Y == currentBox.Y)
                    {
                        int chest = currentBox.OpenChest();
                        currentPlayer.Gold += chest;
                        Log.Enqueue("You have found " + chest + " gold in the treasure box!");
                        currentBox = null;
                    }
                }

                if (currentBox1 != null)
                {
                    if (currentPlayer.X == currentBox1.X && currentPlayer.Y == currentBox1.Y)
                    {
                        int chest = currentBox1.OpenChest();
                        currentPlayer.Gold += chest;
                        Log.Enqueue("You have found " + chest + " gold in the treasure box!");
                        currentBox1 = null;
                    }
                }

                if (currentCash != null)
                {
                    if (currentPlayer.X == currentCash.X && currentPlayer.Y == currentCash.Y)
                    {
                        int drop = currentCash.GetCashDrop();
                        currentPlayer.Gold += drop;
                        Log.Enqueue("You have found " + drop + " gold!");
                        currentCash = null;
                    }
                }

                if (currentCash1 != null)
                {
                    if (currentPlayer.X == currentCash1.X && currentPlayer.Y == currentCash1.Y)
                    {
                        int drop = currentCash1.GetCashDrop();
                        currentPlayer.Gold += drop;
                        Log.Enqueue("You have found " + drop + " gold!");
                        currentCash1 = null;
                    }
                }

                if(Trap != null)
                {
                    if(currentPlayer.X == Trap.X && currentPlayer.Y == Trap.Y)
                    {
                        Log.Enqueue("Trap activated!");
                        currentPlayer.currentHP = Trap.PoisonTrap(currentPlayer.currentHP);
                        Log.Enqueue("Player lost 3 HP!");
                        Trap = null;
                    }
                }

                if(currentPlayer.Level == 1 && currentPlayer.exp >= 10)
                {
                    Log.Enqueue($"Congrats, you have leveled up to level {currentPlayer.Level + 1}!");
                    currentPlayer.Level = currentPlayer.LevelRaiser(currentPlayer.Level);
                    currentPlayer.exp = currentPlayer.expReset(currentPlayer.exp);
                    currentPlayer.maxHP = currentPlayer.HPRaiser(currentPlayer.maxHP, currentPlayer.currentHP);
                }

                if (currentPlayer.Level == 2 && currentPlayer.exp >= 15)
                {
                    Log.Enqueue($"Congrats, you have leveled up to level {currentPlayer.Level + 1}!");
                    currentPlayer.Level = currentPlayer.LevelRaiser(currentPlayer.Level);
                    currentPlayer.exp = currentPlayer.expReset(currentPlayer.exp);
                    currentPlayer.maxHP = currentPlayer.HPRaiser(currentPlayer.maxHP, currentPlayer.currentHP);
                }

                if (currentPlayer.Level == 3 && currentPlayer.exp >= 20)
                {
                    Log.Enqueue($"Congrats, you have leveled up to level {currentPlayer.Level + 1}!");
                    currentPlayer.Level = currentPlayer.LevelRaiser(currentPlayer.Level);
                    currentPlayer.exp = currentPlayer.expReset(currentPlayer.exp);
                    currentPlayer.maxHP = currentPlayer.HPRaiser(currentPlayer.maxHP, currentPlayer.currentHP);
                }

                if (currentPlayer.Level == 4 && currentPlayer.exp >= 25)
                {
                    Log.Enqueue($"Congrats, you have leveled up to level {currentPlayer.Level + 1}!");
                    currentPlayer.Level = currentPlayer.LevelRaiser(currentPlayer.Level);
                    currentPlayer.exp = currentPlayer.expReset(currentPlayer.exp);
                    currentPlayer.maxHP = currentPlayer.HPRaiser(currentPlayer.maxHP, currentPlayer.currentHP);
                }

                if (currentPlayer.Level == 5 && currentPlayer.exp >= 30)
                {
                    Log.Enqueue($"Congrats, you have leveled up to level {currentPlayer.Level + 1}!");
                    currentPlayer.Level = currentPlayer.LevelRaiser(currentPlayer.Level);
                    currentPlayer.exp = currentPlayer.expReset(currentPlayer.exp);
                    currentPlayer.maxHP = currentPlayer.HPRaiser(currentPlayer.maxHP, currentPlayer.currentHP);
                }

                if (currentPlayer.Level == 6 && currentPlayer.exp >= 35)
                {
                    Log.Enqueue($"Congrats, you have leveled up to level {currentPlayer.Level + 1}!");
                    currentPlayer.Level = currentPlayer.LevelRaiser(currentPlayer.Level);
                    currentPlayer.exp = currentPlayer.expReset(currentPlayer.exp);
                    currentPlayer.maxHP = currentPlayer.HPRaiser(currentPlayer.maxHP, currentPlayer.currentHP);
                }

                if (currentVendor != null)
                {
                    if(currentPlayer.X == currentVendor.X && currentPlayer.Y == currentVendor.Y)
                    {
                        Console.SetCursorPosition(0, 17);
                        VendorMenu();
                        
                    }
                }

                if (currentEnemy != null && currentPlayer != null)
                    EnemyMovement(currentPlayer, currentEnemy);

                if (currentEnemy1 != null && currentPlayer != null)
                    EnemyMovement(currentPlayer, currentEnemy1);

                if (currentEnemy2 != null && currentPlayer != null)
                    BossEnemyMovement(currentPlayer, currentEnemy2);

                if (currentEnemy != null && currentPlayer != null)
                {
                    if (currentPlayer.X == currentEnemy.X && currentPlayer.Y == currentEnemy.Y)
                    {
                        Console.SetCursorPosition(0, 17);
                        BattleLoop(currentEnemy);
                        if (enemyDead == true)
                            currentEnemy = null;
                    }
                }

                if (currentEnemy1 != null && currentPlayer != null)
                {
                    if (currentPlayer.X == currentEnemy1.X && currentPlayer.Y == currentEnemy1.Y)
                    {
                        Console.SetCursorPosition(0, 17);
                        BattleLoop(currentEnemy1);
                        if (enemyDead == true)
                            currentEnemy1 = null;
                    }
                }

                if (currentEnemy2 != null && currentPlayer != null)
                {
                    if (currentPlayer.X == currentEnemy2.X + 1 && currentPlayer.Y == currentEnemy2.Y || currentPlayer.X == currentEnemy2.X + 2 && currentPlayer.Y == currentEnemy2.Y || currentPlayer.X == currentEnemy2.X && currentPlayer.Y == currentEnemy2.Y)
                    {
                        Console.SetCursorPosition(0, 17);
                        BattleLoop(currentEnemy2);
                        if (enemyDead == true)
                            currentEnemy2 = null;
                    }
                }

                if (currentLever != null)
                {
                    if (currentPlayer.X == currentLever.X && currentPlayer.Y == currentLever.Y && currentLevel == 6)
                    {
                        SetCLTo6a();
                        currentLever = null;
                    }
                    
                    else if (currentPlayer.X == currentLever.X && currentPlayer.Y == currentLever.Y && currentLevel == 7)
                    {
                        SetCLTo7a();
                        currentLever = null;
                    }
                }

                if(currentEnemy == null)
                    playerCanLeaveLVL = true;

                if (currentEnemy == null && currentEnemy1 == null)
                    playerCanLeaveLVL = true;
            }
        }
    }
}
