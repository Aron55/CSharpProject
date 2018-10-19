using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_01b_6274
{
    class Program
    {

        static void Main(string[] args)
        {


            Console.WriteLine("Enter 25 number ");
            int[,] myArray = new int[5, 5];

            for (int i = 0; i < 5; i++) // Input of the array
            {
                for (int j = 0; j < 5; j++)
                {
                    Int32.TryParse(Console.ReadLine(), out myArray[i, j]);
                }
            }


            for (int i = 0; i < 5; i++) // Print the array ( just to check )
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(myArray[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }


            Console.WriteLine(CheckMagicSquare(myArray));


            Console.Read();
        }

        /// <returns>Return a bool for the magic squar</returns>
        static bool CheckMagicSquare(int[,] myArray)
        {
            ///<summary>
            ///J'explique ma variable
            ///</summary>
            int sum = 0;
            int lineSum = 0;
            int coloneSum = 0;
            int firstDiagSum = 0;
            int secondDiagSum = 0;

            for (int j = 0; j < 5; j++) // Initialize the first sum
            {
                sum += myArray[0, j];
                //coloneSum += myArray[j, 0];
            }



            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++) // Do a sum for each line colone and for the two diagonals
                {
                    lineSum += myArray[i, j];
                    coloneSum += myArray[j, i];
                    firstDiagSum += myArray[j, j];
                    secondDiagSum += myArray[j, 4 - j];
                }
                if ((lineSum != sum) || (coloneSum != sum) || (firstDiagSum != sum) || (secondDiagSum != sum)) // If one of the sum isn't equal to the first sum
                    return false;

                //Reinitialize the variable
                lineSum = 0;
                coloneSum = 0;
                firstDiagSum = 0;
                secondDiagSum = 0;
            }
            return true;


        }
    }
}
