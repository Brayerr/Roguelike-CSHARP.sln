using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj
{
    class Player
    {
		public int maxHP = 20;
		public int currentHP;
		public int Damage = 3;
		public string Name;
		public float hitChance = 0.8f;
		public float critChance = 0.3f;
		public int critMultyplier = 2;
		public int Gold;
		public int Score;
		public int Level = 1;
		public int exp;
		public int Elixir = 0;		

		public int LevelRaiser(int Level)
        {
			Level++;
			return Level;
        }

		public int expReset(int exp)
        {
			exp = 0;
			return exp;
        }

		public int HPRaiser(int maxHP, int currentHP)
        {
			maxHP += 3;
			return maxHP;
		}

		public bool PlayerHit(float hitChance)
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
			
			if(rand.NextDouble() <= critChance)
            {
				return true;
            }
            else
            {
				return false;
            }
        }

		public bool IsDead(int currentHP)
        {
			if (currentHP <= 0)
				return true;
			else
				return false;
        }

		public int X { get; set; }
		public int Y { get; set; }
		private string PlayerMarker;
		public ConsoleColor PlayerColor;
		

		public Player(int initialX, int initialY)
        {
			X = initialX;
			Y = initialY;
			PlayerMarker = "@";
			PlayerColor = ConsoleColor.Green;
        }

		public void Print()
        {
			Console.ForegroundColor = PlayerColor;
			Console.SetCursorPosition(X, Y);
			Console.Write(PlayerMarker);
			Console.ResetColor();
        }
	}
}
