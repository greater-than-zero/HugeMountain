using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MapEditorToolSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [MenuItem("GameObject/HugeMountainMap/MapMain", false, 0)]
    public static void Test1() {
        Debug.Log("Test_-----");
    }

    [MenuItem("GameObject/HugeMountainMap/MapItem", false, 0)]
    public static void Test2() {
        GameObject panelObject = createGameObject("MapItem");
        panelObject.AddComponent<MapItemBase>();
        Selection.objects = new Object[] { panelObject };
    }

    public static GameObject createGameObject(string name) {
        GameObject panelObject = new GameObject(name);
        if (Selection.activeGameObject != null) {
            panelObject.transform.parent = Selection.activeGameObject.transform;
            panelObject.layer = Selection.activeGameObject.layer;
        } else {
            panelObject.layer = 1;
        }
        return panelObject;
    }
}
