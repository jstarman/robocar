#r "paket:
nuget Fake.Core.Target //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.IO.Globbing.Operators

let dotnetCli args  = 
    let result = 
        CreateProcess.fromRawCommand "dotnet" args
        |> Proc.run
    if result.ExitCode <> 0 then failwithf "dotnet failed"

let scpCli fileName  =
    printfn "Uploading %s to pi@192.168.0.20:~/robot/" fileName
    let result = 
        CreateProcess.fromRawCommand "scp" [ fileName; "pi@192.168.0.20:~/robot/" ]
        |> Proc.run
    if result.ExitCode <> 0 then failwithf "scp failed"

let projectDir = "../RoboCar.fsproj"

Target.create "Clean" (fun _ ->
    dotnetCli ["clean"; projectDir]
)

Target.create "Build" (fun _ ->
    dotnetCli ["build"; projectDir]
)

Target.create "Default" (fun _ ->
    Trace.trace "Please specify an explicit task"
)

Target.create "PublishToPi"(fun _ ->
    Trace.trace "Running publish to pi"
    let args = [ "publish"; projectDir; "-r"; "linux-arm"; "-o"; "./bin/linux-arm/publish" ]
    String.concat " " args |> printfn "dotnet %s"
    dotnetCli args
    !! "../bin/linux-arm/publish/*"
    |> Seq.iter scpCli
)

open Fake.Core.TargetOperators

"Clean"
    ==>"Build"
    ==> "Default"

"Clean"
    ==>"Build"
    ==>"PublishToPi"

Target.runOrDefaultWithArguments "Default"