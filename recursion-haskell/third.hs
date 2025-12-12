pow3 n = pow3loop n 0 1

pow3loop n i x =
    if n == i
        then x
    else pow3loop n (i+1) (x*3)

sum3 n = sum3loop n 1

sum3loop number count=
    if count == number
        then (pow3 count)
    else (pow3 count) + (sum3loop number (count+1))