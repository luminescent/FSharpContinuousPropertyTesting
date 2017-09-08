module FizzBuzz 

// Write a program that prints the numbers from 1 to 50. 
// But for multiples of three print "Fizz" instead of the number and for the multiples of five print "Buzz". 
// For numbers which are multiples of both three and five print "FizzBuzz".


// Create active patterns for multiples 
let (|MultipleOf3|_|) i = if i % 3 = 0 then Some MultipleOf3 else None
let (|MultipleOf5|_|) i = if i % 5 = 0 then Some MultipleOf5 else None 

// the main function
let fizzBuzz i = 
  match i with
  | MultipleOf3 & MultipleOf5 -> "FizzBuzz" 
  | MultipleOf3 -> "Fizz" 
  | MultipleOf5 -> "Buzz" 
  | _ -> sprintf "%i" i   