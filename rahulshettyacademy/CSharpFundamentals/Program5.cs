using System;
using System.Collections.Generic;


// array stores collection of elements
String[] stringArray = { "hello", "there", "Oliver", "Doe" };
int[] intArray = { 1, 2, 3, 4, 5 };
String[] a1 = new String[4];
Console.WriteLine(a1.Length);

a1[0] = "apple";
a1[1] = "pear";

// prints array type
Console.WriteLine(a1);

// prints all content of array
Array.ForEach(a1, Console.WriteLine);

for (var i = 0; i < a1.Length; i++) {
    if(a1[i] != null)
    {
        Console.WriteLine($"Array item #{i+1}: is {a1[i]}");
    }
    

}
