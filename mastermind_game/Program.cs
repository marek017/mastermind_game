using System;
using System.Linq;

namespace mastermind_game
{
    class Program
    {
        static int maxPegs = 6;
        static int codeLenght = 4;
        static bool gameEnd = false;

        static int[] secretCode = new int[codeLenght];
        static int[] guessedCode = new int[codeLenght];

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

            Console.WriteLine("You have breaked the secret code! " + secretCode.ToString());
        }

        private static void Setup()
        {
            Console.WriteLine("Master mind game!\n");
            //TODO: fix code generation
            do
            {
                int num = rnd.Next(1, maxPegs);
                if(!secretCode.Contains(num))
                    secretCode.Append(num);
                Console.WriteLine(num);

            } while (secretCode.Length < codeLenght);
            
        }

        private static void CheckCode()
        {
            string feedback = "";
            int correctPeg = 0; 
            int guessedPeg = 0;

            if (guessedCode.SequenceEqual(secretCode))
                gameEnd = true;

            for (int i =01; i < codeLenght-1; i++)
            {
                if (guessedCode[i].Equals(secretCode[i]))
                    correctPeg++;
                else if (guessedCode.Contains(secretCode[i]))
                    guessedPeg++;
            }

            for (int i = 0; i <= correctPeg; i++)
            {
                feedback += "Ø";
            }

            for (int i = 0; i <= guessedPeg; i++)
            {
                feedback += "O";
            }

            Console.Write(" feedback: " + feedback);
        }

        private static void ReadCode()
        {
            Console.WriteLine("Type {0} digit code\n",codeLenght);
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
