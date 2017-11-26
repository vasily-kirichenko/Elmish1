module Counter.Types

type Good =
    { message: string }

type Model =
    | Good of Good
    | Error of string

type Msg =
    | GetGood
    | GotGood of Good
    | GetError
    | GotError of string
