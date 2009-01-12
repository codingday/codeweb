#light
//codingday
open System
(* Pi Similation*)
let ran = new Random()
let next()= ran.NextDouble() 

let approx t = let points = Seq.init_finite t (fun i-> pown (next()) 2,pown (next()) 2)
               points |> Seq.fold (fun  i (x,y) -> if (sqrt(x+y) <= 1.) then i+1. else i ) 0.   

let pi = let m= 1000000
         4. * (approx m) / double(m)                            

(* Battle ship *)

let battleship = | 
(*Type of ship 	Size
aircraft carrier 	
5
battleship 	
4
destroyer 	
3
submarine 	
3
patrol boat 	
2 *)
let gameboard = 