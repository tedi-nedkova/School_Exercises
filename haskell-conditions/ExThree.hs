main = do
    number <- getLine
    jackets <- getLine
    helmets <- getLine
    shoes <- getLine

    let skiers = read number :: Int
    let numberOfJackets = read jackets :: Int
    let numberOfHelmets = read helmets :: Int
    let numberOfShoes = read shoes :: Int

    let result = fromIntegral skiers * 
                 ((fromIntegral numberOfJackets * 120) 
                 + (fromIntegral numberOfHelmets * 75) 
                 + (fromIntegral numberOfShoes * 299.90))

    let saleResult = result * 0.85

    putStrLn ("Suma za vsichki skiori " ++ show result ++ " lv.")
    putStrLn ("Sled namalenie ot " ++ show result ++ " trqbva da zaplatite " ++ show saleResult ++ " lv.")
