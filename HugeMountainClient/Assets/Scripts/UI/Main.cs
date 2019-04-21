using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class Main : UIBase
{
    private GButton _button;

    void Start()
    {
        _mainView = GetComponent<UIPanel>().ui;
        _button = _mainView.GetChild("n0").asButton;
        _button.onClick.Add(this.onClickN0Btn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onClickN0Btn()
    {
        print("Hi! FairyGUI!");
    }
}
