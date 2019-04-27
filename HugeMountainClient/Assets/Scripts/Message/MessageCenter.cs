using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MessageCenter : MonoBehaviour {
    public static MessageCenter ins;
    private Dictionary<string, ArrayList> _messageCenterDict = new Dictionary<string, ArrayList>();

    void Awake() {
        ins = this;
    }

    public void dispatcher(string eventName, ArrayList message) {
        if (_messageCenterDict.ContainsKey(eventName)) {
            foreach(Action<ArrayList> ac in _messageCenterDict[eventName]) {
                ac.Invoke(message);
            }
        }
    }

    public void addListener(string eventName, Action<ArrayList> action) {
        if (_messageCenterDict.ContainsKey(eventName)) {
            ArrayList array = _messageCenterDict[eventName];
            int findIndex = array.IndexOf(action);
            if (findIndex == -1) {
                array.Add(action);
                _messageCenterDict[eventName] = array;
            } else {
                array[findIndex] = action;
                _messageCenterDict[eventName] = array;
            }
        } else {
            ArrayList array = new ArrayList();
            array.Add(action);
            _messageCenterDict.Add(eventName, array);
        }
    }

    public void removeListstener(string eventName, Action<ArrayList> action) {
        if (!_messageCenterDict.ContainsKey(eventName)) {
            return;
        }

        _messageCenterDict[eventName].Remove(action);
    }
}
