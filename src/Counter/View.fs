module Counter.View

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types

let simpleButton txt action dispatch =
  div
    [ ClassName "column is-narrow" ]
    [ a
        [ ClassName "button"
          OnClick (fun _ -> action |> dispatch) ]
        [ str txt ] ]

let root model dispatch =
  div
    [ ClassName "columns is-vcentered" ]
    [ div [ ClassName "column" ] [ ]
      div
        [ ClassName "column is-narrow"
          Style
            [ CSSProp.Width "170px" ] ]
        [ str (sprintf "Value: %A" model) ]
      simpleButton "get good" GetGood dispatch
      simpleButton "get error" GetError dispatch
      div [ ClassName "column" ] [ ] ]
