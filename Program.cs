using System;

class Program
{
    static bool FindPairWithSum(int[] S, int x)
    {
        // Step 1: Sort the array
        Array.Sort(S);  // O(n log n)
        
        // Step 2: Initialize two pointers
        int left = 0;
        int right = S.Length - 1;
        
        // Step 3: Use two-pointer technique to find the pair
        while (left < right)
        {
            int currentSum = S[left] + S[right];
            
            if (currentSum == x)
                return true;
            else if (currentSum < x)
                left++;  // Move left pointer to increase sum
            else
                right--; // Move right pointer to decrease sum
        }
        
        return false;  // No pair found
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



