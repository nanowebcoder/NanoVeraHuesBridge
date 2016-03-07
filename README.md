# NanoVeraHuesBridge
A C# version of a Philips Hues Bridge which allows Amazon Echo to speak to Vera and control lights, doors, stereos and more.

Based on Armzilla's ecellent JAVA version, located at https://github.com/armzilla/amazon-echo-ha-bridge, this version is written in C# 
and runs a bit leaner on Windows than the the JAVA heap does.  In our testing, memory usage goes from about 300mb down to 15mb.  

It also includes an installer, a native Windows service, and a Windows configuration application (while remaining backward compatible with the  web configurator from the original Armzilla project).

It stores its configuration in a plain text file, which makes it easier to maintain and backup.

Finally, it uses nLog for logging, and out of the box will write a rolling set of plain text log files, although nLog will allow practically any log file output needed.

