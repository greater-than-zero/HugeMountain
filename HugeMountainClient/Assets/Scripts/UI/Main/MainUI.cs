using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class Main : UIBase {
    private GButton _button;
    private GButton _button2;

    override public void initUI() {
        _packageName = "Main";
        _componentName = "MainUI";
    }

    override public void onOpen() {
        _button = _view.GetChild("n1").asButton;
        _button2 = _view.GetChild("n2").asButton;
        _button.onClick.Add(onClickN0Btn);
        _button2.onClick.Add(onClickN1Btn);
        Game.ins.on("dddd", TestMessageEevn);
        Game.ins.on("dddd", TestMessageEevn2);
    }

    private void onClickN0Btn() {
        Game.ins.emit("dddd", new ArrayList() { 111, "aaa", 222 });
        print("Hi! FairyGUI!");
        Game.ins.off("dddd", TestMessageEevn2);
    }

    private void onClickN1Btn() {
        UIMgr.ins.openWindow("Loading");
        UIMgr.ins.closeWindow("Main");
    }

    private void TestMessageEevn(ArrayList arrayList) {
        Debug.Log(arrayList[0]);
        Debug.Log(arrayList[1]);
        Debug.Log(arrayList[2]);
    }

    private void TestMessageEevn2(ArrayList arrayList) {
        Debug.Log("TestMessageEevn2");
    }
}
