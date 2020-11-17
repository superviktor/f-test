module Sequences
    //sequences
    // numbers |> Seq.iter (printfn "%d") 
    let numbers = seq {1..5}

    //sequence vs list

    //ok
    let allPositiveIntsSeq =
        seq {for i in 0..System.Int32.MaxValue do
                yield i}
    
    //out of memory exception
    let allPositiveIntsList = 
        [for i in 0..System.Int32.MaxValue
            -> i]

    //sequence expressions
    //Seq.take 4 alphabet
    let alphabet = seq { for c in 'A' .. 'Z' -> c }

    //sequence with side effect 
    //let fifthLetter = Seq.nth 4 noisyAlphabet
    let noisyAlphabet = seq { for c in 'A' .. 'Z' do
                                printfn "%c" c
                                yield c}
    
    //recuresive
    open System.IO
    let rec allFilesUnder basePath = 
        seq {
            yield! Directory.GetFiles(basePath)

            for subdir in Directory.GetDirectories(basePath) do
                yield! allFilesUnder subdir
        }

    //seq module function

    //take 
    //randomSequence |> Seq.take 3
    open System
    let randomSequence = 
        seq {
            let rnd = new Random()
            while true do
                yield rnd.Next()
        }
    
    //unfold
   
    //Seq.toList fibsUnder100    
    let fibinacciUnder100 (a,b) =
        if a+b > 100 then
            None
        else 
            let nextValue = a+b
            Some(nextValue, (nextValue,a))

    let fibsUnder100 = Seq.unfold fibinacciUnder100 (0,1)

    //aggregate operators

    //seq map
    //words |> Seq.map (fun word -> word, word.Length)
    let words = "The quick brown fox jumped over the lazy dog".Split(' ')

    //seq fold 
    //Seq.fold (+) 0 <| seq { 1 .. 100 }
    
