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
- Control Panel/Network Connections Ethernet properties -> Sharing -> Find wifi adapter and check allow other network users to connect through this computer’s Internet connection. Select connected network adapter. When Docker installed or hyper-v running look for default adapter or disable all others.
- Install an ip scanner https://www.advanced-ip-scanner.com/ Most likely in `192.168.137-138.0-254` range
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
- Install the OpenSSH windows 10 feature
  
  https://blogs.msdn.microsoft.com/powershell/2017/12/15/using-the-openssh-beta-in-windows-10-fall-creators-update-and-windows-server-1709/

- Create passwordless key 
- Move public key to pi host
`cat ~/.ssh/id_rsa.pub | ssh pi@<IP-ADDRESS> 'mkdir -p ~/.ssh && cat >> ~/.ssh/authorized_keys'`
- Then `PS [app root]> ssh raspberry`

- Other using putties file transfer tool test transferring files.
  - `PS [app root]> pscp .\ReadMe.md pi@192.168.0.20:robot`

## Bootstrap app
`PS[app root]\build> .\bootstrap.cmd`

## Run specific build targets
Run local clean and build 

`PS[app root]\build>  .\fake build`

Run specific target like publish to pi

`PS[app root]\build>  .\fake build -t PublishToPi`

## Run
Local

`./robocar > dotnet run`

On Rpi

`pi@raspberrypi:~/robot $ ./RoboCar`

Test 

`pi@raspberrypi:~ $ curl localhost:5000`


## Troubleshooting 
- Find used ports `sudo netstat -ltp`
- Kill process using port `kill [PID]`

## Reverse Proxy Setup
To run app on default ports 80/443

`pi@raspberrypi ~ $ sudo apt install haproxy`

Edit Rpi config `/etc/haproxy/haproxy.cfg`
Sample config `.\misc\haproxy.cfg`

Restart service `sudo service haproxy restart`

Logs for troubleshooting at `var/log/haproxy.log`

`pi@raspberrypi:/var/log $ sudo nano haproxy.log`

Find Robocar site at: 
http://192.168.0.20
http://192.168.0.20/car/camera

## Setup RoboCar As Service
Run .net core as service for automatic startup.

Rpi config at `/lib/systemd/system/robocar.system`

Sample config at `.\misc\robocar.system`

** Next: Stop service prior to rebuild **
** Next: Create Petite rebuild to cut down build to RPI time **
** Next: Research streaming mjpeg through site **

## Sources 

https://github.com/pkese/raspberry-fsharp
https://blogs.msdn.microsoft.com/david/2017/07/20/setting_up_raspian_and_dotnet_core_2_0_on_a_raspberry_pi/
https://www.youtube.com/watch?v=WBlXvGwkZa8
https://github.com/pkese/raspberry-fsharp
http://www.circuitbasics.com/how-to-connect-to-a-raspberry-pi-directly-with-an-ethernet-cable/
http://www.gregtrowbridge.com/setting-up-a-multiple-raspberry-pi-web-server-part-5/
https://www.thomaslevesque.com/2018/04/17/hosting-an-asp-net-core-2-application-on-a-raspberry-pi/
