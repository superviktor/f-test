let nearX x =
    [
        yield x - 1
        yield x
        yield x + 1
    ]

let negateArray = 
    [
        let negate x = -x
        for i in 1 .. 10 do
            if i % 2 = 0 then
                yield negate i
            else
                yield i
    ]

//primesUnderMax 50
let primesUnderMax max =
    [
    for n in [1..max] do
        let primeFactorsOfN =
            [
                for i in [1..n] do
                    if n % i = 0 then
                        yield i
            ]
        
        if List.length primeFactorsOfN = 2 then
            yield n
    ]

//List.reduce insertComma ["1", "2", "3"]
let insertComma accumulator item 
    = accumulator + ", " + item

//List.fold addAccToListItem 0 [4;5]
let addAccToListItem acc item =
    acc + item

//List.iter printNumber [1;2;3]
let printNumber n =
    printfn "%d" n

//Optional
open System
let isInteger (str:string) =
    let successful, result = Int32.TryParse(str)
    if successful then Some(result)
    else None

//module
module Utilities =
    module ConversionUtils =
        // Utilities.ConversionUtils.intToString
        let intToString (x : int) = x.ToString()
    module ConvertBase =
        // Utilities.ConversionUtils.ConvertBase.convertToHex
        let convertToHex x = sprintf "%x" x
        // Utilities.ConversionUtils.ConvertBase.convertToOct
        let convertToOct x = sprintf "%o" x
    module DataTypes =
        // Utilities.DataTypes.Point
        type Point = Point of float * float * float

[<EntryPoint>]
let main argv =
    0 // return an integer exit code