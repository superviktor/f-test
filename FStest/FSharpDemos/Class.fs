module Class

//explicit class construction
type Point = 
    //fields
    val m_x:float
    val m_y:float

    //ctor with patams
    new (x,y) = {m_x = x; m_y = y}

    //paramless constructor
    new () = {m_x = 0.; m_y = 0.}

    //property
    member this.Length =
        let sqr x = x*x
        sqrt <| sqr this.m_x + sqr this.m_y

//Execution before ctor
open System
type Point2 = 
    //fields
    val m_x:float
    val m_y:float

    new (text: string) as this =
        //pre processing
        if isNull text then
            raise <| ArgumentException("text")

        let parts = text.Split([|','|])
        let (successX,x) = Double.TryParse(parts.[0])
        let (successY,y) = Double.TryParse(parts.[1])

        if not successX || not successY then
            raise <| ArgumentException("text")
        
        //intitialize fields
        {m_x = x; m_y = y}
        //post processing
        then 
            printfn "[%f;%f]" this.m_x this.m_y

//implicit class construction
type Point3(x:float, y:float) =
    let length =
        let square x = x*x
        sqrt <| square x + square y

    member this.X = x
    member selfRef.Y = y
    member selfReference.Length = length

    //custom ctor should call main ctor
    new() = Point3(0.,0.)

    //second ctor
    new(text: string) =        
        if isNull text then
            raise <| ArgumentException("text")

        let parts = text.Split([|','|])
        let (successX,x) = Double.TryParse(parts.[0])
        let (successY,y) = Double.TryParse(parts.[1])

        if not successX || not successY then
            raise <| ArgumentException("text")
        
        Point3(x,y)

//generic class
type Arrayify<'a>(x:'a) = 
    member this.EmptyArray: 'a[] = [||]
    member __.ArraySize1: 'a[] = [|x|]
    member __.ArraySize2: 'a[] = [|x;x|]

let arrayifyTuple = new Arrayify<int*int>((1,2))

//generic discriminated union
type GenericDU<'a> = 
    | Tag1 of 'a
    | Tag2 of string*'a list

let tag2 = Tag2("primary colors", ["Red";"Green";"Blue"])

//generic record
type GenericRecord<'a,'b> = 
    { Field1:'a; Field2:'b}

let record = {Field1 = 1; Field2 = "str"}

//properties
type ClassWithProps() = 
    let mutable amount = 0
    //readonly prop
    member __.Empty = amount = 0

    //read/write prop
    member __.Amount with get() = amount 
                        and set newAmt = amount <- newAmt 

//autoprop
type ClassWithAutoProp() = 
    member __.Empty = 
        __.Amount = 0
    member val Amount =
        0 with get, set


