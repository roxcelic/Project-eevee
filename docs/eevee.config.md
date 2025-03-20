[return](../README.md)
---

## content
- [eevee.config](#config)
- [eevee.config.KEYBOARD_code](#config)
- [eevee.config.config.CONTROLLER_name](#configcontroller_name)
- [eevee.config.config.CONTROLLER_name.xbox](#configcontroller_namexbox)
- [eevee.config.config.CONTROLLER_name.ps5](#configcontroller_nameps5)
---

### config
- syntax
```c#
[System.Serializable]
public class config {
    [Header("general")]
    public string displayName;
    public bool Pressed;

    [Header("keyboard")]
    public int KEYBOARD_code;
        
    [Header("controller")]
    public string CONTROLLER_name;
}
```
- displayName is the name that you will request it with
- Pressed is the value that will dictate if its pressed or not
- KEYBOARD_code is the keycode of the input
- CONTROLLER_name is the display name of the input on the controller

### config.KEYBOARD_code
personally i find the best way to set this is with:
```c#
(int)KeyCode.Q
```
So i can still use keyCode values for it.

### config.CONTROLLER_name
here i will list the display names for all the buttons on the xbox and ps5 controllers:
- ### config.CONTROLLER_name.xbox
    - Left joystick
        - `Left Stick Up`
        - `Left Stick Left`
        - `Left Stick Down`
        - `Left Stick Right`
        - `Left Stick Press`
    - Right joystick
        - `Right Stick Up`
        - `Right Stick Left`
        - `Right Stick Down`
        - `Right Stick Right`
        - `Right Stick Press`
    - triggers
        - `Left Trigger`
        - `Right Trigger`
        - `Left Bumper`
        - `Right Bumper`
    - dpad
        - `D-Pad Up`
        - `D-Pad Left`
        - `D-Pad Down`
        - `D-Pad Right`
    - pause Buttons
        - `Select`
        - `Start`
    - main Buttons
        - `A`
        - `B`
        - `X`
        - `Y`
- ### config.CONTROLLER_name.ps5
    - Left joystick
        - `Left Stick Up`
        - `Left Stick Left`
        - `Left Stick Down`
        - `Left Stick Right`
        - `L3`
    - Right joystick
        - `Right Stick Up`
        - `Right Stick Left`
        - `Right Stick Down`
        - `Right Stick Right`
        - `R3`
    - triggers
        - `L2`
        - `R2`
        - `Left Trigger`
        - `Right Trigger`
        - `L1`
        - `R1`
    - dpad
        - `D-Pad Up`
        - `D-Pad Left`
        - `D-Pad Down`
        - `D-Pad Right`
    - pause Buttons
        - `Share`
        - `Options`
    - main Buttons
        - `Cross`
        - `Circle`
        - `Square`
        - `Triangle`
    - touchpad
        - `Touchpad Press`
    - System
        - `System`