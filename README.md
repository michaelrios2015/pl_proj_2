example output 

```
Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): not
Enter Hex value: A5
Result of NOT [1; 0; 1; 0; 0; 1; 0; 1] = [0; 1; 0; 1; 1; 0; 1; 0] = 5A

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): not
Enter Hex value: 00
Result of NOT [0; 0; 0; 0; 0; 0; 0; 0] = [1; 1; 1; 1; 1; 1; 1; 1] = FF

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): and
Enter Hex value: F9
Enter Hex value: 9f
         [1; 1; 1; 1; 1; 0; 0; 1]
AND      [1; 0; 0; 1; 1; 1; 1; 1]
--------------------------------------------
         [1; 0; 0; 1; 1; 0; 0; 1] = 99

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): and
Enter Hex value: 11
Enter Hex value: 33
         [0; 0; 0; 1; 0; 0; 0; 1]
AND      [0; 0; 1; 1; 0; 0; 1; 1]
--------------------------------------------
         [0; 0; 0; 1; 0; 0; 0; 1] = 11

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): or
Enter Hex value: 01
Enter Hex value: 11
         [0; 0; 0; 0; 0; 0; 0; 1]
OR       [0; 0; 0; 1; 0; 0; 0; 1]
--------------------------------------------
         [0; 0; 0; 1; 0; 0; 0; 1] = 11

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): or
Enter Hex value: 45
Enter Hex value: ee
         [0; 1; 0; 0; 0; 1; 0; 1]
OR       [1; 1; 1; 0; 1; 1; 1; 0]
--------------------------------------------
         [1; 1; 1; 0; 1; 1; 1; 1] = EF

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): xor
Enter Hex value: ff
Enter Hex value: 88
         [1; 1; 1; 1; 1; 1; 1; 1]
XOR      [1; 0; 0; 0; 1; 0; 0; 0]
--------------------------------------------
         [0; 1; 1; 1; 0; 1; 1; 1] = 77

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): xor
Enter Hex value: 13
Enter Hex value: 74
         [0; 0; 0; 1; 0; 0; 1; 1]
XOR      [0; 1; 1; 1; 0; 1; 0; 0]
--------------------------------------------
         [0; 1; 1; 0; 0; 1; 1; 1] = 67

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter first number : 121
Enter second number: 6
         [0; 1; 1; 1; 1; 0; 0; 1]
ADD      [0; 0; 0; 0; 0; 1; 1; 0]
--------------------------------------------
         [0; 1; 1; 1; 1; 1; 1; 1] = 127

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter first number : 121
Enter second number: -6
         [0; 1; 1; 1; 1; 0; 0; 1]
ADD      [1; 1; 1; 1; 1; 0; 1; 0]
--------------------------------------------
         [0; 1; 1; 1; 0; 0; 1; 1] = 115

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter first number : 3
Enter second number: -89
         [0; 0; 0; 0; 0; 0; 1; 1]
ADD      [1; 0; 1; 0; 0; 1; 1; 1]
--------------------------------------------
         [1; 0; 1; 0; 1; 0; 1; 0] = -86

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): sub
Enter first number : 5
Enter second number: 5
         [0; 0; 0; 0; 0; 1; 0; 1]
SUB      [0; 0; 0; 0; 0; 1; 0; 1]
--------------------------------------------
         [0; 0; 0; 0; 0; 0; 0; 0] = 0

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): sub
Enter first number : 5
Enter second number: -5
         [0; 0; 0; 0; 0; 1; 0; 1]
SUB      [1; 1; 1; 1; 1; 0; 1; 1]
--------------------------------------------
         [0; 0; 0; 0; 1; 0; 1; 0] = 10

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): sub
Enter first number : 55
Enter second number: -55
         [0; 0; 1; 1; 0; 1; 1; 1]
SUB      [1; 1; 0; 0; 1; 0; 0; 1]
--------------------------------------------
         [0; 1; 1; 0; 1; 1; 1; 0] = 110

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter first number : 64
Enter second number: 64
         [0; 1; 0; 0; 0; 0; 0; 0]
ADD      [0; 1; 0; 0; 0; 0; 0; 0]
--------------------------------------------
         [1; 0; 0; 0; 0; 0; 0; 0] = -128

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): sub
Enter first number : 10
Enter second number: 11
         [0; 0; 0; 0; 1; 0; 1; 0]
SUB      [0; 0; 0; 0; 1; 0; 1; 1]
--------------------------------------------
         [1; 1; 1; 1; 1; 1; 1; 1] = -1

Enter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): add
Enter first number : 128
Enter second number: 1
         [1; 0; 0; 0; 0; 0; 0; 0]
ADD      [0; 0; 0; 0; 0; 0; 0; 1]
--------------------------------------------
         [1; 0; 0; 0; 0; 0; 0; 1] = -127

```

I was just having fun with overflow(??) here, since we only go from -128 to 127 it seems to loop back on itself 
when you go over or below those numbers... interesting :) 

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
