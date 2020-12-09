module Interface
type IConsumable = 
    abstract Eat : unit -> unit
   
type Apple() =
    interface IConsumable with 
        member this.Eat() = printfn "Tasty"
 
// let apple = Apple()
// let iconsumable = apple :> IConsumable
// iconsumable.Eat()

//object expression for interfaces
open System.Collections.Generic

type Person = { FirstName:string; LastName:string}
let people = 
    new List<_>(
        [|
            {FirstName ="Viktor"; LastName = "Prykhidko"}
            {FirstName="Andrey"; LastName="Prykhidko"}
        |] )
people.Sort(
    {
        new IComparer<Person> with //another way is to implement separate type IComaprer<Person>
            member this.Compare(l,r) = 
                if l.FirstName > r.FirstName then 1
                elif l.FirstName = r.FirstName then 0
                else -1          
    })
//Seq.iter (fun person -> printfn "\t %s %s" person.FirstName person.LastName) people