﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;

public class Game : MonoBehaviour {
    static public Game ins;

    private LogicMgr _logicMgr = new LogicMgr();

    void Awake() {
        ins = this;
    }

    void Start() {
        _logicMgr.initLoigc();
        loadUIPackage();
    }

    void Update() {
        
    }

    /*
     * 加载UI包
     */
    private async void loadUIPackage() {
        await Task.Delay(1000);
        onInitGameFinish();
    }

    private void onInitGameFinish() {
        UIMgr.ins.openWindow("Main");
    }

    public void on(string eventName, Action<ArrayList> action) {
        MessageCenter.ins.addListener(eventName, action);
    }

    public void emit(string eventName, ArrayList message) {
        MessageCenter.ins.dispatcher(eventName, message);
    }

    public void off(string eventName, Action<ArrayList> action) {
        MessageCenter.ins.removeListstener(eventName, action);
    }
}
