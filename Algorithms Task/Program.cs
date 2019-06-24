using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

namespace Algorithms_Task
{
    class Program
    {
        static List<int> ShellList = new List<int>();
        static List<int> InsertionList = new List<int>();
        public static string filePath = @"C:\Users\102051563\source\repos\Algorithms Task\Files\unsorted_numbers.csv";
        static void ShellSortArray()
        {
            string[] array = File.ReadAllLines(filePath);
            foreach(string item in array)
            {
                ShellList.Add(int.Parse(item));
            }
            int[] intArray = ShellList.ToArray();
            ShellSort(intArray);
        }
        
        static void InsertionSortArray()
        {
            string[] array = File.ReadAllLines(filePath);
            foreach (string item in array)
            {
                ShellList.Add(int.Parse(item));
            }
            int[] intArray = ShellList.ToArray();
            InsertionSort(intArray);
        }

        static void ShellSort(int[] intArray)
        {
            int n = intArray.Length;
            int gap = n / 2;
            int temp;

            while(gap > 0)
            {
                for(int i = 0; i + gap < n; i++)
                {
                    int j = i + gap;
                    temp = intArray[j];

                    while(j - gap >= 0 && temp < intArray[j - gap])
                    {
                        intArray[j] = intArray[j - gap];
                        j = j - gap;
                    }
                    intArray[j] = temp;
                }
                gap = gap / 2;
            }
            ShellList = intArray.ToList();
        }

        static void InsertionSort(int[] intArray)
        {
            for(int i = 1; i < intArray.Length; i++)
            {
                int key = intArray[i];
                int j = i - 1;
                while(j >= 0 && intArray[j] > key)
                {
                    intArray[j + 1] = intArray[j];
                    j--;
                }
                intArray[j + 1] = key;
            }
            InsertionList = intArray.ToList();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Shell Sort Begins ");
            DateTime beforeShellSort = DateTime.Now;
            ShellSortArray();
            TimeSpan shellDuration = DateTime.Now - beforeShellSort;
            Console.WriteLine("Shell sort took " + shellDuration.TotalMilliseconds);
            /*foreach (int num in ShellList)
            {
                Console.WriteLine(num);
            }*/
            
            Console.ReadLine();
            Console.WriteLine("Insertion Sort Begins ");
            DateTime beforeInsertSort = DateTime.Now;
            InsertionSortArray();
            TimeSpan insertDuration = DateTime.Now - beforeInsertSort;
            Console.WriteLine("Insertion sort took " + insertDuration.TotalMilliseconds);
            /*foreach (int num in InsertionList)
            {
                Console.WriteLine(num);
            }*/
            Console.WriteLine("Computers are spooky");
            Console.ReadLine();
        }
    }
}
