module Records
    type PersonRec = {First: string; Last: string; Age: int}

    let steve = {First = "Steve"; Last = "Holt"; Age = 22}


    //cloning record 
    type Car = { 
        Maker: string;
        Model: string;
        Year: int 
        }
    let thisYearCar = { Maker = "bmw"; Model = "x5"; Year = 2020}
    let nextYearCar = { thisYearCar with Year = 2021}

    //pattern matching 
    //currentYearCars [{ Maker = "bmw"; Model = "x5";Year = 2020 }; { Maker = "bmw"; Model = "x5"; Year = 2021 }]
    let cars = [thisYearCar; nextYearCar]
    let currentYearCars allCars =
        allCars |> List.filter (function | { Year = 2020}  -> true | _ -> false)

    //type inference
    //distance {X = 0.0; Y = 0.0} {X = 10.0; Y = 10.0};;
    type Point = { X: float; Y: float}

    let distance p1 p2 =
        let square x = x*x
        sqrt <| square (p1.X - p2.X) + (square p1.Y - p2.Y)

    //methods and properties
    //let v = { X = 10.0; Y = 20.0; Z = 30.0 }
    //v.Length
    type Vector = 
        { X: float; Y: float; Z: float}
        member this.Length =
            sqrt <| this.X**2.0 + this.Y**2.0 + this.Z**2.0


