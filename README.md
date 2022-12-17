# TheftShot

> There is some security problems on the project. But tbh, I don't want to handle that.
>
> If you want to, feel free to do it.

TheftShot is a basic project. It build a windows service and his installer.

The TheftShot service do something very basic.
It take a picture through the webcam when it start (delayed of 60s), and log in a file when it start and stop.
This is useful to take picture of who start the computer and duration of the sessions.
All files are save in `C:\Temp\TheftShot`

The service include a basic server to send the file outside. But the function is not yet in the service.
