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
    printfn "Ingrese su estatura"
    let height = float(Console.ReadLine())
    printfn "Ingrese su peso corporal"
    let weight = float(Console.ReadLine())

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
    let imc1 = imc ifSuccess ifZero ifZero 
    let imcSimple = imc1 ifTooBig ifTooBig
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
    let ifSuccess2 x = 
        if x<18.5 
        then printfn "Peso bajo: %.3f kg/m^2 " x 
        else if x>25.0 
        then printfn "Peso alto: %.3f kg/m^2" x 
        else printfn "Peso adecuado: %.3f kg/m^2" x
    let imcSpecialized = imc ifSuccess2 ifZero ifZero ifZero ifZero
    imcSpecialized height weight
    

let bindtochainoptions() =
    printfn "Ingresa tu promedio academico"
    printfn "Para poder clasificarlo"
    //Estas son las funciones que queremos encadenar por medio del bind.
    let notvalid (x : float) = 
        if (x <= 5.0 && x >= 0.0) 
        then 
           printfn("Tu Promedio ingresado es valido")
           Some x
        else 
           printfn("El promedio debe ser un numero entre 0 y 5")
           None
    
    let not45 (x : float) = 
        if (x < 4.5) 
        then 
           printfn("Tu promedio es menor a 4.5")
           Some x
        else 
           printfn("Felicidades Tienes un Promedio igual o por encima de 4.5")
           None

    let not40 (x : float) = 
        if (x < 4.0) 
        then 
           printfn("Tu promedio es menor a 4")
           Some x
        else 
           printfn("Pero tu promedio esta entre 4 y 4.4 lo cual es bastante bueno")
           None

    let not35 (x : float) = 
        if (x < 3.5) 
        then 
           printfn("Tu promedio es menor a 3.5")
           Some x
        else
           printfn("Tienes un promedio entre 3.5 y 3.9  no es muy alto pero es aceptable :)")
           None

    let not30 (x : float) = 
           if (x < 3.0) 
           then 
              printfn("Tu promedio es menor a 3, por lo que no deberias seguir en la U :(")
              Some x
           else
              printfn("Tienes un promedio entre 3 y 3.4 deberias comenzar a preocuparte")
              None

    
    //Esta funcion es la que nos va a permitir ir encadenando todas las funciones, siempre y cuando estas retornen algo distinto a none (null)
    let bind f x = 
        match x with 
        | Some i -> f i
        | None -> None
    
    //Se recive el input del usuario
    let peso = float(Console.ReadLine())
    let pes = Some peso
    pes
    //Se llama el primer bind con el input del usuario y la primera funcion a evaluar, y se va a pasar el resultado de este bind, al  siguente bind, con otra funcion, 
    //y se va a repetir lo anterior hasta que se acaben los bind.
    |> bind notvalid
    |> bind not45
    |> bind not40
    |> bind not35
    |> bind not30
    |> ignore

    printfn("")

[<EntryPoint>]
let main argv =
    let options = ["1. Partial aplicaction";"2. Hollywood principle";"3. Use bind to chain options"]
    let prnt = printfn "%s"
    let mutable input = ""
    printfn "Ingrese la opcion que desea realizar:"
    options
    |> List.iter prnt

    input <- Console.ReadLine()
    
    match input with
    | "1" | "1." -> partialAplication()
    | "2" | "2." -> hollywoodPrinciple()
    | "3" | "3." -> bindtochainoptions()
    | _ -> printfn "Opcion invalida"

    0




