using UnityEngine;
using UnityEditor;
using FairyGUI;

public class FairyGUIMgr {

    public void initMgr() {
#if UNITY_WEBPLAYER || UNITY_WEBGL || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
        CopyPastePatch.Apply();
#endif

#if (UNITY_5 || UNITY_5_3_OR_NEWER)
        //Use the font names directly
        UIConfig.defaultFont = "Microsoft YaHei";
#else
		//Need to put a ttf file into Resources folder. Here is the file name of the ttf file.
		UIConfig.defaultFont = "afont";
#endif
        /*
        UIPackage.AddPackage("UI/Basics");

        UIConfig.verticalScrollBar = "ui://Basics/ScrollBar_VT";
        UIConfig.horizontalScrollBar = "ui://Basics/ScrollBar_HZ";
        UIConfig.popupMenu = "ui://Basics/PopupMenu";
        UIConfig.buttonSound = (NAudioClip)UIPackage.GetItemAsset("Basics", "click");
        */
        initCommpont();
    }

    /*
     * 所有Fairy组件绑定在此进行
     */
    private void initCommpont() {

    }
}