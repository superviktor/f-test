module FizzBuzzer
let fizzBuzz i =
    match i with
    | _ when i % 3 = 0 && i % 5 = 0 
        -> "FizzBuzz"
    | _ when i % 3 = 0 
        -> "Fizz"
    | _ when i % 5 = 0
        -> "Buzz"
    | _ 
        -> sprintf "%d" i

    //[1..100] |> List.map fizzBuzz