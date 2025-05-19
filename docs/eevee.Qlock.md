[return](../README.md)
---

## content
- [eevee.Qlock.wrap](#wrap)
- [eevee.Qlock.unwrap](#unwrap)
- [eevee.Qlock.push](#push)
- [eevee.Qlock.extractr](#extractr)
- [eevee.Qlock.clear](#clear)
---

### wrap
- syntax
```c#
eevee.Qlock.wrap(Dictionary<string, eevee.config> FullConfig);
```

- example useage
```c#
eevee.Qlock.wrap(FullConfig);
```
> turns the full config of eevee into json data, for interal processes such as writing to a file

### unwrap
- syntax
```c#
eevee.Qlock.unwrap(string json);
```

- example useage
```c#
eevee.Qlock.unwrap(FullConfig);
```
> turns the json data of the full config back into a c# data struct of eevee.config

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