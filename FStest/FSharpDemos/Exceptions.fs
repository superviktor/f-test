module Exceptions

    //failwith
    let divide1 x y =
        if y = 0 then failwithf "Can't divide %d by zero" x
        x / y

    //throw
    let divide2 x y =
        if y = 0 then raise <| new System.DivideByZeroException()
        x / y

    //handle exception
    let complexFunc =
        try
            printfn "some complex stuff"
        with
        | :? System.DivideByZeroException
            -> printfn "DivideByZeroException"
        | :? System.ArgumentNullException
            -> printfn "DivideByZeroException"
        | _ as ex 
            -> printfn "%s" ex.Message