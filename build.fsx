#r "packages/FAKE/tools/FakeLib.dll"
open Fake
open DotNetCli


let runTests() =
    trace "testing..."
    DotNetCli.Test (fun t -> 
                            {t with WorkingDir = "tests"})

Target "Test" <| fun _ -> runTests()

let build() = 
    trace "starting build..."

    Paket.Restore id
    DotNetCli.Build id

    trace "build..."    

Target "Build" <| fun _ -> build()
    

Target "Watch" (fun _ -> 
  use srcWatcher = 
    !! "src/**/*.*"
    ++ "tests/**/*.*"
    |> WatchChanges(fun e -> 
        printfn "Changed files"
        for f in e do printfn " - %s" f.Name
        try
          build()
          runTests()
        with e -> 
          e |> sprintf  "Something bad happened: %A" |>  traceError
      )

  build()
  runTests()
  System.Console.ReadLine() 
  |> ignore
      
  ())


"Build"
    ==> "Test"

RunTargetOrDefault "Build"