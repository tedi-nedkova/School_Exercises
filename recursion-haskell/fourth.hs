sumEvenDigits n = sumEvenDigitsLoop n 0

sumEvenDigitsLoop number sum = 
    if number == 0
        then sum
        else
            if (number `mod` 10) `mod` 2 == 0
                then sumEvenDigitsLoop (number `div` 10) (sum + (number `mod` 10))
                else sumEvenDigitsLoop (number `div` 10) sum
