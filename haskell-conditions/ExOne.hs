main = do
    putStr "a = "
    a <- getLine
    putStr "b = "
    b <- getLine
    putStr "h = "
    h <- getLine

    let aNumber = read a :: Double
    let bNumber = read b :: Double
    let hNumber = read h :: Double

    let area = (aNumber + bNumber)/2 * hNumber
    let result = area * 900

    putStrLn("Liceto na trapeca e " ++ show area ++ "kv. m")
    putStrLn("Basein na plosht " ++ show area ++ "kv. m se pulni s " ++ show result ++ " litra voda")
    