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
        static List<int> items = new List<int>();
        static List<int> end = new List<int>();
        public static string filePath = @"C:\Users\102051563\source\repos\AlgorithmsTask\Files\unsorted_numbers.csv";
        //int[] fileNums;
        static int[] readFile(string filePath)
        {
            List<int> Nums = new List<int>();
            string[] array = File.ReadAllLines(filePath);
            foreach (string item in array)
            {
                Nums.Add(int.Parse(item));
            }
            return Nums.ToArray();
        }

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

        static List<int> LinearSearch()
        {
            int count = 0;
            
            int[] linNumbers = readFile(filePath);
            ShellSort(linNumbers);

            int n = linNumbers.Length;
            for(int i = 0; i < n; i++)
            {
                if(count == 1500)
                {
                    count = 0;
                    items.Add(linNumbers[i]);
                }
                if(linNumbers[i] == linNumbers.Max())
                {
                    items.Add(linNumbers[i]);
                }
                count++;
                
            }

            return items;
        }

        static List<int> BinarySearch()
        {
            //List<int> end = new List<int>();
            int bindex = 1500;
            int[] binNumbers = readFile(filePath);
            ShellSort(binNumbers);
            int n = binNumbers.Length;
            //int max = binNumbers.Max();
            while (bindex < 15000)
            {
                int index = Array.BinarySearch(binNumbers, binNumbers[bindex]);
                end.Add(binNumbers[index]);
                bindex += 1500;

            }
            int lindex = Array.BinarySearch(binNumbers, binNumbers.Max());
            end.Add(binNumbers[lindex]);

            return end;
        }
        //List<int> list = new List<int>
        //BinarySearchold() = result
        //list.add(result)
        static List<int> BinarySearchold()
        {
            
            int[] binNums = readFile(filePath);
            ShellSort(binNums);
            int target = binNums.Max();
            int min = 0;
            int max = binNums.Length - 1;
            bool finished = false;
            //while (!finished){}

            int bindex = 1500;
            while (bindex < 15000)
            {
                int index = Array.BinarySearch(binNums, binNums[bindex]);
                end.Add(binNums[index]);
                bindex += 1500;

            }
            //int lindex = Array.BinarySearch(binNums, binNums.Max());
            //end.Add(binNums[lindex]);
            while (!finished)
            {
                if (min <= max)
                {
                    int mid = (min + max) / 2;
                    if (target == binNums[mid])
                    {
                        //return ++mid;
                        end.Add(binNums[mid]);
                        finished = true;
                    }
                    else if (target < binNums[mid])
                    {
                        max = mid - 1;
                    }
                    else if (target > binNums[mid])
                    {
                        min = mid + 1;
                    }
                }
                else
                {
                    finished = true;
                }
            }
            return end;
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
            DateTime beforeLinear = DateTime.Now;
            LinearSearch();
            TimeSpan LinearDuration = DateTime.Now - beforeLinear;
            foreach(int num in items)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("Linear Search took " + LinearDuration.TotalMilliseconds);
            Console.ReadLine();
            DateTime beforeBinary = DateTime.Now;
            BinarySearchold();
            TimeSpan BinaryDuration = DateTime.Now - beforeBinary;
            foreach(int binNum in end)
            {
                Console.WriteLine(binNum);
            }
            Console.WriteLine("Binary Search took " + BinaryDuration.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
