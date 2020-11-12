module PatternMatching

    let isOdd x = x % 2 = 1

    let describeNumber x =
        match isOdd x with 
        | true -> printfn "%d is odd" x
        | false -> printfn "%d is even" x

    let booleanAnd x y =
        match x y with 
        | true, true -> true
        | _, _ -> false

    //named patterns
    let greet x =
        match x with 
        | "Robert" -> printfn "Hi, Bob"        
        | "William" -> printfn "Hi, Bill"
        | x -> printfn "Hi, %s" x

    //matching literals
    [<Literal>]
    let Bill = "Bill Gates"

    let greatV2 x = 
        match x with
        | Bill -> printfn "Hi, Bill"
        | x -> printfn "Hi, %s" x

    //when guards
    open System
    let highLowGame () =
        let rng = new Random()
        let secretNumber = rng.Next() % 100
        let rec highLowGameStep () =
            printfn "Guess the secret number:"
            let guessStr = Console.ReadLine()
            let guess = Int32.Parse(guessStr)
            match guess with
            | _ when guess > secretNumber
                -> printfn "The secret number is lower."
                   highLowGameStep()
            | _ when guess = secretNumber
                -> printfn "You've guessed correctly!"
                   ()
            | _ when guess < secretNumber
                -> printfn "The secret number is higher."
                   highLowGameStep()

        highLowGameStep()

    //grouping pattern 
    let vowelTest c =
        match c with 
        | 'a' | 'b' | 'c' 
            -> true
        | _ 
            -> false

    let describeNumbers x y =
        match x, y with 
        | 1, _
        | _, 1
            -> printfn "One of numbers is one"
        | (2,_) & (_,2)
            -> printfn "Both numbers are two"
        | _ 
            -> printfn "Other"

    //tuple
    let testXor x y =
        match x, y with
        | tuple when fst tuple <> snd tuple
            -> true
        | true, true -> false
        | false, false -> false 

    //list 
    let rec listLengh l =
        match l with 
        | [] 
            -> 0
        | [_] 
            -> 1
        | [_;_] 
            -> 2
        | [_;_;_] 
            -> 3
        | hd :: tail 
            -> 1 + listLengh tail


