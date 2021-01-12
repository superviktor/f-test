module Module2Functions

//function definition
let doubleInput x = 2*x
//function appliation
//doubleInput 2 

let distance x y = x-y |> abs
//partial application 
let distanceFrom5 = distance 5
//distanceFrom5 -5
//currying
//(distance 5) -5

//prefix function 
let add x y = x+y

//infix operator
//1+3

//infix operator in prefix form
//(+)1 3 
let add1 = (+) 1
//add1 6 //7

//function as infix operator, infix distance
let (|><|) x y = x - y |> abs
//5 |><| -5 //10

//lambdas, distance function lambda
//(fun x y -> x - y |> abs) 5 -5

//recursion 
let rec length = function
    | [] -> 0
    | x::xs -> 1 + length xs

//length [1;2;3]

let rec factorial n =
    if n < 2 then
        1
    else 
        n * factorial (n-1)

factorial 3

//piping 
//sin 7.
//pipe forward 
//7. |> sin

//7. |> sin |>  ((*)2.)

//[1;2;3;4]
//    |> List.filter (fun i -> i%2=0)
//    |> List.map ((*)2)
//    |> List.sum

 //pipe backward
 //sin (2. + 1.)
 //sin <| 2. + 1.

 //double/tripple pipe
 //min 12 7
 //(12,7) ||> min

 //function composition
 let minus1 x = x - 1
 let times2 x = x * 2

 //times2 (minus1 9) //16

 let minus1Times2 = minus1 >> times2
 let minus1Times2 = times2 << minus1

minus1Times2 9 //16
(times2 << minus1) 9 //16
 times2 << minus1 <| 9 //16














