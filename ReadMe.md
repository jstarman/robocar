# Raspberry Pi 3 Model B
## Setup Direct Connect to laptop

- Download Raspian
- Download install Etcher
- Flash Raspian zip onto SD card via Etcher
- Once flashing is complete, create a new empty file named ssh (with no extension) in the root of the drive that holds the SD card. This will ensure that the SSH daemon is enabled once the Raspberry Pi has started and you can logon over the network.

More detail here: https://blogs.msdn.microsoft.com/david/2017/07/20/setting_up_raspian_and_dotnet_core_2_0_on_a_raspberry_pi/

- Insert SD card into Pi
- Connect power supply
- Connect ethernet to laptop
- Control Panel/Network Connections Ethernet properties -> Sharing -> Allow other network users to connect through this computer’s Internet connection. When Docker installed look for default adapter.
- `ping raspberrypi.mshome.net` to find IP.
- If this doesn't work install an ip scanner https://www.advanced-ip-scanner.com/ Most likely in `192.168.137.0-255` range
- Install Putty use either hostname or found IP, port 22, SSH.
    - Default username pi
    - Default password raspberry
- Watch https://www.youtube.com/watch?v=WBlXvGwkZa8 from 5:38 for more first time setup instructions.

**Stopped here with network issues**

## .Net Core Setup
- https://github.com/pkese/raspberry-fsharp
- Install .net core prerequisites


## Sources

https://github.com/pkese/raspberry-fsharp
https://blogs.msdn.microsoft.com/david/2017/07/20/setting_up_raspian_and_dotnet_core_2_0_on_a_raspberry_pi/
https://www.youtube.com/watch?v=WBlXvGwkZa8
https://github.com/pkese/raspberry-fsharp