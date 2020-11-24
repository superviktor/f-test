module ForLoopWithPatternMathing
    type Pet =
        | Cat of string * int //name, lives
        | Dog of string

    let famousPets = [ Dog("Lassie"); Cat("Felix", 9); Dog("Rin Tin Tin") ]
    let printFamousDogs pets = 
        for Dog(name) in pets do
            printfn "The famous dog was %s" name
