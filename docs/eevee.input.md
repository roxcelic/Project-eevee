[return](../README.md)
---

## content
- [eevee.input.Collect](#collect)
- [eevee.input.Check](#check)
- [eevee.input.CheckAxis]()
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

### CheckAxis
- syntax
```c#
eevee.input.CheckAxis("right", "left");
```

- example useage
```c#
int Horizontal = eevee.input.Check("right")?1:eevee.input.Check("left")?-1:0;
int Vertical = eevee.input.Check("up")?1:eevee.input.Check("down")?-1:0;
```

> returns an axis response to an input: 1 for positive; 0 for neutral; -1 for negative
