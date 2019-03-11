namespace RoboCar.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc

[<Route("")>]
[<ApiController>]
type CheckController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let value = "RoboCar"
        ActionResult<string>(value)