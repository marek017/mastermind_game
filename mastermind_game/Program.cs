using System;
using System.Linq;

namespace mastermind_game
{
    class Program
    {
        static readonly int maxPegs = 6;
        static readonly int codeLenght = 4;
        static bool gameEnd = false;

        static int[] secretCode = new int[codeLenght];
        static int[] guessedCode = new int[codeLenght];

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Setup();

            do
            {
                ReadCode();
                CheckCode();
            } while (!gameEnd);

            Console.WriteLine("You have cracked the secret code!");
        }

        private static void Setup()
        {
            Console.WriteLine("Master mind game!\n X - correct location and correct number of peg\n O - wrong locaiton and correct number of peg ");
            int num = rnd.Next(1, maxPegs);
            for (int i = 0; i < codeLenght; i++)
            {
                while(secretCode.Contains(num))
                {
                    num = rnd.Next(1, maxPegs);
                }
                secretCode[i] = num;
            }
        }

        private static void CheckCode()
        {
            if (guessedCode.SequenceEqual(secretCode))
                gameEnd = true;

            string feedback = "";
            for (int i = 0; i < codeLenght; i++)
            {
                if (guessedCode[i] == secretCode[i])
                {
                    feedback += "X";
                    continue;
                }
                if (guessedCode.Contains(secretCode[i]))
                {
                    feedback += "O";
                }
            }
            Console.Write("feedback: {0}\n",feedback);
        }

        private static void ReadCode()
        {
            Console.WriteLine("Type {0} digit code",codeLenght);
            char[] temp = Console.ReadLine().ToCharArray();
            for (int i = 0; i < codeLenght; i++)
            {
                guessedCode[i] = int.Parse(temp[i].ToString());
            }
        }
    }
}
