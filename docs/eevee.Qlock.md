[return](../README.md)
---

## content
- [eevee.Qlock.push](#push)
- [eevee.Qlock.clear](#clear)
- [eevee.Qlock.extractr](#extractr)
---

### push
- syntax
```c#
eevee.Qlock.push();
```

- example useage
```c#
void Start(){
    eevee.Qlock.push();
}
```
> will save the current config to the file, you do not need to do this it does this automatically

### clear
- syntax
```c#
eevee.Qlock.clear();
```

- example useage
```c#
void Start(){
    eevee.Qlock.clear();
}
```
> will delete the current config and clear it from memory

### extractr
- syntax
```c#
eevee.Qlock.extractr();
```

- example useage
```c#
void Start(){
    new Dictionary<string, eevee.config>(eevee.Qlock.extractr());
}
```
> will return the current config