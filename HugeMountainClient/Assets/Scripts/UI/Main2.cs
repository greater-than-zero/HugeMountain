using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class Main2 : UIBase
{
    private GButton _button;

    override public void onOpen() {
        _button = _mainView.GetChild("n0").asButton;
        _button.onClick.Add(this.onClickN0Btn);
    }

    override public void initBase() {
        _packageName = "Package1";
        _componentName = "Component1";
    }

    private void onClickN0Btn()
    {
        print("Hi! FairyGUI!");
    }
}
