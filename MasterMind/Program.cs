using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> randomList = new List<int>();
            Random num = new Random();
            for(int i = 0; i < 4; i++)
            {
                randomList.Add(num.Next(1, 7));
            }
          
            string randomNumber = string.Empty;
            foreach (int rnum in randomList)
            {
                randomNumber += rnum;
            }

            bool correct = false;

            for(int i = 0; i<10;i++)
            {
                string output = string.Empty;
                string plusOut = string.Empty;
                string minusOut = string.Empty;
                Console.WriteLine("Enter 4 digit number - you have 10 guesses - Guess no:" + (i+1));
                string inputString = Console.ReadLine();
                List<char> charString = inputString.ToList();
                List<int> inputIntNumber = new List<int>();
                foreach (char c in charString)
                {
                  inputIntNumber.Add(Convert.ToInt32(c) - 48);
                }
                for (int j = 0; j < inputIntNumber.Count; j++)
                {
                    if (j < 4 && inputIntNumber[j] == randomList[j])
                    {
                        plusOut += "+";
                    }

                    if (randomList.Contains(inputIntNumber[j]) && !(j < 4 && inputIntNumber[j] == randomList[j]))
                    {
                        minusOut += "-";
                    }
                }

                output = plusOut + minusOut;
                Console.WriteLine(output);
                if (output == "++++")
                {
                    correct = true;
                    break;
                }
            }

           Console.WriteLine("Number is " + randomNumber);
            if (correct)
                Console.WriteLine("You won");
            else
                Console.WriteLine("You lost. 10 chances over.");

            Console.Read();

        }
    }
}
