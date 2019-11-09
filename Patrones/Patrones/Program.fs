// Learn more about F# at http://fsharp.org

open System

let partialAplication() =
    let weights  = [40.0;50.0;70.0]
    
    let pounds x = x*2.205

    let inKilograms = "En kilogramos:"
    let inKilogramsUnits = printfn "    %.3f kg"
    let inPounds = "Al convertir a libras:"
    let inPoundsUnits = printfn "   %.3f lb"

    let prnt = printfn "%s"

    prnt inKilograms
    weights
    |> List.iter inKilogramsUnits

    prnt inPounds

    weights
    |> List.map pounds
    |> List.iter inPoundsUnits

    printfn "Ingrese su peso en kilogramos"

    let kilograms = float (Console.ReadLine())
    prnt inPounds
    inPoundsUnits (pounds kilograms)
    
let hollywoodPrinciple() =
    let pounds x = x*2.205
    printfn "asdasd"


[<EntryPoint>]
let main argv =
    let options = ["1. Partial aplicaction";"2. Hollywood principle";"3. Use bind to chain options";"4. Use bind to chain tasks"]
    let prnt = printfn "%s"
    let mutable input = ""
    printfn "Ingrese la opcion que desea realizar:"
    options
    |> List.iter prnt

    input <- Console.ReadLine()
    
    match input with
    | "1" | "1." -> partialAplication()
    | "2" | "2." -> hollywoodPrinciple()
    | _ -> printfn "Opcion invalida"

    0




