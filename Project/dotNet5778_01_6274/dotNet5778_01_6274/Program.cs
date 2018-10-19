using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_01_6274
{
    class Program
    {

        static void Main(string[] args) 
        {
            int[] myArray;
            myArray = new int[100];
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                myArray[i] = r.Next(0, 1000);
            }

            for (int i = 0; i < myArray.Length; i++) // Sort the array
            {
                for (int j = 0; j < myArray.Length - 1; j++)
                {
                    if (myArray[j] > myArray[j+ 1])
                    {
                        int temp = myArray[j+ 1];
                        myArray[j + 1] = myArray[j];
                        myArray[j] = temp;
                    }
                }
            }

            for (int i = 0; i < 100; i++) // affiche le tableau
            {
                Console.Write(myArray[i]);
                Console.Write(" ");
            }

            Console.WriteLine();
            Console.WriteLine("[1] Guess a number \n[2] Guess an interval \n[3] Exit");

            int choice = 0;
            while (choice != 3)
            {
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        GuessNumber(myArray);
                        break;
                    case 2:
                        GuessNumberWithInterval(myArray);
                        break;
                    case 3:
                        Console.WriteLine("GoodBye");
                        break;
                    default:
                        Console.WriteLine("Not a valid choice");
                        break;
                }
            }


        }
       
        
        static void GuessNumber(int[] myArray)
        {
            int count = 0;
            Console.WriteLine("Enter the number to guess : ");
            int toGuess = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 100; i++)
            {
                if (myArray[i] == toGuess)
                {
                    count++;
                }
            }

            if (count != 0)
            {
                Console.WriteLine("We find the number {0} times", count);
            }
            else
            {
                Console.WriteLine("We didn't find the number");
            }
        } 

        static void GuessNumberWithInterval(int[] myArray)
        {
            Console.Write("What is your interval : \nFirst = ");
            Int32.TryParse(Console.ReadLine(), out int firstInterval);

            Console.Write("Second = ");
            Int32.TryParse(Console.ReadLine(), out int secondInterval);

            Console.Write("How many number do you think there is in this interval");
            Int32.TryParse(Console.ReadLine(), out int guessInTheinter);

            if (secondInterval < firstInterval) //swap
            {
                int tmp = firstInterval;
                firstInterval = secondInterval;
                secondInterval = tmp;
            }

            int countInTheInter = 0;

            for (int i = 0; i < 100; i++)
            {
                if (myArray[i] >= firstInterval && myArray[i] <= secondInterval)
                {
                    countInTheInter++;
                }
            }

            if (countInTheInter == guessInTheinter)
                Console.WriteLine("YES ! You guessed right");
            else
                Console.WriteLine("Oups! You didn't guessed right");
        }
    }
}
