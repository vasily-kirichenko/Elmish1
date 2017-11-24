module Home.Types

type Model =
    | On
    | Off

type Msg =
  | SwitchTo of Model
  | Switched of Model
