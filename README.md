## Project Eevee

Project eevee is a Unity plugin which will revamp the unity input system, the reason why I chose to make this is because id like to create custom input mappings in run time which unity has an issue with for some reason.

## dependencys
Built for unity `v6000.042f1`
`UnityEngine`
`System`
---
more specifically (End users will not have to worry about this):
- `UnityEngine`
- `UnityEngine.InputSystem`
- `UnityEngine.InputSystem.Controls`

- `System`
- `System.IO`
- `System.Linq`
- `System.Collections`
- `System.Collections.Generic`

## installation
I recommend placing the [main file](./eevee.cs) within the `/assets/plugins/eevee/eevee.cs` directory once youve done this you will be able to use all methods from this library in any file as it is a global namespace not a library persay.

## usage
- ### [var](./docs/eevee.var.md)
- ### [inject](./docs/eevee.inject.md)
- ### [input](./docs/eevee.input.md)
- ### [Qlock](./docs/eevee.Qlock.md)
- ### [Config](./docs/eevee.config.md)

Thank you for using Eevee!
> updates may subject this to change
<br>

> If you use Eevee please credit [me](https://github.com/roxcelic) for eevee, this isnt a demand but a request as I understand some people wouldnt desire to do that.

## 1.0.5
as of 1.0.5 we now have the same amount of range as basic unity I/O systems but this has the ability to add configs at runtime. One Key thing is that: **ALL DELAYS AND INPUT STORAGE ARE UNIVERSAL** This results in not being able to have multiple objects being able to check an input at any one time. This shouldnt be an issue as in most typical use and recommended use you will only be checking inputs on the character, but for some projects this wont always be the case, if anyone using this has such an issue I will attempt to find a work around but i do not beleive (in the given nature of this project) that would be possible. 

*As well as it only supporting a single gamepad but that is also how the base unity input system works so i do not feel that is as of the same importance.*

> Its possible that in the future i will make a secondary version that will use Lists of each config so you can assign multiple buttons to each input.