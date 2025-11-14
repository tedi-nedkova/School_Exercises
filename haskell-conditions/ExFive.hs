main = do
    guests <- getLine
    money <- getLine

    let numberOfGuests = read guests :: Int
    let budget = read money :: Double

    let numberOfKozunak = ceiling (fromIntegral numberOfGuests / 3) 

    let result = fromIntegral numberOfKozunak * 4 + fromIntegral numberOfGuests * 0.45


    if result <= budget
        then do
            putStrLn ("Lyubo bought " ++ show numberOfKozunak ++ "Easter bread and " ++ show numberOfGuests ++ " eggs.")
            let moneyLeft = budget - result
            putStrLn ("He has " ++ show moneyLeft ++" lv. left.")
        else do
            putStrLn ("Lyubo doesn't have enough money.")
            let moneyNeed = result - budget
            putStrLn ("He needs " ++ show moneyNeed ++ " lv. more." )
