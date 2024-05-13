using System;
using System.Security.AccessControl;


class Program
{
    static void bubblesort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    //swap
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    static double[] PrefixAverages1Naive(int[] arr)
    {
        double[] A = new double[arr.Length];
        for (int i = 0;i < arr.Length; i++)
        {
            double sum = 0;
            for(int j = 0;j <= i; j++)
            {
                sum += arr[j];
            }
            A[i] = sum/(i+1);
        }
        return A;
    }
    static double[] PrefixAverages1Optimized(int[]arr)
    {
        double[] A=new double[arr.Length];
        int sum = 0;
        for (int i = 0;i < arr.Length; i++)
        {
            sum += arr[i];
            A[i] = (double)sum/(i+1);
        }
        return A;
    }

    static public long Multiply(int x,int y)
    {
        if (x == 0 || y==0 ) return 0;
        else
        {
            return x+ Multiply(y-1,x);
        }
    }

    static public int findDrop(int[] arr,int n)  
    {
        if (n==1) return arr[0];
    
        int mid = n / 2;
        int leftDrop = findDrop(arr, mid);
        int rightDrop = findDrop(arr[mid..], n - mid);
        return Math.Min(leftDrop, rightDrop);
    }

    static void InsertionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while(j>= 0 && arr[j] > key)
            {
                arr[j+1] = arr[j];
                j--;
            }
            arr[j+1] = key;
        }
    } 

    static int FindPeakElement(int[] arr)
    {
        int left = 0, right = arr.Length - 1;
        while (left < right)
        {
            int mid = left+(right-left)/2;
            if (arr[mid] > arr[mid + 1])
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }
        return arr[left];
    }

    static long Fibonacci(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        long[] fibonacci = new long[n+1];
        fibonacci[0] = 0;
        fibonacci[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
        }
        return fibonacci[n];
    }

    public static void Merge(int[] input, int left, int middle, int right)
    {
        int[] leftArray = new int[middle - left + 1];
        int[] rightArray = new int[right - middle];

        Array.Copy(input, left, leftArray, 0, middle - left + 1);
        Array.Copy(input, middle + 1, rightArray, 0, right - middle);

        int i = 0;
        int j = 0;
        for (int k = left; k < right + 1; k++)
        {
            if (i == leftArray.Length)
            {
                input[k] = rightArray[j];
                j++;
            }
            else if (j == rightArray.Length)
            {
                input[k] = leftArray[i];
                i++;
            }
            else if (leftArray[i] <= rightArray[j])
            {
                input[k] = leftArray[i];
                i++;
            }
            else
            {
                input[k] = rightArray[j];
                j++;
            }
        }
    }

    static  void MergeSort(int[] input,int left,int right)
    {
        if(left < right)
        {
            int middle = (left + right) / 2;
            MergeSort(input, left, middle);
            MergeSort(input,middle +1 , right);
            Merge(input, left, middle, right);
        }
    }

    static void Main(string[] args)
    {
        // Define an array of integers
        int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };

        // Print the original array
        Console.WriteLine("Original Array:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        // Call bubblesort function to sort the array
        bubblesort(numbers);

        // Print the sorted array
        Console.WriteLine("Sorted Array:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
        Console.WriteLine("---------------------------------------");
        int[] nums = {10,20,30,40,50 };
        foreach (int num in nums)
        {
            Console.WriteLine(num + " ");
        }
        Console.WriteLine();
        double[] A = PrefixAverages1Naive(nums);
        foreach (int num in A)
        {
            Console.WriteLine(num + " ");
        }
        Console.WriteLine();
        double[] B = PrefixAverages1Optimized(nums);
        foreach(int num in B)
        {
            Console.WriteLine(num + " ");
        }
        Console.WriteLine();
        Console.WriteLine("---------------------------------------");
        long mult = Multiply(4, 5);
        Console.WriteLine(mult + " ");
        Console.WriteLine("---------------------------------------");
        int[] seq = { 10, 9, 4, 1, 2, 6, 10, 100 };
        int drop = findDrop(seq, 8);
        Console.WriteLine(drop);
        Console.WriteLine("---------------------------------------");
        int[] intz = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        InsertionSort(intz);
        foreach (int item in intz)
        {
            Console.WriteLine(item + " ");
        }
        Console.WriteLine("---------------------------------------");
        int[] arrr = { 1, 3, 5, 7, 9, 11, 10, 8, 6, 4, 2 };
        int peakValue = FindPeakElement(arrr);
        Console.WriteLine(peakValue);
        Console.WriteLine("---------------------------------------");
        Console.WriteLine(Fibonacci(50));
        Console.WriteLine("---------------------------------------");
        int[] inputarr = { 33, 17, 93, 17, 93, 42, 42, 42, 33, 17, 93 };
        MergeSort(inputarr, 0, inputarr.Length - 1);
        foreach(int item in inputarr)
        {
            Console.WriteLine(item + " ");
        }
    }

}
