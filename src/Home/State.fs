module Home.State

open Elmish
open Fable.PowerPack
open Types

let init () : Model * Cmd<Msg> = On, []

let update msg model : Model * Cmd<Msg> =
  match msg with
  | SwitchTo state ->
      model,
      Cmd.ofPromise
        (fun () -> Promise.sleep 1000)
        ()
        (fun () -> Switched state)
        (fun _ -> Switched state)
  | Switched state ->
      state, []
