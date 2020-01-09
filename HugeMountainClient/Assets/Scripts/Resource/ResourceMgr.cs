using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ResourceMgr {
    private Dictionary<String, AssetHander> _mapAssetHander = new Dictionary<string, AssetHander>();
    public void load(string path, bool isWeb, loadFinishCb loadFinish) {
        if (_mapAssetHander.ContainsKey(path)) {
            loadFinish(_mapAssetHander[path]);
            return;
        }

        if (isWeb) {
            loadAssetBundleWeb(path, loadFinish);
        } else {
            loadAssetBundle(path, loadFinish);
        }
    }

    public IEnumerator loadAssetBundle(string path, loadFinishCb loadFinish) {
        AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
        yield return request;

        AssetHander hander = new AssetHander();
        hander.assetBundle = request.assetBundle;
        hander.addRef();
        _mapAssetHander.Add(path, hander);
        loadFinish(_mapAssetHander[path]);
    }

    public IEnumerable loadAssetBundleWeb(string path, loadFinishCb loadFinish) {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(path);
        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError) {
            Debug.Log("path is Error" + path + " " + request.error);
        } else {
            AssetHander hander = new AssetHander();
            hander.assetBundle = DownloadHandlerAssetBundle.GetContent(request);
            hander.addRef();
            _mapAssetHander.Add(path, hander);
            loadFinish(_mapAssetHander[path]);
        }
    }

    public delegate AssetHander loadFinishCb(AssetHander assetHander);
}
