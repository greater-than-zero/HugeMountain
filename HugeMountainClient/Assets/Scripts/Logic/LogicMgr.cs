using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LogicMgr {
    private Dictionary<string, LogicBase> _mapLogic = new Dictionary<string, LogicBase>();

    public void initLoigc() {
        registerAll();
    }

    public void unInitLogic() {
        clear();
    }

    private void registerAll() {
        //所有逻辑类在此函数注册
    }

    public void register(string name, LogicBase logic) {
        if (_mapLogic.ContainsKey(name)) {
            Debug.LogWarning("LogicMgr register Name is Exist! " + name);
        }

        logic.onInit();
        _mapLogic.Add(name, logic);
    }

    public void unRegister(string name) {
        if (!_mapLogic.ContainsKey(name)) {
            Debug.LogWarning("LogicMgr register Name is  Not Exist! " + name);
            return;
        }

        LogicBase logic = _mapLogic[name];
        logic.onUnInit();
        _mapLogic.Remove(name);
    }

    public void clear() {
        foreach (KeyValuePair<string, LogicBase> pair in _mapLogic) {
            pair.Value.onUnInit();
        }

        _mapLogic.Clear();
    }

    public LogicBase getLogic(string name) {
        LogicBase logic = null;
        if (_mapLogic.ContainsKey(name)) {
            logic = _mapLogic[name];
        }
        return logic;
    }
}
