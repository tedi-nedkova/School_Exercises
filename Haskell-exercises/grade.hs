main = do
    text <- getLine
    let score = read text :: Int
    let result = if 90 <= score
                    then "Otlichen"
                    else if score >= 75 && score <= 89
                        then "Mnogo dobur"
                        else if score >= 50 && score <= 74
                            then "Dobur"
                            else "Slab"
    putStrLn(result)