using UnityEngine;

public enum AssetType {
    None,
    Image,
    Prefab,
    File,
    Spine,
}

public class AssetHander {
    private int _count = 0;
    private AssetType _assetType = AssetType.None;
    public AssetBundle assetBundle { get; set; }

    public void addRef() {
        _count++;
    }

    public void releaseRef() {
        _count--;
        if (_count == 0) {
            release();
        }
    }

    public virtual bool release() {
        return true;
    }

    public int getCount() {
        return _count;
    }

    public AssetType getType() {
        return _assetType;
    }

    public void setType(AssetType assetType) {
        _assetType = assetType;
    }
}
