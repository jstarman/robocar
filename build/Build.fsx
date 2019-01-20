#r "paket:
nuget Fake.Core.Target //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core


let dotnetCli cmd  proj =
    let result = 
        CreateProcess.fromRawCommand "dotnet" [cmd; proj]
        |> Proc.run
    if result.ExitCode <> 0 then failwithf "'%s %s' failed to" cmd proj

let projectDir = "../RoboCar.fsproj"

Target.create "Clean" (fun _ ->
    dotnetCli "clean" projectDir
)

Target.create "Build" (fun _ ->
    dotnetCli "build" projectDir
)

Target.create "Default" (fun _ ->
    Trace.trace "Please specify an explicit task"
)

open Fake.Core.TargetOperators

"Clean"
    ==>"Build"
    ==> "Default"

Target.runOrDefault "Default"