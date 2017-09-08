module Tests

open System
open FsCheck 
open FsCheck.Xunit
open FizzBuzz

type IntsEvenlyDivisibleBy3And5 = 
    static member Valid() =
        Arb.Default.Int32()
        |> Arb.mapFilter (fun x -> x * 3 * 5)(fun _ -> true)

[<Property>]    
let  ``Fizz when evenly divisible by 3`` d =
    (d % 3 = 0 && d % 5 <> 0) ==> ("Fizz" = fizzBuzz d)

[<Property>]   
let ``Buzz when evenly divisible by 5`` d =
    (d % 5 = 0 && d % 3 <> 0) ==> ("Buzz" = fizzBuzz d)

[<Property(Arbitrary = [| typeof<IntsEvenlyDivisibleBy3And5>|])>]
//[<Property>]
let ``FizzBuzz when evenly divisible by 3 and 5`` d =
    (d % 3 = 0 && d % 5 = 0) ==> ("FizzBuzz" = fizzBuzz d)

[<Property>]
let ``number when not evenly divisible by 3 nor 5`` d = 
    (d % 3 <> 0 && d % 5 <> 0) ==> (sprintf "%A" d = fizzBuzz d)