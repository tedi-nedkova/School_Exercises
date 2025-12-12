sumOdd n = sumOddLoop n 1 1

sumOddLoop n result count =
    if n == count
        then result
    else result + sumOddLoop n (result+2) (count+1)