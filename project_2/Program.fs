// -----------------------------------------------------------------------------------------------------
// ok lets see if I can do some of the logical operators 


// functions for lodical operators everything seems to be working fine, now with matching :)  
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
        if i > 8 then
            acc
        else 
            loop (n >>> 1 ) (n % 2 :: acc) (i + 1)
    loop num [] 1


// -----------------------------------------------------------------------------------------------------
// CONEVRT base 2 list   back to unsigned 

let base2listtoUnsigned base2list =
    let rec loop list num =
        if list = [] then 
            num
        else
            //uses the binary nuimber to increase it each round 
            loop list.Tail ((num <<< 1) + list.Head)
    loop base2list 0

//let list1 = unsignedToBase2List 20 

//printfn $"processing %A{list1} through 'base2listtoUnsigned' produces: %A{base2listtoUnsigned list1}\n"

// -----------------------------------------------------------------------------------------------------
// ADDING??? 

// not the best but seems to work
let addTwoBinaryLists binList1 binList2 =
    // our loop with accumalter and carry
    let rec loop (binList1: int list)  (binList2: int list) acc carry =
        //assumes lists are the smae size, it's ok for this program
        if binList1 = [] then
            acc
        else 
            //ands the two heads together and the carry divide by two to get carry over 
            let c = (binList1.Head + binList2.Head + carry) / 2 
            // remainder of two to get the digit to put in list 
            let digit = (binList1.Head + binList2.Head + carry) % 2
            //then loop again with tails, add digit to acculator and send the carry over 
            loop binList1.Tail binList2.Tail ( digit:: acc) c

    //we need to reverse the lists before sneding them into the loop
    let a1 = List.rev binList1
    let b1 = List.rev binList2
    loop a1 b1 [] 0


// -----------------------------------------------------------------------------------------------------
// 2 compliment 
// should i use |> not sure if you can here... 
let twosCompliement binList =
    // our loop with accumalter and carry
    let notBinList = notPipeline binList
    let one = unsignedToBase2List 1
    let acc = addTwoBinaryLists notBinList one
    acc    


// -----------------------------------------------------------------------------------------------------
// takes in a number and returns the signed 8 bist base 2 list  
let  signedToBase2List num =
    // our loop with accumalter and carry
    if num < 0 then
        let absnum = num * -1
        absnum
        |> unsignedToBase2List
        |> twosCompliement
    else
        unsignedToBase2List num


// -----------------------------------------------------------------------------------------------------
// takes in a bit list and returns the signed number   
let  base2ListToSigned (bitlist: int list) =
    // our loop with accumalter and carry
    if bitlist.Head = 1 then
        printfn $"bitlist = %A{bitlist}"
        let num = bitlist 
                    |> twosCompliement
                    |> base2listtoUnsigned
        num * -1
    else
        printfn $"bitlist = %A{bitlist}"
        bitlist
        |> base2listtoUnsigned
        


//    //seems to work
//let bitlist = signedToBase2List 20

//printfn $"processing %A{bitlist} through 'Base2ListToSigned' produces: %A{base2ListToSigned bitlist}\n"
    

// -----------------------------------------------------------------------------------------------------
// stolen from professor seems to work fine 
// SO I would like this to loop and check for input and print nicer... we will see what I have time for 
// a print function might be the best as it makes it easier to double check the logic 


let result () =
    printf "\nEnter the operation you want to perform (NOT, OR, AND, XOR, ADD, SUB or QUIT): "
    match System.Console.ReadLine() with
    | "NOT" -> 
        printf "Enter Hex value: "
        let byte = System.Console.ReadLine()
        let tmp = (notPipeline (StringToInt byte 16 |> unsignedToBase2List))
        printfn $"Result of NOT %s{byte} = %A{tmp} = %X{base2listtoUnsigned tmp}"
        true
    | "AND" -> 
        printf "Enter Hex value: "
        let byte = System.Console.ReadLine()
        let tmp = (StringToInt byte 16 |> unsignedToBase2List)
        printf "Enter Hex value: "
        let byte2 = System.Console.ReadLine()
        let tmp2 = (StringToInt byte2 16 |> unsignedToBase2List)
        let ans = andPipeline tmp tmp2
        printfn $"Result of AND %s{byte}, %s{byte2} = %A{ans} = %X{base2listtoUnsigned ans}"
        true
    | "OR" -> 
        printf "Enter Hex value: "
        let byte = System.Console.ReadLine()
        let tmp = (StringToInt byte 16 |> unsignedToBase2List)
        printf "Enter Hex value: "
        let byte2 = System.Console.ReadLine()
        let tmp2 = (StringToInt byte2 16 |> unsignedToBase2List)
        let ans = orPipeline tmp tmp2
        printfn $"Result of OR %s{byte}, %s{byte2} = %A{ans} = %X{base2listtoUnsigned ans}"
        true
    | "XOR" -> 
        printf "Enter Hex value: "
        let byte = System.Console.ReadLine()
        let tmp = (StringToInt byte 16 |> unsignedToBase2List)
        printf "Enter Hex value: "
        let byte2 = System.Console.ReadLine()
        let tmp2 = (StringToInt byte2 16 |> unsignedToBase2List)
        let ans = xorPipeline tmp tmp2
        printfn $"Result of XOR %s{byte}, %s{byte2} = %A{ans} = %X{base2listtoUnsigned ans}"
        true
    | "ADD" -> 
        printf "Enter first number : "
        let byte = System.Console.ReadLine()
        let tmp = (StringToInt byte 10 |> signedToBase2List)
        printfn $"tmp =  %A{tmp}"
        printf "Enter second number: "
        let byte2 = System.Console.ReadLine()
        let tmp2 = (StringToInt byte2 10 |> signedToBase2List)
        printfn $"tmp2 =  %A{tmp2}"
        // should probably have a function that makes it a signed base2list 
        // pass bith numbers through 
        // then add the two numbers
        let ans = addTwoBinaryLists tmp tmp2
        printfn $"and = %A{ans}"
        // then a function to base2ListtoSigned 
        // then a better print function
        printfn $"Result of ADD %s{byte}, %s{byte2} = %A{ans} = %i{base2ListToSigned ans}"
        true
    //minus should be pretty simil;ar but I need to multiple the second number by -1 first 
    | "SUB" -> 
        printf "Enter first number : "
        let byte = System.Console.ReadLine()
        let tmp = (StringToInt byte 10 |> signedToBase2List)
        printfn $"tmp =  %A{tmp}"
        printf "Enter second number: "
        let byte2 = System.Console.ReadLine()
        //so just multiplinhg the number by minus 1
        let tmp2 = ((StringToInt byte2 10) * -1 |> signedToBase2List) 
        //let tmp2m = tmp2 * -1 
        printfn $"tmp2 =  %A{tmp2}"
        // should probably have a function that makes it a signed base2list 
        // pass bith numbers through 
        // then add the two numbers
        let ans = addTwoBinaryLists tmp tmp2
        printfn $"and = %A{ans}"
        // then a function to base2ListtoSigned 
        // then a better print function
        printfn $"Result of ADD %s{byte}, %s{byte2} = %A{ans} = %i{base2ListToSigned ans}"
        true


result()
