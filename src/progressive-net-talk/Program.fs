// Learn more about F# at http://fsharp.org

open System
open FizzBuzz


[<EntryPoint>]
let main argv =
    let fizzBuzzes =
         [|1..50|]
         |> Array.map fizzBuzz
         |> String.concat ", "

    printfn "FizzBuzzes from 1 to 50: %A" fizzBuzzes

    0 // return an integer exit code
