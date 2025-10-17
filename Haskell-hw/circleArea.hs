main = do
    let pi = 3.14 :: Double
    r <- getLine
    let rDouble = read r :: Double
    let result = rDouble * rDouble * pi
    putStrLn (show result)
