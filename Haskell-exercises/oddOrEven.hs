main = do
    number <- getLine
    let intNumber = read number :: Int
    let result = if intNumber `mod` 2 == 0 
                    then "It is even."
                    else "It is odd."
    putStrLn result
