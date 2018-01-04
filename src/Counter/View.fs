module Counter.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fable.Import
open Fable.Import.React
open Fable.Recharts
open Fable.Recharts.Props

//module SVG = Fable.Helpers.React.Props
//
//let lineChartSample (data: Data[]) =
//    lineChart
//        [ Chart.Width 600.
//          Chart.Height 300.
//          Chart.Data data
//          Chart.Margin { top = 5.0; bottom = 5.0; right = 20.0; left = 0.0 }
//        ]
//        [ line
//            [ Cartesian.Type Monotone
//              Cartesian.DataKey "y"
//              SVG.Stroke "#8884d8"
//              SVG.StrokeWidth 1.5
//              Cartesian.IsAnimationActive false ]
//            []
//
//          cartesianGrid
//            [ SVG.Stroke "#ccc"
//              SVG.StrokeDasharray "5 5" ]
//            []
//
//          xaxis [ Cartesian.DataKey "x"] []
//          yaxis [] []
//          tooltip [] []
//        ]

[<Pojo>]
type Metrics =
    { danger: float
      normal: float }

[<Pojo>]
type Connection =
    { source: string
      target: string
      metrics: Metrics
      ``class``: string }

[<Pojo>]
type Node =
    { renderer: string
      name: string
      maxVolume: int
      ``class``: string
      updated: float
      nodes: Node[]
      connections: Connection[] }

[<Pojo>]
type Modes =
    { detailedNode: string }

[<RequireQualifiedAccess>]
type Vizceral =
    | AllowDraggingOfNodes of bool
    | ShowLabels of bool
    | TargetFramerate of int
    | Traffic of Node
    | View of obj[]
    | Modes of Modes
    interface IProp

let vizceralEl : obj = importDefault "vizceral-react"

let inline vizceral (props: IProp list) (children: React.ReactElement list) : React.ReactElement =
    createElement (vizceralEl, keyValueList CaseRules.LowerFirst props, children)

let data =
    { renderer = "global"
      name = "edge"
      maxVolume = 0
      updated = 0.
      ``class`` = "normal"
      nodes =
        [| { renderer = "region"
             name = "INTERNET"
             ``class`` = "normal"
             maxVolume = 0
             updated = 0.
             nodes = [||]
             connections = [||] }
           { renderer = "region"
             name = "us-east-1"
             maxVolume = 50000
             ``class`` = "normal"
             updated = 1466838546805.
             nodes =
               [| { name = "INTERNET"
                    renderer = "focusedChild"
                    ``class`` = "normal"
                    maxVolume = 0
                    updated = 0.
                    nodes = [||]
                    connections = [||]}
                  { name = "proxy-prod"
                    renderer = "focusedChild"
                    ``class`` = "normal"
                    maxVolume = 0
                    updated = 0.
                    nodes = [||]
                    connections = [||] }
               |]

             connections =
               [| { source = "INTERNET"
                    target = "proxy-prod"
                    metrics =
                      { danger = 116.524
                        normal = 15598.906 }
                    ``class`` = "normal" }
               |] }
        |]
      connections =
        [| { source = "INTERNET"
             target = "us-east-1"
             metrics =
               { normal = 26037.626
                 danger = 92.37 }
             ``class`` = "normal" }
        |]
    }

let root model dispatch =
  div
    [ Class "vizceral-container" ]
    [ vizceral
        [ Vizceral.Traffic data
          Vizceral.View [||]
          Vizceral.Modes { detailedNode = "volume" }
        ]
        []
    ]
