[return](../README.md)
---

## content
- [eevee.input.Collect](#collect)
- [eevee.input.Check](#check)
- [eevee.input.Grab](#Grab)
- [eevee.input.CheckAxis](#checkaxis)
- [eevee.input.CheckAxis](#CollectAxis)
---

### Collect
- syntax
```c#
eevee.input.Collect(string inputName)
```

- example useage
```c#
void Update() {
    if (eevee.input.Collect("left")){
        Debug.Log("left");
    }
}
```
> will return periodically return true when the input is pressed and held, starting with a delay of 0.5s aand then decreasing to the low of 0.05s

### Grab
- syntax
```c#
eevee.input.Grab(string inputName)
```

- example useage
```c#
void Update() {
    if (eevee.input.Grab("left")){
        Debug.Log("left");
    }
}
```
> will return if the input was pressed, only returns once any call after while the button is held will return false

### Check
- syntax
```c#
eevee.input.Check(string inputName)
```

- example useage
```c#
void Update() {
    if (eevee.input.Check("left")){
        Debug.Log("left");
    }
}
```

> will return if the input is pressed or not, no delay

### CheckAxis
- syntax
```c#
eevee.input.CheckAxis("right", "left");
```

- example useage
```c#
int Horizontal = eevee.input.CheckAxis("right", "left");
int Vertical = eevee.input.CheckAxis("up", "down");
```

> returns an axis response to an input: 1 for positive; 0 for neutral; -1 for negative

### CollectAxis
- syntax
```c#
eevee.input.CollectAxis("right", "left");
```

- example useage
```c#
int Horizontal = eevee.input.CollectAxis("right", "left");
int Vertical = eevee.input.CollectAxis("up", "down");
```

> Does the same as Check axis but does it with the collect delay
