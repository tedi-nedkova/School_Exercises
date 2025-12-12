progression n = arithmeticProgression n 1 5 1

arithmeticProgression n firstNumber difference count =
    if n == count
        then firstNumber
    else
         arithmeticProgression n (firstNumber + difference) difference (count+1)