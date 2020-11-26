module DomainEntity

open System

let sayHello name =
    sprintf "Hello, %s" name

let getList numberOfElements =
    [for i in 1..numberOfElements do 
        let rnd = new Random()
        yield i*rnd.Next()]

