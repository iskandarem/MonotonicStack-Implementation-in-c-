// See https://aka.ms/new-console-template for more information
using MonotonicStack;
int[] v = { 1, 2, 3, 8, 5, 6, 7, 8, 1 };
var monotonicStack = new MonotonicStack<int>(v, false);

while (!monotonicStack.Empty())
    Console.WriteLine(monotonicStack.Pop());



