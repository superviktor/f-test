module LazyEvaluation
    //lazy types
    //y.Value
    let x = Lazy<int>.Create(fun () -> printfn "Evaluating x"; 10)
    let y = lazy (printfn "Evaluating y", x.Value + x.Value)

 
   

