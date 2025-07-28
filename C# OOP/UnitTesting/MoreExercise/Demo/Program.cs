











using Collections;
using System;

int[] array = { 1, 2, 3, 4 };
Collection<int> collection = new(array);

Console.WriteLine(collection);
Console.WriteLine($"[{string.Join(", ", array)}]");