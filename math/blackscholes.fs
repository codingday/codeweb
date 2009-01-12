#light
// This code was transliterated from the OCAML code
// located here http://www.espenhaug.com/black_scholes.html
let pow x n = exp (n * log(x) ) 
let cnd x =
   let a1 =  0.31938153
   let a2 = -0.356563782
   let a3 =  1.781477937
   let a4 = -1.821255978
   let a5 =  1.330274429
   let pi = 4.0 * atan 1.0
   let l  = abs(x)
   let k  = 1.0 / (1.0 + 0.2316419 * l)
   let w  = ref (1.0-1.0/sqrt(2.0*pi)*exp(-l*l/2.0)*(a1*k+a2*k*k+a3*(pow k 3.0)+a4*(pow k 4.0)+a5*(pow k 5.0)))
   if (x < 0.0) then  w := 1.0 - !w
   !w
// call_put_flag: 'c' if call option; otherwise put option
// s: stock price
// x: strike price of option
// t: time to expiration in years
// r: risk free interest rate
// v: volatility
let black_scholes call_put_flag s x t r v =
   let d1=(log(s / x) + (r+v*v/2.0)*t)/(v*sqrt(t))
   let d2=d1-v*sqrt(t)
   let res = ref 0.0
   if (call_put_flag = 'c') then
      res := s*cnd(d1)-x*exp(-r*t)*cnd(d2)
   else
      res := x*exp(-r*t)*cnd(-d2)-s*cnd(-d1)
   !res

> black_scholes 'c' 60.0 65.0 0.25 0.08 0.3;;
val it : float = 2.133371862
> black_scholes 'p' 60.0 65.0 0.25 0.08 0.3;;
val it : float = 5.846285627