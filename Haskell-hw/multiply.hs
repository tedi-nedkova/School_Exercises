main = do
    firstNumber <- getLine
    secondNumber <- getLine
    let firstNumberDouble = read firstNumber :: Double
    let secondNumberDouble = read secondNumber :: Double
    let multiply = firstNumberDouble * secondNumberDouble
    putStrLn (show multiply)
