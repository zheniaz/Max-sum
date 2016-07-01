using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TriangleMaxSum
{
    class Program
    {
        static int[,] lowerTriangularMatrix;
        static List<string> strReader = new List<string>();
        static List<int> itemList = new List<int>();
        static int stringCount = 0;
        static string[] fileStr = { "exampleTest.txt", "smallTriangle.txt", "bonusMaxSum.txt" };

        //create  lower triangular matrix
        static void CreateMatrix()
        {
            for (int i = 0, eqNullCount = 1; i < stringCount; i++, eqNullCount++)
            {
                string[] strItem = strReader[i].Split(' ');
                for (int con = 0; con < strItem.Length; con++)
                {
                    itemList.Add(Convert.ToInt32(strItem[con]));
                }


                for (int j = 0; j < stringCount; j++)
                {
                    if (j < eqNullCount)
                        lowerTriangularMatrix[i, j] = itemList[j];
                    else
                        lowerTriangularMatrix[i, j] = 0;
                }

                itemList.Clear();

            }
            strReader.Clear();
        }

        //show matrix
        static void ShowMatrix()
        {
            for (int i = 0; i < stringCount; i++)
            {
                for (int j = 0; j < stringCount; j++)
                {
                    Console.Write(lowerTriangularMatrix[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }

        // max sum
        static void MaxSum(string fileName)
        {
            int actualIndexValue = 0;
            int maxSum = lowerTriangularMatrix[0, 0];
            Console.WriteLine("Max sum of {0}: \n", fileName);

            Console.Write(lowerTriangularMatrix[0, 0]);
            for (int i = 1; i < stringCount; i++)
            {
                if (lowerTriangularMatrix[i, actualIndexValue] > lowerTriangularMatrix[i, actualIndexValue + 1])
                {
                    maxSum += lowerTriangularMatrix[i, actualIndexValue];
                    Console.Write(" + " + lowerTriangularMatrix[i, actualIndexValue]);

                }
                else
                {
                    maxSum += lowerTriangularMatrix[i, actualIndexValue + 1];
                    Console.Write(" + " + lowerTriangularMatrix[i, actualIndexValue + 1]);
                    actualIndexValue++;
                }
            }
            Console.Write(" = {0}\n\n", maxSum);
            stringCount = 0;
        }


        static void Main(string[] args)
        {
            foreach (var item in fileStr)
            {
                using (FileStream filestream = new FileStream(item, FileMode.Open))
                {
                    StreamReader streamReader = new StreamReader(filestream);

                    //read from the file
                    while (!streamReader.EndOfStream)
                    {
                        strReader.Add(streamReader.ReadLine().ToString());
                        stringCount++;
                    }
                    streamReader.Dispose();
                    streamReader.Close();
                    lowerTriangularMatrix = new int[stringCount, stringCount];

                    //create   matrix
                    CreateMatrix();

                    //show matrix
                    //ShowMatrix();

                    //max sum
                    MaxSum(item);


                }
            }
            Console.Read();
        }
    }
}
