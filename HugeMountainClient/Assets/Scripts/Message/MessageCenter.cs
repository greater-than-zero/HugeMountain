using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MessageCenter : MonoBehaviour {
    public static MessageCenter ins;
    private Dictionary<string, ArrayList> messageCenterDict = new Dictionary<string, ArrayList>();

    void Awake() {
        ins = this;
    }

    public void dispatcher(string eventName, ArrayList message) {
        if (messageCenterDict.ContainsKey(eventName)) {
            foreach(Action<ArrayList> ac in messageCenterDict[eventName]) {
                ac.Invoke(message);
            }
        }
    }

    public void addListener(string eventName, Action<ArrayList> action) {
        if (messageCenterDict.ContainsKey(eventName)) {
            ArrayList array = messageCenterDict[eventName];
            int findIndex = array.IndexOf(action);
            if (findIndex == -1) {
                array.Add(action);
                messageCenterDict[eventName] = array;
            } else {
                array[findIndex] = action;
                messageCenterDict[eventName] = array;
            }
        } else {
            ArrayList array = new ArrayList();
            array.Add(action);
            messageCenterDict.Add(eventName, array);
        }
    }

    public void removeListstener(string eventName, Action<ArrayList> action) {
        if (!messageCenterDict.ContainsKey(eventName)) {
            return;
        }

        messageCenterDict[eventName].Remove(action);
    }
}
