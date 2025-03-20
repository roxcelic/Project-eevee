[return](../README.md)
---

## content
- [eevee.input.Collect](#collect)
- [eevee.input.Check](#check)
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
