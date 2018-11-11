namespace RoboCar.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc

[<Route("car/[controller]")>]
[<ApiController>]
type MotorController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let value = "Current Motor Settings"
        ActionResult<string>(value)

    [<HttpGet("forward/{id}")>]
    member this.Foward(id:int) =
        let value = sprintf "forward %i"  id
        ActionResult<string>(value)

    [<HttpGet("backward/{id}")>]
    member this.Backward(id:int) =
        let value = sprintf "backward %i"  id
        ActionResult<string>(value)

    [<HttpGet("speed/{id}")>]
    member this.Speed(id:int) =
        let value = sprintf "speed %i"  id
        ActionResult<string>(value)

    [<HttpPost>]
    member this.Post([<FromBody>] value:string) =
        ()

    [<HttpPut("{id}")>]
    member this.Put(id:int, [<FromBody>] value:string ) =
        ()

    [<HttpDelete("{id}")>]
    member this.Delete(id:int) =
        ()
