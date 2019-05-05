using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class UIBase : MonoBehaviour {
    protected GComponent _view;
    protected string _packageName;
    protected string _componentName;

    private void Start() {
        initUI();
        UIPackage.AddPackage("UI/" + _packageName);
        UIPanel uiPanel = gameObject.AddComponent<UIPanel>();
        uiPanel.packageName = _packageName;
        uiPanel.componentName = _componentName;
        uiPanel.fitScreen = FitScreen.FitSize;
        uiPanel.CreateUI();
        _view = GetComponent<UIPanel>().ui;
        onOpen();
    }

    void Update() {
        
    }

    virtual public void initUI() {

    }

    virtual public void onOpen() {

    }

    virtual public void onClose() {

    }
}
