main = do
    days <- getLine
    food <- getLine
    foodFirstCat <- getLine
    foodSecondCat <- getLine

    let numberOfDays = read days :: Int
    let foodLeft = read food :: Int
    let foodPerDayFirstCat = read foodFirstCat :: Double
    let foodPerDaySecondCat = read foodSecondCat :: Double

    let result = fromIntegral numberOfDays * (foodPerDayFirstCat + foodPerDaySecondCat)

    let foodAvailable = fromIntegral foodLeft :: Double

    if foodAvailable >= result
        then do
            let foodRemaining = ceiling (foodAvailable - result)
            putStrLn "The cats are well fed."
            putStrLn (show foodRemaining ++ " kilos of food left.")
        else do
            let foodMissing = floor (result - foodAvailable)
            putStrLn "The cats are hungry."
            putStrLn (show foodMissing ++ " more kilos of food are needed.")
