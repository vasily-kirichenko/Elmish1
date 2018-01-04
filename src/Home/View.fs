module Home.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import
open Types
open Fulma
open Fulma.Elements

//[<Import("edit", "../../node_modules/ace-code-editor/lib/ace/ace.js")>]
//let aceEdit : string -> obj = jsNative

let root model dispatch =
  div []
    [ Button.button_a [ Button.isSuccess; Button.isOutlined ] [ str "I'm static" ]
      str " "
      Button.button_a
        [ Button.isOutlined
          (match model with On -> Button.isSuccess | Off -> Button.isDanger)
          Button.onClick (fun _ ->
            let desiredState = match model with On -> Off | Off -> On
            dispatch (SwitchTo desiredState)) ]
        [ str (match model with On -> "off" | Off -> "on") ]
      Button.button_a [ Button.onClick (fun _ -> Browser.location.reload(true) ) ] [ str "Reload!" ]
    ]
