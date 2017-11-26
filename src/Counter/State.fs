module Counter.State

open Elmish
open Fable.Core
open Fable.Core.JsInterop
open Types
open Fable.PowerPack
open Fable.PowerPack.Fetch

let init () : Model * Cmd<Msg> =
  Error "nothing yet", []

let update msg (model: Model) =
    match msg with
    | GetGood ->
        model,
        Cmd.ofPromise
            (fun () ->
                promise {
                    let! resp = fetch "http://localhost:3000/good"
                                      [ RequestProperties.Method HttpMethod.GET
                                        requestHeaders [ContentType "application/json" ]]
                    let! text = resp.text()
                    return ofJson<Good> text
                })
            ()
            (fun good -> GotGood good)
            (fun e -> GotError e.Message)
    | GotGood good ->
        Model.Good good, []
    | GetError ->
        model,
        Cmd.ofPromise
            (fun () ->
                promise {
                    let! resp = fetch "http://localhost:3000/error" []
                    return! resp.text()
                })
            ()
            GotError
            (fun e -> GotError e.Message)
    | GotError error ->
        Model.Error error, []
