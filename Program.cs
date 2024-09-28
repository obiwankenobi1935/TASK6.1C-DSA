using System;


class Program
{
    static bool FindPairWithSum(int[] S, int x)
    {
        MergeSort(S, 0, S.Length - 1);  // Sorting using Merge Sort
        
        int left = 0;
        int right = S.Length - 1;
        
        while (left < right)
        {
            int currentSum = S[left] + S[right];
            
            if (currentSum == x)
                return true;
            else if (currentSum < x)
                left++;
            else
                right--;
        }
        
        return false;
    }

    // Merge Sort Algorithm (O(n log n))
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];
        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + 1 + j];

        int i1 = 0, j1 = 0, k = left;

        while (i1 < n1 && j1 < n2)
        {
            if (L[i1] <= R[j1])
            {
                arr[k] = L[i1];
                i1++;
            }
            else
            {
                arr[k] = R[j1];
                j1++;
            }
            k++;
        }

        while (i1 < n1)
        {
            arr[k] = L[i1];
            i1++;
            k++;
        }

        while (j1 < n2)
        {
            arr[k] = R[j1];
            j1++;
            k++;
        }
    }

    static void Main()
    {
        int[] S = { 10, 15, 3, 7 };
        int x = 17;
        
        bool result = FindPairWithSum(S, x);
        Console.WriteLine(result ? "Pair found" : "No pair found");
    }
}



class MinStack
{
    private Stack<int> stack;      // Regular stack for push and pop
    private Stack<int> minStack;   // Auxiliary stack to track minimum values
    
    public MinStack()
    {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }
    
    // Push operation
    public void Push(int x)
    {
        stack.Push(x);
        
        // If the minStack is empty or the current element is smaller or equal
        // to the top of the minStack, push it to the minStack
        if (minStack.Count == 0 || x <= minStack.Peek())
        {
            minStack.Push(x);
        }
    }
    
    // Pop operation
    public void Pop()
    {
        if (stack.Count == 0) throw new InvalidOperationException("Stack is empty.");
        
        int popped = stack.Pop();
        
        // If the popped element is the current minimum, pop it from the minStack as well
        if (popped == minStack.Peek())
        {
            minStack.Pop();
        }
    }
    
    // Min operation
    public int Min()
    {
        if (minStack.Count == 0) throw new InvalidOperationException("Stack is empty.");
        return minStack.Peek();  // Return the current minimum element
    }
    
    static void Main()
    {
        MinStack minStack = new MinStack();
        
        minStack.Push(5);
        minStack.Push(2);
        minStack.Push(3);
        Console.WriteLine("Current Min: " + minStack.Min());  // Output: 2
        
        minStack.Pop();  // Popping 3
        Console.WriteLine("Current Min: " + minStack.Min());  // Output: 2
        
        minStack.Pop();  // Popping 2
        Console.WriteLine("Current Min: " + minStack.Min());  // Output: 5
    }
}



