#define TESTING
using System;

/*
 * STUDENTS: Your answers (your code) goes into this file!!!!
 * 
  * NOTE: In addition to your answers, this file also contains a 'main' method, 
 *      in case you want to run a normal console application.
 * 
 * If you want to / have to put something into 'Main' for these PCEs, then put that 
 * into the Program.Main method that is located below, 
 * then select this project as startup object 
 * (Right-click on the project, then select 'Set As Startup Object'), then run it 
 * just like any other normal, console app: use the menu item Debug->Start Debugging, or 
 * Debug->Start Without Debugging
 * 
 */

namespace PCE_StarterProject
{
	class Program
	{
		static void Main(String[] args)
		{
            Test_Print_Array tpa = new Test_Print_Array();
            tpa.RunExercise();

            //Test_Find_Integer_Linear_Measured tfilm = new Test_Find_Integer_Linear_Measured();
            //tfilm.measure();

            // Test_Find_Integer_Binary_Measured tfibm = new Test_Find_Integer_Binary_Measured();
            // tfibm.measure();
            // tfibm.TestRecursiveBinarySearch();

            // Test_BubbleSort_Measured tbm = new Test_BubbleSort_Measured();
            // tbm.measure();

            // Students: If you want to / have to put something
            // into 'Main' for these PCEs, this is the place to put it :)


            // In the View -> Solution Explorer you can right-click on project 03,
            // then select "Set As Startup Project" in order to run this code as
            // a console application
            QuickOverviewOfOutParameters qooop = new QuickOverviewOfOutParameters();
			int num1 = 10;
			Console.WriteLine("Normal Parameters: =============");
			Console.WriteLine("PRE  num1 is: {0}", num1);
			qooop.NormalParam(num1);
			Console.WriteLine("POST num1 is: {0}", num1); // notice that num1 hasn't changed

			Console.WriteLine("Out Parameters: ================");
			Console.WriteLine("PRE  num1 is: {0}", num1);
			qooop.OutParam(out num1);
			Console.WriteLine("POST num1 is: {0}", num1); // notice that num1 HAS changed

		}
	}

	public class Test_Print_Array
	{
		public void RunExercise()
		{
            SearchingAndSorting ase = new SearchingAndSorting();

            int[] i = { 10, 1, 12, 3, 9, 32, 36 };

           // int test = 32;
            int comparison = 0;
            int swaps = 0;

            //if (ase.FindIntegerLinearPerfMeasured(test, i,out comparison) == false)
            //    Console.WriteLine("Not, after {0} comparisons",comparison);
            //if (ase.FindIntegerLinearPerfMeasured(test, i,out comparison) == true)
            //    Console.WriteLine("Is in, after {0} comparisons",comparison);

           // ase.FindIntegerBinaryPerfMeasured(test, i, out comparison);
            
            
            // ase.BubbleSort(i);
            ase.BubbleSortPerfMeasured(i, out swaps, out comparison);



        }
	}

	public class Analyzing_Algorithms
	{
		// put your output here, in a comment:
	}

public class QuickOverviewOfOutParameters
{
	public void NormalParam(int x)
	{
		Console.WriteLine("PRE  x is: {0}", x);
		x = 20;
		Console.WriteLine("POST x is: {0}", x);
	}

	public void OutParam(out int x)
	{
		// we're not allowed to use an out parameter until we give it a 
		//      starting value.  
		// Try to uncomment the next line, and notice the compiler error you get
		// Console.WriteLine("PRE  x is: {0}", x);
		x = 0; // starting value assigned here

		x = 20; // notice that this changes the param here AND the "num1" back in main!
		Console.WriteLine("POST x is: {0}", x);
	}
}

	// This is now UNcommented, so it compiles ok as soon as you've downloaded it.
	public class SearchingAndSorting
	{
        public void printArray(int[] nums)
        {
            Console.WriteLine("The array is " + nums.Length + "integers long!");

            for (int i = 0; i < nums.Length; i++)
                Console.WriteLine(nums[i]);

        }


        public bool FindIntegerLinear(int target, int[] array)
		{
            bool x = false;
            for(int i =0; i<array.Length;i++)
            {
                if(target == array[i])
                {
                    x = true;
                    break;
                }
               if (target != array[i])
                {
                    x = false;
                }
            }
            return x;
        }

		public bool FindIntegerBinary(int target,
					int[] array)
		{
            int min = 0;
            int max = array.Length - 1;
            int half;


            while(min<=max)
            {
               half = (min + max) / 2;
                if (array[half]==target)
                {
                    return true;
                    //break;
                }
               else if (array[half]<target)
                {
                    min = half + 1 ;
                    continue;
                }
                else if(array[half]>target)
                {
                    max = half - 1;
                    continue;
                }

            }
            return false;
        }

		public bool FindIntegerBinaryRecursive(int target,
								int[] array)
		{
			FindIntegerBinaryRecursive(target, array, 0, array.Length - 1);
			return false;
		}

		private bool FindIntegerBinaryRecursive(int target,
												int[] array,
												int lowestIndex,
												int highestIndex)
		{
			FindIntegerBinaryRecursive(target, array, lowestIndex + 1, highestIndex - 1);
			return false;
		}

		public bool FindIntegerLinearPerfMeasured(int target, int[] array, out int numComparisons)
		{
			// Your code goes here.
			numComparisons = 0;
            bool x = false;
            for (int i = 0; i < array.Length; i++)
            {
                numComparisons++;
                if (target == array[i])
                {
                    x = true;
                    break;
                }
                if (target != array[i])
                {
                    x = false;
                }
             
            }
            return x;
        }
    

		public bool FindIntegerBinaryPerfMeasured(int target,
				int[] array, out int numComparisons)
		{
			numComparisons = 0;
            int min = 0;
            int max = array.Length - 1;
            int half;


            while (min <= max)
            {
                numComparisons++;
                half = (min + max) / 2;
                if (array[half] == target)
                {
                    return true;
                    //break;
                }
                else if (array[half] < target)
                {
                    min = half + 1;
                    continue;
                }
                else if (array[half] > target)
                {
                    max = half - 1;
                    continue;
                }

            }
            return false;
        }

        public void BubbleSort(int[] nums)
        {
            int shelf = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length-1; j++)
                {
                    if (nums[j+1] < nums[j])
                    {
                        shelf = nums[j+1];
                        nums[j + 1] = nums[j];
                        nums[j] = shelf;
                    }
                }
                Console.WriteLine("{0}",nums[i]);
            }
        }

		public void BubbleSortPerfMeasured(int[] nums, out int numSwaps, out int numComparisons)
		{
            int shelf=0;
            int swaps = numSwaps=0;
            int compare = numComparisons = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length - 1; j++)
                {
                    if (nums[j + 1] < nums[j])
                    {
                        shelf = nums[j + 1];
                        nums[j + 1] = nums[j];
                        nums[j] = shelf;
                        swaps++;
                    }
                    compare++;
                }
                Console.WriteLine("{0}", nums[i]);
            }
            Console.WriteLine("Number of swaps: {0}\n Number of Comparisons: {1}", swaps, compare);
        }
    }

	public class Test_Find_Integer_Linear_Measured
	{
		public void measure()
		{
			SearchingAndSorting sas = new SearchingAndSorting();

			Console.WriteLine("\n\n\t\tLINEAR SEARCH PERFORMANCE TESTING!\n\n");
			Random r = new Random();
			for (int i = 1; i < 5; i++)
			{
				int arraySize = i * i * 100;

				int[] nums = new int[arraySize];
				for (int j = 0; j < arraySize; j++)
				{	// give each element a random starting value.
					nums[j] = r.Next(arraySize);
				}

				// we want to first get a reading on how many comparisons are
				// needed when we're looking for something in the array.
				// So we'll randomly pick an element out of the array,
				// and search for it.  Lather, rinse, repeat 100 times.
				int totalComps = 0;
				int numComps;
				for (int j = 0; j < 10000; j++)
				{
					int target = nums[r.Next(arraySize)];
					if (!sas.FindIntegerLinearPerfMeasured(target, nums, out numComps))
						Console.WriteLine("ERROR: COULDN'T find " + target + " despite it's presence");
					totalComps += numComps;
				}
				double aveFound = totalComps / 10000.0;	// Average number of comparisons per search

				// next, we want to get a reading on how many comparisons are
				// needed when we're looking for something NOT in the array.
				// So we'll randomly pick a value we know is NOT in the array,
				// and search for it.  Lather, rinse, repeat 100 times.
				totalComps = 0;
				for (int j = 0; j < 10000; j++)
				{
					if (sas.FindIntegerLinearPerfMeasured(arraySize + 10, nums, out numComps))
						Console.WriteLine("ERROR: COULD find " + (arraySize + 10) + " despite it's presence");
					totalComps += numComps;
				}
				double aveNotFound = totalComps / 10000.0;	// Average number of comparisons per search
				Console.WriteLine("For an array of " + arraySize + " elements, the average number of comparisons when:\n\tthe element was present: " + aveFound + "\n\tthe element was NOT present: " + aveNotFound);
			}
		}
	}

	public class Test_Find_Integer_Binary_Measured
	{
		public void measure()
		{
			SearchingAndSorting sas = new SearchingAndSorting();

			Console.WriteLine("\n\n\t\tBINARY SEARCH PERFORMANCE TESTING!\n\n");

			Random r = new Random();
			for (int i = 1; i < 5; i++)
			{
				int arraySize = i * i * 100;

				int[] nums = new int[arraySize];
				for (int j = 0; j < arraySize; j++)
				{	// give each element a random starting value.
					nums[j] = r.Next(arraySize);
				}
				Array.Sort(nums); // binary search only works on sorted arrays, so sort it...

				// we want to first get a reading on how many comparisons are
				// needed when we're looking for something in the array.
				// So we'll randomly pick an element out of the array,
				// and search for it.  Lather, rinse, repeat a zillioni times.
				int totalComps = 0;
				int numComps;
				for (int j = 0; j < 10000; j++)
				{
					int target = nums[r.Next(arraySize)];
					if (!sas.FindIntegerBinaryPerfMeasured(target, nums, out numComps))
						Console.WriteLine("ERROR: COULDN'T find " + target + " despite it's presence");
					totalComps += numComps;
				}
				double aveFound = totalComps / 10000.0;	// Average number of comparisons per search

				// next, we want to get a reading on how many comparisons are
				// needed when we're looking for something NOT in the array.
				// So we'll randomly pick a value we know is NOT in the array,
				// and search for it.  Lather, rinse, repeat a zillion more times.
				totalComps = 0;
				for (int j = 0; j < 10000; j++)
				{
					if (sas.FindIntegerBinaryPerfMeasured(arraySize + 10, nums, out numComps))
						Console.WriteLine("ERROR: COULD find " + (arraySize + 10) + " despite it's presence");
					totalComps += numComps;
				}
				double aveNotFound = totalComps / 10000.0;	// Average number of comparisons per search
				Console.WriteLine("For an array of " + arraySize + " elements, the average number of comparisons when:\n\tthe element was present: " + aveFound + "\n\tthe element was NOT present: " + aveNotFound);
			}
		}

		public void TestRecursiveBinarySearch()
		{
			// Create an array, and call binary search (recursive) on it, until you're
			// convinced that it works ok.
		}
	}

	public class Test_BubbleSort_Measured
	{
		public void measure()
		{
			Console.WriteLine("\n\n\t\tBUBBLE SORT PERFORMANCE TESTING!\n\n");

			Random r = new Random();
			SearchingAndSorting sas = new SearchingAndSorting();

			double totalComps = 0;
			int compsThisTime = 0;

			double totalSwaps = 0;
			int swapsThisTime = 0;

			for (int i = 1; i < 5; i++)
			{
				int arraySize = i * i * 100;
				totalComps = 0;

				// repeat 1000 times: create an unsorted array, and sort it.
				int numTimes = 2;
				for (int j = 0; j < numTimes; j++)
				{
					int[] nums = new int[arraySize];
					for (int k = 0; k < arraySize; k++)
					{	// give each element a random starting value.
						nums[k] = r.Next(arraySize);
					}

					sas.BubbleSortPerfMeasured(nums, out swapsThisTime, out compsThisTime);
					totalComps += compsThisTime;
					totalSwaps += swapsThisTime;
				}
				Console.WriteLine("For an array of " + arraySize + " elements, there were an average of " + totalComps / numTimes + " comparisons performed, and an average of " + totalSwaps / numTimes + "swaps performed");
			}
		}
	}
}