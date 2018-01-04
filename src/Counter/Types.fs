module Counter.Types

open Fable.Core

[<Pojo>]
type Data =
    { x: float; y: float }

type Model =
    { Data: Data list
      LastX: int }

type Msg = GetData
