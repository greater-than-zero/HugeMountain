using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;

public class UIMgr : MonoBehaviour {
    private Dictionary<string, UIBase> _uiMap = new Dictionary<string, UIBase>();
    private Dictionary<string, Type> _uiClassMap = new Dictionary<string, Type>();
    private List<string> _cachaNameList = new List<string>();
    private FairyGUIMgr _fairyGUImgr = new FairyGUIMgr();

    static int MaxCacheUI = 10;
    static bool NotDiposeCacheUI = true;
    static public UIMgr ins;

    void Awake() {
        ins = this;
    }

    void Start() {
        _fairyGUImgr.initMgr();
        initMgr();
    }

    void Update() {
        
    }

    void initMgr() {
        register("Main", typeof(Main));
    }

    void register(string name, Type ui) {
        if (_uiClassMap.ContainsKey(name)) {
            Debug.LogWarning("register ui is has name is:" + name);
        }
        _uiClassMap.Add(name, ui);
    }

    /*
     * 打开UI界面
     */
    public UIBase openWindow(string name) {
        UIBase uiBase = null;
        if (_uiMap.ContainsKey(name)) {
            uiBase = _uiMap[name];
            uiBase.onOpen();
        } else {
            Type uiClassType = _uiClassMap[name];
            GameObject uiObject = new GameObject("uiPanel");
            uiObject.layer = 5;
            uiBase = (UIBase)uiObject.AddComponent(uiClassType);
            uiObject.transform.parent = gameObject.transform;
            _uiMap.Add(name, uiBase);
        }
        _cachaNameList.Add(name);
        return uiBase;
    }

    /*
     * 关闭UI界面
     */
    public void closeWindow(string name) {
        UIBase uiBase = null;
        if (!_uiMap.ContainsKey(name)) {
            return;
        }

        uiBase = _uiMap[name];
        uiBase.onClose();

        if (!NotDiposeCacheUI) {
            uiBase.gameObject.transform.parent = null;
            Destroy(uiBase.gameObject);
            _cachaNameList.Remove(name);
            _uiMap.Remove(name);
            return;
        }

        //缓存UI数量
        if (_uiMap.Count >= MaxCacheUI) {
            int lastIndex = _cachaNameList.Count - 1;
            if (lastIndex < 0 || lastIndex > _cachaNameList.Count - 1) {
                return;
            }

            string lastName = _cachaNameList[lastIndex];
            _cachaNameList.RemoveAt(lastIndex);
            if (_uiMap.ContainsKey(name)) {
                uiBase = _uiMap[name];
                uiBase.gameObject.transform.parent = null;
                Destroy(uiBase.gameObject);
                _uiMap.Remove(name);
            }
        } else {
            uiBase.gameObject.SetActive(false);
        }
    }
}
