main = do
    text <- getLine
    let month = read text :: Int
    let result = if month == 12 || month == 1 || month == 2
                    then "Winter"
                    else if month == 3 || month == 4 || month == 5
                        then "Spring"
                        else if month == 6 || month == 7 || month == 8
                            then "Summer"
                            else if month == 9 || month == 10 || month == 11
                                then "Autumn"
                                else "Invalid season"
    putStrLn(result)