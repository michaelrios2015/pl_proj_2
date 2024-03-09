// -----------------------------------------------------------------------------------------------------
// functions for logical operators everything seems to be working fine, now with matching :)  
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
// THE PIELINE FOR THE LOGICAL OPERTORS 

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
//pretty sure all these can be done with matching as well 
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


//let list1 = unsignedToBase2List 20 

//printfn $"processing %A{list1} through 'base2listtoUnsigned' produces: %A{base2listtoUnsigned list1}\n"

// -----------------------------------------------------------------------------------------------------
// ADDING??? 

// not the best but seems to work
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
let twosCompliement binList =
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
        |> twosCompliement
    //it's a positive number so just used unsigned function
    |_-> unsignedToBase2List num
    

// -----------------------------------------------------------------------------------------------------
// takes in a bit list and returns the signed number   
let  base2ListToSigned (bitlist: int list) =
    // checking to see if it is positive or negative 
    match bitlist.Head with 
    | 1 ->
        //printfn $"bitlist = %A{bitlist}"
        //this is a negative number we convert it back into a positive bit 2 list, and turn that into a decimal number 
        let num = bitlist 
                    |> twosCompliement
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
// print not sure if this really adds much.. it's very good for certain operations as it makes checking them much easier and not so 
//good for others 

let printnice bitlist1 bitlist2 operator=
    printfn $"\t %A{bitlist1}"
    printfn $"%s{operator}\t %A{bitlist2}"
    printfn $"--------------------------------------------"

// -----------------------------------------------------------------------------------------------------
// stolen from professor, works fine could use more subprograms
//I have a feeling that my loop is not set up correctly but it works so I am keeping it till i learn more
//would be better if I made subprograms instead of repeating code...

let result () =

    let rec loop ans =
        match ans with
        | yes ->
            printf "\nEnter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): "
            let operator = System.Console.ReadLine().ToUpper()
            match operator with
            | "NOT" ->
                printf "Enter Hex value: "
                //get input
                let byte = System.Console.ReadLine()
                // convert to unsigned list 
                let tmp1 = (StringToInt byte 16 |> unsignedToBase2List)
                //run it through not pipeline
                let tmp2 = (notPipeline tmp1)
                //print results
                printfn $"Result of NOT %A{tmp1} = %A{tmp2} = %X{base2listtoUnsigned tmp2}"
                loop "yes"
                //true
            | "AND" -> 
                //pretty much same as above but with two inputs
                printf "Enter Hex value: "
                let byte = System.Console.ReadLine()
                let tmp = (StringToInt byte 16 |> unsignedToBase2List)
                printf "Enter Hex value: "
                let byte2 = System.Console.ReadLine()
                let tmp2 = (StringToInt byte2 16 |> unsignedToBase2List)
                let ans = andPipeline tmp tmp2
                printnice tmp tmp2 operator
                printfn $"\t %A{ans} = %X{base2listtoUnsigned ans}"
                loop "yes"
                //true
            | "OR" -> 
                printf "Enter Hex value: "
                let byte = System.Console.ReadLine()
                let tmp = (StringToInt byte 16 |> unsignedToBase2List)
                printf "Enter Hex value: "
                let byte2 = System.Console.ReadLine()
                let tmp2 = (StringToInt byte2 16 |> unsignedToBase2List)
                let ans = orPipeline tmp tmp2
                printnice tmp tmp2 operator
                printfn $"\t %A{ans} = %X{base2listtoUnsigned ans}"
                loop "yes"
                //true
            | "XOR" -> 
                printf "Enter Hex value: "
                let byte = System.Console.ReadLine()
                let tmp = (StringToInt byte 16 |> unsignedToBase2List)
                printf "Enter Hex value: "
                let byte2 = System.Console.ReadLine()
                let tmp2 = (StringToInt byte2 16 |> unsignedToBase2List)
                let ans = xorPipeline tmp tmp2
                printnice tmp tmp2 operator
                printfn $"\t %A{ans} = %X{base2listtoUnsigned ans}"
                loop "yes"
                //true
            | "ADD" -> 
                //take in first number 
                printf "Enter first number : "
                let byte = System.Console.ReadLine()
                // turn it into a signed base 2 list
                let tmp = (StringToInt byte 10 |> signedToBase2List)
                //repeat for second number 
                printf "Enter second number: "
                let byte2 = System.Console.ReadLine()
                let tmp2 = (StringToInt byte2 10 |> signedToBase2List)
                //add the two 
                let ans = addTwoBinaryLists tmp tmp2
                //print it 
                printnice tmp tmp2 operator
                printfn $"\t %A{ans} = %i{base2ListToSigned ans}"
                loop "yes"
                //true
            //minus should be pretty simil;ar but I need to multiple the second number by -1 first 
            | "SUB" -> 
                //same as above
                printf "Enter first number : "
                let byte = System.Console.ReadLine()
                let tmp = (StringToInt byte 10 |> signedToBase2List)
                printf "Enter second number: "
                let byte2 = System.Console.ReadLine()
                //so just multiplinhg the second number by minus 1, since we are adding our two numbers
                let tmp2 = ((StringToInt byte2 10) * -1 |> signedToBase2List) 
                //this is just so we can dispaly the bit two list correctly for the print function
                let tmp3 = ((StringToInt byte2 10) |> signedToBase2List) 
                //we can now add number one to the negative of number two
                let ans = addTwoBinaryLists tmp tmp2
                //print it nicely
                printnice tmp tmp3 operator
                printfn $"\t %A{ans} = %i{base2ListToSigned ans}"
                loop "yes"
                //true
            | "QUIT" |_ -> 
                printfn $"GOOD BYE!!"
                //loop "no"
                //I have no clue why this stops the program but it does so I am sticking with it 
                true

        //|_-> false
    
    loop "yes"

result()
