using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj
{
    class Enemy
    {
        public string Name;
        public int HP;
        public int Damage;
        public float hitChance = .5f;
        public float critChance = .3f;
        public int critMultyplier = 2;

        public int X { get; set; }
        public int Y { get; set; }
        private string EnemyMarker;
        public ConsoleColor EnemyColor;


        public Enemy(string name, string marker,int hp, int damage, int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            Name = name;
            HP = hp;
            Damage = damage;
            EnemyMarker = marker;
            EnemyColor = ConsoleColor.Red;
        }        

        public void Print()
        {
            Console.ForegroundColor = EnemyColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(EnemyMarker);
            Console.ResetColor();
        }

        public bool EnemyHit(float hitChance)
        {
            Random rand = new Random();

            if (rand.NextDouble() <= hitChance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CriticalHit(float critChance)
        {
            Random rand = new Random();

            if (rand.NextDouble() <= critChance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
