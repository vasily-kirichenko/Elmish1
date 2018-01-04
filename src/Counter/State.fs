module Counter.State

open Elmish
open Fable.Core
open Fable.Core.JsInterop
open Types
open Fable.PowerPack
open System

let init () : Model * Cmd<Msg> =
    let rnd = Random()
    { Data = [ for x in 0..100 -> { x = float x; y = float (rnd.Next 1000) } ]
      LastX = 100 },
    Cmd.ofMsg GetData

let update msg (model: Model) = model, []
//    match msg with
//    | GetData ->
//        let rnd = Random()
//        let data =
//            [ yield! List.tail model.Data
//              yield { x = float (model.LastX + 1); y = float (rnd.Next 1000) } ]
//
//        { model with LastX = model.LastX + 1; Data = data },
//        Cmd.ofPromise
//            (fun () -> Promise.sleep 1000) ()
//            (fun () -> Msg.GetData)
//            (fun _ -> Msg.GetData)
