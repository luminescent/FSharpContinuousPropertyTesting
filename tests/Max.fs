module Tests.Max 

open Max 
open FsCheck
open FsCheck.Xunit

// we are now testing the properties of max 

type EmptyArray =
    static member Valid() =
        Arb.Default.Array()
        |> Arb.mapFilter(fun x -> Array.empty)(fun _ -> true)

type NonEmptyArray =
    static member Valid() = 
        Arb.Default.Array()
        |> Arb.mapFilter(id)(Array.isEmpty >> not)

[<Property(Arbitrary=[|typeof<EmptyArray>|])>]
let ``there is no max in an empty array`` (arr: int array) = 
    (true) ==> (
        arr
        |> findMax
        |> Option.isNone
    )

[<Property(Arbitrary = [|typeof<NonEmptyArray>|])>]
let ``max is an element of the non empty list`` (arr: int array) = 
    (true) ==> (   
            printfn "%A" arr
            let max = (arr
                |> findMax).Value
            arr
            |> Array.tryFind (fun i -> i = max)
            |> Option.isSome
        )
        
[<Property(Arbitrary = [|typeof<NonEmptyArray>|])>]
let ``any other element is smaller or equal than max`` (arr: int array) = 
    (true) ==> (   
            printfn "%A" arr
            let max = (arr
                |> findMax).Value
            arr
            |> Array.tryFind (fun i -> i >= max)
            |> Option.isSome
        )
