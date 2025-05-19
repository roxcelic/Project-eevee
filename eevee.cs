using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace eevee {
    // variables
    public class var {
        public static string name = "eevee-1.0.5";
        public static string ConfPath = Path.Combine(Application.persistentDataPath, "EeveeConfig.json");
    }
    
    // controll config
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

    [System.Serializable]
    public class KeyValue {
        public string key;
        public eevee.config value;
    }

    [System.Serializable]
    public class ConfigWrapper {
        public List<KeyValue> configData;
    }

    // livespace
    //  eevee.inject.install();
    //  eevee.inject.add();
    //  eevee.inject.OverWrite(); -- does the same thing as add but i got confused with the naming
    //  eevee.inject.Parasite();
    //  eevee.inject.retrieve(); -- returns the parasite
    public class inject {
        static inject() {
            Parasite();
        }

        public static void install(Dictionary<string, eevee.config> config) {
            eev eevee = retrieve();
            eevee.FullConfig = config;
            Qlock.push();
        }

        public static void add(eevee.config config) {
            eev eevee = retrieve();
            eevee.FullConfig[config.displayName] = config;
            Qlock.push();
        }

        public static void OverWrite(eevee.config config) {
            eev eevee = retrieve();
            eevee.FullConfig[config.displayName] = config;
            Qlock.push();
        }
        
        public static void Parasite() {
            if (GameObject.Find(var.name) == null){
                GameObject Parasect = new GameObject();
                Parasect.name = var.name;
                Parasect.AddComponent<eev>();
                install(Qlock.extractr());
            }
        }

        public static eev retrieve() {
            // make this make the object if null
            GameObject eeveeOBJ = GameObject.Find(var.name);
            if (eeveeOBJ == null){
                inject.Parasite();
                eeveeOBJ = GameObject.Find(var.name);
            }

            eev eevee = eeveeOBJ.GetComponent<eev>();
            return eevee;
        }
    }

    // inputs
    //  eevee.input.Collect("a");
    //  eevee.input.Check("a");
    //  eevee.input.Grab("a");
    //  eevee.input.CheckAxis("a", "d");
    //  eevee.input.CollectAxis("a", "d");
    public class input {
        static input() {
            inject.Parasite();
        }

        public static bool Collect(string input) {
            return inject.retrieve().pressed(input);
        }

        public static bool Check(string input) {
            return inject.retrieve().Check(input);
        }

        public static bool Grab(string input) {
            return inject.retrieve().Grab(input);
        }

        public static int CheckAxis(string positive, string negative) {
            return input.Check(positive)?1:input.Check(negative)?-1:0;
        }

        public static int CollectAxis(string positive, string negative) {
            return input.Collect(positive)?1:input.Collect(negative)?-1:0;
        }
    }

    // config lock
    //  eevee.Qlock.wrap();
    //  eevee.Qlock.unwrap();
    //  eevee.Qlock.push();
    //  eevee.Qlock.extractr();
    //  eevee.Qlock.clear();
    public class Qlock {
        static Qlock() {
            inject.Parasite();
        }

        public static string wrap(Dictionary<string, eevee.config> FullConfig) {
            List<KeyValue> keyValueList = new List<KeyValue>();

            foreach (KeyValuePair<string, eevee.config> entry in FullConfig) {
                keyValueList.Add(new KeyValue { key = entry.Key, value = entry.Value });
            }

            ConfigWrapper wrapper = new ConfigWrapper { configData = keyValueList };

            return JsonUtility.ToJson(wrapper);
        }

        public static Dictionary<string, eevee.config> unwrap(string json) {
            ConfigWrapper wrapper = JsonUtility.FromJson<ConfigWrapper>(json);
            
            Dictionary<string, eevee.config> FullConfig = new Dictionary<string, eevee.config>();
            
            foreach (KeyValue entry in wrapper.configData) {
                FullConfig.Add(entry.key, entry.value);
            }

            return FullConfig;
        }

        public static void push() {
            Dictionary<string, eevee.config> FullConfig = inject.retrieve().FullConfig;

            Debug.Log("saving config...");
            File.WriteAllText(var.ConfPath, wrap(FullConfig));
            Debug.Log("config saved.");
        }

        public static Dictionary<string, eevee.config> extractr() {
            if (File.Exists(var.ConfPath)) {
                string json = File.ReadAllText(var.ConfPath);

                return unwrap(json);
            }

            return new Dictionary<string, eevee.config>() {
                {
                    "one", new eevee.config {
                        displayName = "get injected fool",
                        KEYBOARD_code = (int)KeyCode.A
                    }
                }
            };
        }

        public static void clear() {
            if (File.Exists(var.ConfPath)) {
                File.Delete(var.ConfPath);   

                inject.install(new Dictionary<string, eevee.config>());
            }
        }
    }

    // test 
    //  eevee.test.Test();
    public class test {
        public static void Test() {

        }
    }
}

// the componant for live data sifting,
//  This is as Efficient as i could make it but feel free to try your hand at it, in basic how this works:
//  Once an input is requested it will begin the track it, by every frame checking if it is held down either 
//  by `UnityEngine.Input.GetKeyDown()` and by grabbing all the currently pressed buttons on the first gamepad (if there is a gamepad)
//  and mapping that into a ~~hashtable~~ dictionary.
// If anyone needs more help with editing this file please feel free to ask me personally through my socials, i will help out if i have the time (:
public class eev : MonoBehaviour {
    public Dictionary<string, eevee.config> FullConfig = new Dictionary<string, eevee.config>();
    public Dictionary<string, Coroutine> activeCoroutines = new Dictionary<string, Coroutine>();

    public Dictionary<string, Coroutine> activeCoroutines_grab = new Dictionary<string, Coroutine>();

    public List<ButtonControl> current_pressed_buttons = new List<ButtonControl>();
    public List<string> current_pressed_names = new List<string>();

    public bool Check(string input){
        if (FullConfig.ContainsKey(input)) {
            if (Input.GetKey((KeyCode)FullConfig[input].KEYBOARD_code) || IsControllerInputPressed(FullConfig[input].CONTROLLER_name)){
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    public bool Grab(string input){
        if (FullConfig.ContainsKey(input)) {

            if (activeCoroutines_grab.ContainsKey(input) && activeCoroutines_grab[input] != null){
                return false;
            } else if (Check(input)) {
                activeCoroutines_grab[input] = StartCoroutine(Track_Grab(input));
                
                return true;
            }

            return false;

        } else {
            return false;
        }
    }

    public bool pressed(string input){
        if (FullConfig.ContainsKey(input)) {

            if (activeCoroutines.ContainsKey(input) && activeCoroutines[input] != null){
            
                if (FullConfig[input].Pressed){
                    FullConfig[input].Pressed = false;

                    return true;
                }

                return false;
            
            } else {
                activeCoroutines[input] = StartCoroutine(Track(input));
                
                if (FullConfig[input].Pressed){
                    FullConfig[input].Pressed = false;

                    return true;
                }

                return false;
            }

        } else {
            return false;
        }
    }

    private IEnumerator Track(string keyName) {
        float delay = 1f;
        const float minDelay = 0.01f;

        while (true) {
            if (Input.GetKey((KeyCode)FullConfig[keyName].KEYBOARD_code) || IsControllerInputPressed(FullConfig[keyName].CONTROLLER_name)) {
                FullConfig[keyName].Pressed = true;
            } else {
                activeCoroutines.Remove(keyName);
                yield break;
            }

            delay = Mathf.Max(minDelay, delay / 2);
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator Track_Grab(string keyName) {
        while (true) {
            if (!(Input.GetKey((KeyCode)FullConfig[keyName].KEYBOARD_code) || IsControllerInputPressed(FullConfig[keyName].CONTROLLER_name))) {
                activeCoroutines_grab.Remove(keyName);
                yield break;
            }
            yield return 0;
        }
    }

    void FixedUpdate() {
        if (Gamepad.current != null) {

            current_pressed_buttons = Gamepad.current.allControls.OfType<ButtonControl>()
                .Where(control => control.isPressed)
                .ToList();

            current_pressed_names = current_pressed_buttons.ConvertAll<string>(control => control.displayName);
        }
    }

    bool IsControllerInputPressed(string inputName) {
        return current_pressed_names.Contains(inputName);
    }
}