main = do
    first <- getLine
    second <- getLine

    let days = read first :: Int
    let money = read second :: Double

    let currency = 1.59 :: Double
    
    let result = fromIntegral (days * (money * currency)) * 0.75 

    putStrLn(show result)


