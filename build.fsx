#r "packages/FAKE/tools/FakeLib.dll"
open Fake
open DotNetCli


let test() =
    trace "Start testing..."
    DotNetCli.Test (fun t -> 
                            {t with WorkingDir = "tests"})

Target "Test" <| fun _ -> test()

let build() = 
    trace "Start building..."

    Paket.Restore id
    DotNetCli.Build id

    trace "Done building..."    

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
          test()
        with e -> 
          e |> sprintf  "Error: %A" |>  traceError
      )

  System.Console.ReadLine() 
  |> ignore
      
  ())


"Build"
    ==> "Test"

RunTargetOrDefault "Build"