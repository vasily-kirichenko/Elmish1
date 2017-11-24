module Home.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma
open Fulma.Elements

let root model dispatch =
  div []
    [ Button.button_btn [ Button.isSuccess; Button.isOutlined ] [ str "I'm static" ]
      str " "
      Button.button_btn
        [ Button.isOutlined
          (match model with On -> Button.isSuccess | Off -> Button.isDanger)
          Button.onClick (fun _ ->
            let desiredState = match model with On -> Off | Off -> On
            dispatch (SwitchTo desiredState)) ]
        [ str (match model with On -> "off" | Off -> "on") ]
    ]
