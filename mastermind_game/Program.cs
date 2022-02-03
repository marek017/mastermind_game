using System;
using System.Linq;

namespace mastermind_game
{
    class Program
    {
        static int[] secretCode;
        static int[] guessedCode;

        static int maxPegs = 6;
        static int codeLenght = 4;
        static bool gameEnd = false;

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Setup();
            //Console.WriteLine("Hello World!");
            do
            {
                ReadCode();
                CheckCode();
            } while (gameEnd);
        }

        private static void Setup()
        {
            Console.WriteLine("Master mind game!/n");
            // generate rand secret code

            do
            {
                int num = rnd.Next(1, maxPegs);
                if(!secretCode.Contains(num))
                    secretCode.Append(num);

            } while (secretCode.Length < codeLenght);
            
        }

        private static void CheckCode()
        {
            //compare codes
        }

        private static void ReadCode()
        {
            Console.WriteLine("Type {0} digit code/n",codeLenght);
            int temp = int.Parse(Console.ReadLine());
            while(temp > 0)
            {
                guessedCode.Append(temp % 10);
                temp /= 10;
            }
            guessedCode.Reverse();
        }
    }
}
