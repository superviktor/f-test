module UnitsOfMeasure

    //printTemperature 55.0<fahrenheit> OK
    //printTemperature 55.0 FAIL
    [<Measure>]
    type fahrenheit

    let printTemperature (temp:float<fahrenheit>) =
        if temp < 32.0<_> then
            printfn "below freezing"
        elif temp < 65.0<_> then
            printfn "cold"
        elif temp < 75.0<_> then
            printfn "just rigth"
        elif temp < 100.0<_> then
            printfn "hot"
        else 
            printfn "scorching"

    [<Measure>]
    type m

    //1<m> * 1<m>
    //val it : int<m ^ 2> = 1

    //relatived measures
    [<Measure>]
    type s //second

    [<Measure>]
    type Hz = s ^ -1 //Hertz

    //adding methods to unit of measure
    [<Measure>]
    type far = //fahrenheit
        static member ConvertToCel(x : float<far>) =
        (5.0<cel> / 9.0<far>) * (x - 32.0<far>)
    and [<Measure>] cel = //celsium
        static member ConvertToFar(x : float<cel>) =
        (9.0<far> / 5.0<cel> * x) + 32.0<far>;;