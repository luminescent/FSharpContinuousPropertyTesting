module Max

let findMax arr = 
    match arr with 
    | [||] -> None 
    | _ -> 
        arr
        |> Array.fold(fun max item -> if max < item then item else max) arr.[0]
        |> Some