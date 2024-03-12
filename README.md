example output 

```

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): not
Enter Hex value between 00 and FF: a5
Result of NOT [1; 0; 1; 0; 0; 1; 0; 1] = [0; 1; 0; 1; 1; 0; 1; 0] = 5A

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): and
Enter Hex value between 00 and FF: f9
Enter Hex value between 00 and FF: 9f
         [1; 1; 1; 1; 1; 0; 0; 1] = F9
AND      [1; 0; 0; 1; 1; 1; 1; 1] = 9F
--------------------------------------------
         [1; 0; 0; 1; 1; 0; 0; 1] = 99

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): or
Enter Hex value between 00 and FF: 01
Enter Hex value between 00 and FF: 11
         [0; 0; 0; 0; 0; 0; 0; 1] = 1
OR       [0; 0; 0; 1; 0; 0; 0; 1] = 11
--------------------------------------------
         [0; 0; 0; 1; 0; 0; 0; 1] = 11

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): xor
Enter Hex value between 00 and FF: ff
Enter Hex value between 00 and FF: 88
         [1; 1; 1; 1; 1; 1; 1; 1] = FF
XOR      [1; 0; 0; 0; 1; 0; 0; 0] = 88
--------------------------------------------
         [0; 1; 1; 1; 0; 1; 1; 1] = 77

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter a number between -128 and 127: 121
Enter a number between -128 and 127: 6
         [0; 1; 1; 1; 1; 0; 0; 1] = 121
ADD      [0; 0; 0; 0; 0; 1; 1; 0] = 6
--------------------------------------------
         [0; 1; 1; 1; 1; 1; 1; 1] = 127

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter a number between -128 and 127: 121
Enter a number between -128 and 127: -6
         [0; 1; 1; 1; 1; 0; 0; 1] = 121
ADD      [1; 1; 1; 1; 1; 0; 1; 0] = -6
--------------------------------------------
         [0; 1; 1; 1; 0; 0; 1; 1] = 115

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): sub
Enter a number between -128 and 127: 5
Enter a number between -128 and 127: 5
         [0; 0; 0; 0; 0; 1; 0; 1] = 5
SUB      [0; 0; 0; 0; 0; 1; 0; 1] = 5
--------------------------------------------
         [0; 0; 0; 0; 0; 0; 0; 0] = 0

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): sub
Enter a number between -128 and 127: 5
Enter a number between -128 and 127: -5
         [0; 0; 0; 0; 0; 1; 0; 1] = 5
SUB      [1; 1; 1; 1; 1; 0; 1; 1] = -5
--------------------------------------------
         [0; 0; 0; 0; 1; 0; 1; 0] = 10

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter a number between -128 and 127: 64
Enter a number between -128 and 127: 64
         [0; 1; 0; 0; 0; 0; 0; 0] = 64
ADD      [0; 1; 0; 0; 0; 0; 0; 0] = 64
--------------------------------------------
         [1; 0; 0; 0; 0; 0; 0; 0] = -128

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): sub
Enter a number between -128 and 127: 10
Enter a number between -128 and 127: 11
         [0; 0; 0; 0; 1; 0; 1; 0] = 10
SUB      [0; 0; 0; 0; 1; 0; 1; 1] = 11
--------------------------------------------
         [1; 1; 1; 1; 1; 1; 1; 1] = -1

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter a number between -128 and 127: 128
Enter a number between -128 and 127: 1
         [1; 0; 0; 0; 0; 0; 0; 0] = -128
ADD      [0; 0; 0; 0; 0; 0; 0; 1] = 1
--------------------------------------------
         [1; 0; 0; 0; 0; 0; 0; 1] = -127
```

I was just having fun with overflow(??) here, since we only go from -128 to 127 it seems to loop back on itself 
when you go over or below those numbers... interesting :)  this is from a sligly earlier version of the program 

```

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): sub
Enter first number : -128
Enter second number: 1
         [1; 0; 0; 0; 0; 0; 0; 0]
SUB      [0; 0; 0; 0; 0; 0; 0; 1]
--------------------------------------------
         [0; 1; 1; 1; 1; 1; 1; 1] = 127

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter first number : 127
Enter second number: 2
         [0; 1; 1; 1; 1; 1; 1; 1]
ADD      [0; 0; 0; 0; 0; 0; 1; 0]
--------------------------------------------
         [1; 0; 0; 0; 0; 0; 0; 1] = -127

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter first number : 127
Enter second number: 3
         [0; 1; 1; 1; 1; 1; 1; 1]
ADD      [0; 0; 0; 0; 0; 0; 1; 1]
--------------------------------------------
         [1; 0; 0; 0; 0; 0; 1; 0] = -126

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter first number : 127
Enter second number: 4
         [0; 1; 1; 1; 1; 1; 1; 1]
ADD      [0; 0; 0; 0; 0; 1; 0; 0]
--------------------------------------------
         [1; 0; 0; 0; 0; 0; 1; 1] = -125

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): q
GOOD BYE!!
```

A little more for no particular reason

```
Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): not
Enter Hex value: 45
Result of NOT [0; 1; 0; 0; 0; 1; 0; 1] = [1; 0; 1; 1; 1; 0; 1; 0] = BA

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): or
Enter Hex value: 56
Enter Hex value: 77
         [0; 1; 0; 1; 0; 1; 1; 0]
OR       [0; 1; 1; 1; 0; 1; 1; 1]
--------------------------------------------
         [0; 1; 1; 1; 0; 1; 1; 1] = 77

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): AND
Enter Hex value: 56
Enter Hex value: 77
         [0; 1; 0; 1; 0; 1; 1; 0]
AND      [0; 1; 1; 1; 0; 1; 1; 1]
--------------------------------------------
         [0; 1; 0; 1; 0; 1; 1; 0] = 56

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): xor
Enter Hex value: 56
Enter Hex value: 77
         [0; 1; 0; 1; 0; 1; 1; 0]
XOR      [0; 1; 1; 1; 0; 1; 1; 1]
--------------------------------------------
         [0; 0; 1; 0; 0; 0; 0; 1] = 21

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter first number : -5
Enter second number: 99
         [1; 1; 1; 1; 1; 0; 1; 1]
ADD      [0; 1; 1; 0; 0; 0; 1; 1]
--------------------------------------------
         [0; 1; 0; 1; 1; 1; 1; 0] = 94

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): sub
Enter first number : 5
Enter second number: -99
         [0; 0; 0; 0; 0; 1; 0; 1]
SUB      [1; 0; 0; 1; 1; 1; 0; 1]
--------------------------------------------
         [0; 1; 1; 0; 1; 0; 0; 0] = 104

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): q
GOOD BYE!!
```
