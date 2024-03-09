example output 

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
