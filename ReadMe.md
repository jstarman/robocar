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
- If this doesn't work install an ip scanner https://www.advanced-ip-scanner.com/ Most likely in `192.168.138.0-255` range
- If this still doesn't work disable and reenable network adapters and sharing.
- Install Putty use either hostname or found IP, port 22, SSH.
    - Default username pi
    - Default password raspberry
- Watch https://www.youtube.com/watch?v=WBlXvGwkZa8 from 5:38 for more first time setup instructions.
- Once VNC viewer is setup up remote in and turn on/setup wifi
- Find Ip assigned to raspberry `hostname -I`
- Reboot and turn off remote session and disconnect. You can now connect through wifi connection via VNC viewer or putty.
- For subsequent session boot up Pi and find IP of Pi on network via ipscanner. Probably in this range `192.168.0.0-255`
- 

## .Net Core Setup
- https://github.com/pkese/raspberry-fsharp
- Install .net core prerequisites
- Had to go hunt down lastest version of .net core ARM32 runtime. Substitute instructions above.

## Test ssh connection**
- Using putties file transfer tool test transferring files.
- with putty `PS [app root]> pscp .\ReadMe.md pi@192.168.0.20:robot`
- Other: install the OpenSSH windows 10 feature
- Create key https://blogs.msdn.microsoft.com/powershell/2017/12/15/using-the-openssh-beta-in-windows-10-fall-creators-update-and-windows-server-1709/
- Move public key to pi host
- Then `PS [app root]> ssh raspberry`

## Bootstrap app
`PS[app root]\build> .\bootstrap.cmd`

## Run specific build targets
Run local clean and build 

`PS[app root]\build>  .\fake build`

Run specific target like publish to pi

`PS[app root]\build>  .\fake build -t PublishToPi`

** Next: ssh without password and setup automated build via ssh **

## Sources

https://github.com/pkese/raspberry-fsharp
https://blogs.msdn.microsoft.com/david/2017/07/20/setting_up_raspian_and_dotnet_core_2_0_on_a_raspberry_pi/
https://www.youtube.com/watch?v=WBlXvGwkZa8
https://github.com/pkese/raspberry-fsharp
http://www.circuitbasics.com/how-to-connect-to-a-raspberry-pi-directly-with-an-ethernet-cable/