[return](../README.md)
---

## content
- [eevee.inject.install](#install)
- [eevee.inject.add](#add)
- [eevee.inject.OverWrite](#OverWrite)
- [eevee.inject.parasite](#parasite)
- [eevee.inject.retrieve](#retrieve)
---

### install
- syntax
```c#
eevee.inject.install(Dictionary<string, eevee.config> config)
```

- example useage
```c#
public Dictionary<string, eevee.config> config = new Dictionary<string, eevee.config>() {
	{
        "right", new eevee.config {
            displayName = "right",
            KEYBOARD_code = (int)KeyCode.D,
            CONTROLLER_name = "Left Stick Right"
        }
    },
    {
        "left", new eevee.config {
            displayName = "left",
            KEYBOARD_code = (int)KeyCode.A,
            CONTROLLER_name = "Left Stick Left"
        }
    },
    {
        "up", new eevee.config {
            displayName = "up",
            KEYBOARD_code = (int)KeyCode.W,
            CONTROLLER_name = "Left Stick Up"
        }
    },
    {
        "down", new eevee.config {
            displayName = "down",
            KEYBOARD_code = (int)KeyCode.S,
            CONTROLLER_name = "Left Stick Down"
        }
    }
};

void Start() {
    eevee.inject.install(config);
}
```

> this will inject an input config into the eevee parasite, it will save so you do not have to inject this in every scene

>! **THE KEY FOR THE CONFIG SHOULD BE THE SAME AS THE DISPLAY NAME**

### add
- syntax
```c#
eevee.inject.add(eevee.config);
```

- example useage
```c#
public eevee.config config = new eevee.config {
            displayName = "right",
            KEYBOARD_code = (int)KeyCode.D,
            CONTROLLER_name = "Left Stick Right"
        };

void Start() {
    eevee.inject.add(config);
}
```

> This will add a single config to your config. This will also save

### OverWrite
- syntax
```c#
eevee.inject.OverWrite(eevee.config);
```

- example useage
```c#
public eevee.config config = new eevee.config {
            displayName = "right",
            KEYBOARD_code = (int)KeyCode.D,
            CONTROLLER_name = "Left Stick Right"
        };

void Start() {
    eevee.inject.add(config);
}
```

> This does the same thing as add but i got confused with the naming :3

### Parasite
- syntax
```c#
eevee.inject.Parasite();
```

- example useage
```c#
void Start() {
    eevee.inject.Parasite();
}
```

> You do not need to use this ever, the library will spawn it in when needed

### retrieve
- syntax
```c#
eevee.inject.retrieve();
```

- example useage
```c#
void Start() {
    eev eevee = eevee.inject.retrieve();
}
```

> This will return the `eev` component on the parasite