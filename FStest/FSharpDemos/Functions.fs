module Functions

    let square x = x*x

    let imperativeSum numbers =
        let mutable total = 0
        for n in numbers do
            let numberSquared = square n
            total <- total + numberSquared
        total
    
    let declarativeSum numbers =
        numbers
        |> Seq.map square
        |> Seq.sum

    //lambda
    //List.map (fun x -> -x) [1..10]

    //partional function application
    open System.IO
    let appendFile (fileName: string) (text: string) =
        use file = new StreamWriter(fileName)
        file.WriteLine(text)
        file.Close()

    let appendLogFile = appendFile "D:\dir"

    //function returning funcition 
    let generatePowerOfFunc baseValue =
        (fun exponent -> baseValue ** exponent)

    let powerOfTwo = generatePowerOfFunc 2.0
    let powerOfThree = generatePowerOfFunc 3.0

    //recursive function
    let rec factorial x =
        if x <= 1 then
            1
        else x * factorial (x-1)
    
    //for loop
    //forLoop (fun () -> printfn "Printing") 3
    let rec forLoop body times =
        if times <= 0 then 
            ()
        else
            body()
            forLoop body (times - 1)

    //while loop
    //whileLoop (fun () -> DateTime.Now.DayOfWeek <> DayOfWeek.Saturday) (fun () -> printfn "I wish it were the weekend...");;
    open System
    let rec whileLoop predicate body =
        if predicate() then
            body()
            whileLoop predicate body
        else
            ()

    //symbolic operator factorial
    //!5
    let rec (!) x =
           if x <= 1 then
               1
           else x * (!) (x-1)

    //functions composition
    open System
    open System.IO
    //v1
    let sizeOfFolder folder =
        let filesInFolder:string[] = 
            Directory.GetFiles(folder,"*", SearchOption.AllDirectories)
        let fileInfos:FileInfo[] = 
            Array.map 
                (fun (file:string) -> new FileInfo(file))
                filesInFolder
        let fileSizes:Int64[] = 
            Array.map
                (fun (fileInfo:FileInfo) -> fileInfo.Length)
                fileInfos
        let totalSize = Array.sum fileSizes
        totalSize

    //v2
    let uglySizeOfFolder folder =
        Array.sum
            (Array.map
                (fun (info : FileInfo) -> info.Length)
                    (Array.map
                        (fun file -> new FileInfo(file))
                            (Directory.GetFiles(
                                folder, "*.*",
                                SearchOption.AllDirectories))))

    //pipe forward operator
    [1..10] |> List.iter (printfn "%d")

    //v3
    let sizeOfFolderPiped folder =
        let getFiles path = Directory.GetFiles(path,"*", SearchOption.AllDirectories)

        let totalSize = 
            folder
            |> getFiles
            |> Array.map (fun file -> new FileInfo(file))
            |> Array.map (fun fileInfo -> fileInfo.Length)
            |> Array.sum

        totalSize

    //forward composition opearator
    //v4
    //sizeOfFolderComposed (Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
    let sizeOfFolderComposed (*No Parameters!*) =
        let getFiles folder =
            Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories)
        getFiles
        >> Array.map (fun file -> new FileInfo(file))
        >> Array.map (fun info -> info.Length)
        >> Array.sum