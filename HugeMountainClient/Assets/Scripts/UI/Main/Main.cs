using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class Main : UIBase {
    private GButton _button;

    override public void initUI() {
        _packageName = "Package1";
        _componentName = "Component1";
    }

    override public void onOpen() {
        _button = _mainView.GetChild("n0").asButton;
        _button.onClick.Add(onClickN0Btn);
        Game.ins.on("dddd", TestMessageEevn);
        Game.ins.on("dddd", TestMessageEevn2);
    }

    private void onClickN0Btn() {
        Game.ins.emit("dddd", new ArrayList() { 111, "aaa", 222 });
        print("Hi! FairyGUI!");
        Game.ins.off("dddd", TestMessageEevn2);
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
