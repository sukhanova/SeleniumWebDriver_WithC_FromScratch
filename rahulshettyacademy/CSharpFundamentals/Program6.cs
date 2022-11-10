using System;
using System.Collections;


// array has a size declaired at creation
// ArrayList - use for dynamic list of elements

ArrayList arr = new ArrayList();
arr.Add("pear");
arr.Add("apple");
arr.Add("kiwi");
arr.Add("grape");
int counter = 0;


Console.WriteLine(arr); //prints System.Collections.ArrayList
Console.WriteLine(arr[1]); //prints pear

foreach (String item in arr)
{
    counter++;
    Console.WriteLine($"Item #{counter} is: {item}");
}


Console.WriteLine(arr.Contains("pear")); // true
Console.WriteLine(arr.Contains("Pear")); // false

Console.WriteLine();
// sort items in arrayList
Console.WriteLine("ArrayList after sorting");
arr.Sort();
foreach (String item in arr)
{
    counter++;
    Console.WriteLine($"Item #{counter} is: {item}");
}

