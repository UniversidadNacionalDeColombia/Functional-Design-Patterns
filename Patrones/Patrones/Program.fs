// Learn more about F# at http://fsharp.org

open System

let partialAplication() =
    let weights  = [40.0;50.0;70.0]
    
    //Funcion encargada de convertir el peso de kilogramos a gramos
    let pounds x = x*2.205

    //Strings que se van a imprimir
    let inKilograms = "En kilogramos:"
    let inPounds = "Al convertir a libras:"

    //Funciones encargadas de realizar diferentes tipos de impresiones
    let inKilogramsUnits = printfn "    %.3f kg"
    let inPoundsUnits = printfn "   %.3f lb"
    let prnt = printfn "%s"

    prnt inKilograms
    //Se recorren cada uno de los pesos y se imprimen en kg
    weights
    |> List.iter inKilogramsUnits

    prnt inPounds
    //Se recorren cada uno de los pesos y se imprimen en libras
    weights
    |> List.map pounds
    |> List.iter inPoundsUnits

    printfn "Ingrese su peso en kilogramos"

    let kilograms = float (Console.ReadLine())
    prnt inPounds
    //Dado el peso ingresado en kilogramos se imprime el peso en libras
    inPoundsUnits (pounds kilograms)
    
let hollywoodPrinciple() =
    printfn "Ingrese su estatura"
    let height = float(Console.ReadLine())
    printfn "Ingrese su peso corporal"
    let weight = float(Console.ReadLine())

    //Funcion que calcula el imc y dependiendo de las diferentes opciones que recibe
    //ejecuta alguna de las funciones correspondientes que recibe como paremetros
    let imc ifSuccess ifHeightZero ifweightZero ifHeightTooBig ifweightTooBig heigth weight  = 
        if heigth <= 0.0
        then ifHeightZero()
        else if height > 3.0
        then ifHeightTooBig()
        else if weight <= 0.0
        then ifweightZero()
        else if weight >= 700.0
        then ifweightTooBig()
        else ifSuccess(weight/(height*height))

    printfn "Su indice de masa corporal es de:"
    let ifTooBig () = printfn "¿Estas seguro de tener un dato correcto?"
    let ifZero () = printfn "Dato incorrecto :("
    let ifSuccess x = printfn "%.3f kg/m^2"x
    let heightTooBig () = printfn "La altura no puede ser tan grande"
    let weightTooBig () = printfn "El peso es demasiado grande"
    //Funcion que usa 3 de los parametros que recibe la funcion imc
    let imc1 = imc ifSuccess ifZero ifZero 
    //Funcion que utiliza los 2 ultimos parametros que le faltaba por recibir a la funcion original imc
    let imcSimple = imc1 ifTooBig ifTooBig
    //Funcion que utiliza los 2 ultimos parametros que le faltaba por recibir a la funcion original imc
    let imcEspecific = imc1 heightTooBig weightTooBig

    //No se especifica por que es el error, por decir si la altura se muestra dato incorrecto
    printfn "Resultado con funcion ''simple'' "
    imcSimple height weight
    //Se especifica que tipo de problema hay, por ejemplo si la altura es demasiado grande
    printfn "Resultado con funcion ''Especifica'' "
    imcEspecific height weight

    let errors () = failwith "Dato incorrecto"
    let imcErrors = imc ifSuccess errors errors errors errors
    //Los errores generan una alerta
    printfn "Resultado que genera Throws con datos incorrectos"
    imcErrors height weight

    //Si el imc < 18.5 se muestra un mensaje, imc > 25 otro mensaje y imc >= 18.5 y imc <= 25 otro mensaje
    printfn "Resultado con mensaje de alerta dependiendo del imc"
    //Funcion que es ejecutada en caso de exito y se encarga de trabajar el valor recibido
    //e imprimir un mensaje correspondiente al valor que se ha recibido
    let ifSuccess2 x = 
        if x<18.5 
        then printfn "Peso bajo: %.3f kg/m^2 " x 
        else if x>25.0 
        then printfn "Peso alto: %.3f kg/m^2" x 
        else printfn "Peso adecuado: %.3f kg/m^2" x
    let imcSpecialized = imc ifSuccess2 ifZero ifZero ifZero ifZero
    imcSpecialized height weight
    

[<EntryPoint>]
let main argv =
    let options = ["1. Partial aplicaction";"2. Hollywood principle"]
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




