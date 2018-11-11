namespace RoboCar.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc

[<Route("car/[controller]")>]
[<ApiController>]
type SteeringController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let value = "Current Steering Settings"
        ActionResult<string>(value)

    [<HttpGet("left")>]
    member this.Left() =
        ActionResult<string>("left")

    [<HttpGet("right")>]
    member this.Right() =
        ActionResult<string>("right")

    [<HttpGet("home")>]
    member this.Home() =
        ActionResult<string>("home")    
