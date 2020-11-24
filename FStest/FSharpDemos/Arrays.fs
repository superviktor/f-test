module Arrays
    //array comprehension
    let squares =
        [| for i in 1..10 -> i*i |]

    //slicing
    let halfOfSquares = 
        squares.[4..]

    //array init
    open System

    let divisions = 4.0
    let twoPi = 2.0 * Math.PI
    //Array.init (int divisions) (fun i -> float i * twoPi / divisions)

    //zero create
    let intArray : int [] = Array.zeroCreate 3
    let stringArray : string[] = Array.zeroCreate 3

    //pattern matching
    let describeArray arr = 
        match arr with
        | null -> "array is null"
        | [| |] -> "array is empty"
        | [| x |] -> sprintf "array has one element %A" x
        | [|x;y|] -> sprintf "array has two elements %A, %A" x y
        | a -> sprintf "array has %d elements, %A" arr.Length a

    //array module function
    //partition
    let greaterThan10 x = x > 10

    //[|1;22;1;3;88;6;9;2;54;7|] |> Array.partition greaterThan10

    //try find

    let rec isPowerOfTwo x =
        if x = 2 then 
            true
        elif x%2 = 1 then
            false
        else isPowerOfTwo (x/2)

    //[| 1; 7; 13; 64; 32 |] |> Array.tryFind isPowerOfTwo