using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class UIBase : MonoBehaviour {
    protected GComponent _mainView;
    protected string _packageName;
    protected string _componentName;

    private void Start() {
        initBase();
        UIPackage.AddPackage("UI/" + _packageName);
        UIPanel uiPanel = gameObject.AddComponent<UIPanel>();
        uiPanel.packageName = _packageName;
        uiPanel.componentName = _componentName;
        uiPanel.CreateUI();
        _mainView = GetComponent<UIPanel>().ui;
        onOpen();
    }

    void Update() {
        
    }

    virtual public void initBase() {

    }

    virtual public void onOpen() {

    }

    virtual public void onClose() {

    }
}
