module ActivePatterns

//without AP
let containsVowel (word:string) = 
    let letters = word |>  Set.ofSeq
    match letters with
    | _ when letters.Contains('a') || letters.Contains('o') || letters.Contains('e')
        -> true
    | _ -> false

//single case active patter
open System.IO

let (|FileExtension|) (filePath:string) = Path.GetExtension(filePath)

//determineFileType "file.jpg";;
let determineFileType (filePath:string) =
    match filePath with
    //without active patterns
    | filePath when Path.GetExtension(filePath) = ".txt"
        -> printfn "text file"
    | FileExtension ".jpg"
    | FileExtension ".png"
    | FileExtension ".gif"
        -> printfn "image file"
    | FileExtension ext
        -> printfn "unknown file with extension %s" ext

//partional active pattern
open System
let (|ToBool|_|) (x:string) = 
    let success, value = Boolean.TryParse(x)
    if success then Some(value)
    else None
let (|ToInt|_|) (x:string) = 
    let success, value = Int32.TryParse(x)
    if success then Some(value)
    else None

//describeString "123"
let describeString (str:string) = 
    match str with 
    | ToBool b 
        -> printfn "bool %b" b
    | ToInt i 
        -> printfn "int %d" i
    | _ 
        -> printfn "not bool or int"

//parametrized active pattern
let (|GreterThanThreshold|) (word:string) threshold (text:string) =
    let occurences = 
        text.Split([|' '|]) |> Array.filter (fun w -> w.IndexOf(word, StringComparison.InvariantCultureIgnoreCase) >=0 ) 
    occurences.Length > threshold

//"La la la badword1. I like to say badWord1 because I can." |> profanityChecker
let profanityChecker text = 
    match text with 
    | GreterThanThreshold "badword1" 2 true 
        -> printfn "You said badWord1 more than twice. That's not acceptable!"
    | GreterThanThreshold "badword2" 0 true
        -> printfn "You cant use badword2 ever"
    | _ -> printfn "Acceptable"

//multicase active pattern
let (|Paragraph|Sentence|Word|WhiteSpace|) (input:string) = 
    let inputTrimed = input.Trim()
    if inputTrimed = "" then
        WhiteSpace
    elif input.IndexOf(".") <> -1 then 
        let sentences = inputTrimed.Split([|"."|], StringSplitOptions.None)
        Paragraph(sentences.Length, sentences)
    elif input.IndexOf(" ") <> -1 then
        Sentence (input.Split([|" "|], StringSplitOptions.None))
    else
        Word (input) 

//countLetters "I like f#."
let rec countLetters str =
    match str with
    | WhiteSpace 
        -> 0
    | Word x 
        -> x.Length
    | Sentence words
        -> Array.sumBy countLetters words
    | Paragraph (_, sentences)
        -> Array.sumBy countLetters sentences
