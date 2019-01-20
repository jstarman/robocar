namespace RoboCar.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc

[<Route("car/[controller]")>]
[<ApiController>]
type CameraController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let value = "Current Camera Settings"
        ActionResult<string>(value)

    [<HttpGet("up")>]
    member this.Up() =
        ActionResult<string>("up")

    [<HttpGet("down")>]
    member this.Down() =
        ActionResult<string>("down")

    [<HttpGet("left")>]
    member this.Left() =
        ActionResult<string>("left")

    [<HttpGet("right")>]
    member this.Right() =
        ActionResult<string>("right")

    [<HttpGet("home")>]
    member this.Home() =
        ActionResult<string>("home")    
