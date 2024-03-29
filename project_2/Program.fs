﻿// -----------------------------------------------------------------------------------------------------
// BASIC LOGICAL OPERATORS 

let not x =
    match x with
    | 1 -> 0
    |_ -> 1

let orfun x y = 
    match x+y with
    | 0 -> 0 
    |_ -> 1

let andfun x y = 
    match x+y with 
    | 2 -> 1
    |_ -> 0

let xorfun x y = 
    match x+y with
    | 1 -> 1
    |_ -> 0

// -----------------------------------------------------------------------------------------------------
// THE PIPELINE FOR THE LOGICAL OPERTORS 

// this runs a list through the functions so the pipeline I guess
let notPipeline values =
    values|> List.map not

// apperntly using list.map2 is not cheating so that's great!!
//sinces it's map2 does it know it will be getting two lists?? 
let orPipeline  = List.map2 (orfun)

let andPipeline  = List.map2 (andfun)

let xorPipeline  = List.map2 (xorfun)


// -----------------------------------------------------------------------------------------------------
// Convert HEXADECIMAL string to number, stole from professor 

let StringToInt string (toBase:int) = System.Convert.ToInt32(string, toBase)

// ----------------------------------------------------------------------------------------------------- 
// CONEVRT unsigned to base 2 list  

let unsignedToBase2List num =
    let rec loop n acc i =
        //we interate 8 times then reyurn our base 2 list
        match i with 
        | 8 -> acc
        //tail recursion to check how many 2^i there are 
        |_->  loop (n >>> 1 ) (n % 2 :: acc) (i + 1)
    loop num [] 0


// -----------------------------------------------------------------------------------------------------
// CONEVRT base 2 list   back to unsigned 

let base2listtoUnsigned base2list =
    let rec loop list num =
        // we have gone through the entire list
        match list with 
        | [] -> num
        //uses the binary number to increase value each round 
        |_-> loop list.Tail ((num <<< 1) + list.Head)
    loop base2list 0

//an old test
//let list1 = unsignedToBase2List 20 
//printfn $"processing %A{list1} through 'base2listtoUnsigned' produces: %A{base2listtoUnsigned list1}\n"

// -----------------------------------------------------------------------------------------------------
// ADDING 

// reword from a stack overflow example
let addTwoBinaryLists binList1 binList2 =
    // our loop with accumalter and carry
    let rec loop (binList1: int list)  (binList2: int list) acc carry =
        //assumes lists are the smae size so once one ends they both end, it's ok for this program
        match binList1 with
        | [] -> acc
        |_ ->  
            //ands the two heads together and the carry divide by two to get carry over 
            let c = (binList1.Head + binList2.Head + carry) / 2 
            // remainder of two to get the digit to put in list 
            let digit = (binList1.Head + binList2.Head + carry) % 2
            //then loop again with tails, add digit to acculator and send the carry over 
            loop binList1.Tail binList2.Tail ( digit:: acc) c

    //we need to reverse the lists before sneding them into the loop
    let a1 = List.rev binList1
    let b1 = List.rev binList2
    //start our loop
    loop a1 b1 [] 0


// -----------------------------------------------------------------------------------------------------
// 2 compliment 
// should i use |> not sure if you can here... 
let twosComplement binList =
    // first run the number through the not pipeline
    let notBinList = notPipeline binList
    // this will be our 1
    let one = unsignedToBase2List 1
    // add togther 
    let acc = addTwoBinaryLists notBinList one
    acc    


// -----------------------------------------------------------------------------------------------------
// takes in a number and returns the signed 8 bist base 2 list  
let  signedToBase2List num =
    match num with
    // this seems to work 
    | num when num < 0 -> 
        // if so multipl it by -1 to get positive, or absolute value  
        let absnum = num * -1
        // get the base two list for the absolute value then the twos compliment of that 
        absnum
        |> unsignedToBase2List
        |> twosComplement
    //it's a positive number so just used unsigned function
    |_-> unsignedToBase2List num

// -----------------------------------------------------------------------------------------------------
// SUBTRACTING 

// subtracting is just multiplying the second number by -1
//which is this case just means running it through two's compliement and then adding the two numbers :) 
let subTwoBinaryLists binList1 binList2 =
    addTwoBinaryLists binList1 (twosComplement binList2)

// -----------------------------------------------------------------------------------------------------
// takes in a bit list and returns the signed number   
let  base2ListToSigned (bitlist: int list) =
    // checking to see if it is positive or negative 
    match bitlist.Head with 
    | 1 ->
        //printfn $"bitlist = %A{bitlist}"
        //this is a negative number we convert it back into a positive bit 2 list, and turn that into a decimal number 
        let num = bitlist 
                    |> twosComplement
                    |> base2listtoUnsigned
        //then multiply it by -1 
        num * -1
    |_->
        //printfn $"bitlist = %A{bitlist}"
        bitlist
        |> base2listtoUnsigned

//    //seems to work
//let bitlist = signedToBase2List 20
//printfn $"processing %A{bitlist} through 'Base2ListToSigned' produces: %A{base2ListToSigned bitlist}\n"
    

// -----------------------------------------------------------------------------------------------------
// A PRINT FUNCTION

let printNice bitlist1 bitlist2 operator ans vType=
    
    //pretty sure this can be done with less repitation, but it works
    //ideally I would understanding print spacing a bit better
    match vType with
    | "hex" -> 
            printfn $"\t %A{bitlist1} = %X{base2listtoUnsigned bitlist1}"
            printfn $"%s{operator}\t %A{bitlist2} = %X{base2listtoUnsigned bitlist2}"
            printfn $"--------------------------------------------"
            printfn $"\t %A{ans} = %X{base2listtoUnsigned ans}"
    | "dec" -> 
            printfn $"\t %A{bitlist1} = %i{base2ListToSigned bitlist1}"
            printfn $"%s{operator}\t %A{bitlist2} = %i{base2ListToSigned bitlist2}"
            printfn $"--------------------------------------------"
            printfn $"\t %A{ans} = %i{base2ListToSigned ans}"

    
    // -----------------------------------------------------------------------------------------------------
// AN INPUT FUNCTION  

let input vType= 

    // so it just expects to get hexidecial or regular decimal numers
    match vType with
    |"hex" ->
        printf "Enter Hex value between 00 and FF: "
        //get input
        let byte = System.Console.ReadLine()
        //change it to a number and change that number into an unsigned base 2 list
        StringToInt byte 16 |> unsignedToBase2List
    |"dec"-> 
        //same as above but know with regular decimal numbers
        printf "Enter a number between -128 and 127: "
        let byte = System.Console.ReadLine()
        // turn it into a signed base 2 list
        StringToInt byte 10 |> signedToBase2List

// -----------------------------------------------------------------------------------------------------
// MAIN PROGRAM
// stolen from professor, 

let result () =

    printf "\nEnter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): "
    let operator = System.Console.ReadLine().ToUpper()
    match operator with
    | "NOT" ->
        let tmp1 = input("hex")
        //run it through not pipeline
        let tmp2 = notPipeline tmp1
        //print results
        printfn $"Result of NOT %A{tmp1} = %A{tmp2} = %X{base2listtoUnsigned tmp2}"
        true
    | "AND" -> 
        // get user input
        let tmp1 =  input("hex") 
        let tmp2 =  input("hex")
        //run it through pipeline
        let ans = andPipeline tmp1 tmp2
        //print results
        printNice tmp1 tmp2 operator ans "hex"
        true
    | "OR" -> 
        //the rest follow the same pattern
        let tmp1 = input("hex")
        let tmp2 = input("hex")
        let ans = orPipeline tmp1 tmp2
        printNice tmp1 tmp2 operator ans "hex"
        true
    | "XOR" -> 
        let tmp1 = input("hex")
        let tmp2 = input("hex")
        let ans = xorPipeline tmp1 tmp2
        printNice tmp1 tmp2 operator ans "hex"
        true
    | "ADD" -> 
        let tmp1 = input("dec") 
        let tmp2 = input("dec")
        //add the two 
        let ans = addTwoBinaryLists tmp1 tmp2
        //print it 
        printNice tmp1 tmp2 operator ans "dec"
        true
    | "SUB" -> 
        //essentially the same as add
        let tmp = input("dec")
        let tmp2 = input("dec")
        let ans = subTwoBinaryLists tmp tmp2
        printNice tmp tmp2 operator ans "dec"
        true
    | "QUIT" |_ -> 
        printfn $"GOOD BYE!!"
        false
       
// -----------------------------------------------------------------------------------------------------
// A LOOP for the main program 
// also stolen from professor 
let rec prog () =
    //a small explanation of the program
    printf "---------------------------------------------------------------------------------------------------------\n"
    printf "\nThis program only uses 8 bit numbers for calculations 00 to FF for hexidecimal and -128 to 127 for decimal"
    printf "\nIt will take larger or smaller numbers but it can only return results within those ranges\n"
    printf "\n---------------------------------------------------------------------------------------------------------\n"
    // so it runs restults and just keeps looping till result returns false
    match result () with
    //so this just says do nothing and the program exits.. neat :) 
    | false -> ()
    | _ -> prog ()

prog()
