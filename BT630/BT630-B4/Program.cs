using System;
using System.Collections.Generic;

namespace BT630_B4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listInt = new List<int> { 1, 5, 2, 7, 6, 9 };
            
            List<int> listEvenNumber = new List<int>();
            List<int> listOddNumber= new List<int>();
            
            for (int n = 0; n < listInt.Count; n++)
            {
                if (listInt[n] % 2 == 0)
                {
                    listEvenNumber.Add(listInt[n]);
                }
                else
                {
                    listOddNumber.Add(listInt[n]);
                }
            }
            InsertSort(listEvenNumber);
            InsertSort(listOddNumber);

            foreach(int n in listEvenNumber){
                Console.Write(n + " ");
            }
            foreach (int n in listOddNumber)
            {
                Console.Write(n + " ");
            }
        }

        static void InsertSort(List<int> listInt)
        {
            for(int i = 1; i < listInt.Count; i++)
            {
                int j = i - 1;
                int temp = listInt[i];
                while(j >= 0 && temp <= listInt[j])
                {
                    listInt[j + 1] = listInt[j];
                    j--;
                }
                listInt[j + 1] = temp;
            }
        }
    }
}
