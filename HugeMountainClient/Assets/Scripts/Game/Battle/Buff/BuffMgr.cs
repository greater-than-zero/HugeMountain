using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BuffEmitType {
    None = 0,
    Attack = 1,
    AttackHit = 2,
    Hit = 3,
    Skill = 4,
    Dodge = 5,
    Hurt = 6,
}

public class BuffMgr {
    private Dictionary<string, List<BuffBaseItem>> _mapBuff = new Dictionary<string, List<BuffBaseItem>>();
    private float _nowTime;

    public void init() {
        _nowTime = 0;
    }

    public void clear() {
        foreach (KeyValuePair<string, List<BuffBaseItem>> kv in _mapBuff) {
            if (kv.Value == null) {
                continue;
            }

            if (kv.Value.Count <= 0) {
                continue;
            }

            kv.Value.RemoveAll((obj) => obj.buffState == BuffState.End);

            foreach (var buff in kv.Value) {
                endBuff(buff);
                buff.clear();
            }

            kv.Value.Clear();
        }

        _mapBuff.Clear();
    }

    public void update() {
        _nowTime += Time.fixedTime;

        foreach (KeyValuePair<string, List<BuffBaseItem>> kv in _mapBuff) {
            if (kv.Value == null) {
                continue;
            }

            if (kv.Value.Count <= 0) {
                continue;
            }

            kv.Value.RemoveAll((obj) => obj.buffState == BuffState.End);

            foreach (var buff in kv.Value) {
                if (buff.buffState == BuffState.Run) {
                    if (buff.duration >= 0 && _nowTime > buff.startTime + buff.duration) {
                        endBuff(buff);
                    } else {
                        buff.update();
                    }
                } else if (buff.buffState == BuffState.Wait) {
                    if (_nowTime > buff.addTime + buff.delay) {
                        beginBuff(buff);
                    }
                }
            }
        }
    }

    private void endBuff(BuffBaseItem buff) {
        if (buff.buffState == BuffState.Run) {
            buff.endTime = _nowTime;
            buff.buffState = BuffState.End;
            buff.onEnd();
        }
    }

    private void beginBuff(BuffBaseItem buff) {
        if (buff.buffState == BuffState.Wait) {
            buff.startTime = _nowTime;
            buff.buffState = BuffState.Run;
            buff.onBegin();
        }
    }

    public bool addBuff(string buffId) {
        var buff = new BuffBaseItem();
        if (!canAddBuff(buff)) {
            return false;
        }
        initBuff(buff);
        return true;
    }

    private void initBuff(BuffBaseItem buff) {
        if (buff.buffState == BuffState.None) {
            buff.addTime = _nowTime;
            buff.buffState = BuffState.Wait;

            if (!_mapBuff.ContainsKey(buff.buffType)) {
                _mapBuff[buff.buffType] = new List<BuffBaseItem>();
            }

            _mapBuff[buff.buffType].Add(buff);

            if (buff.maxCount > -1) {
                var findList = _mapBuff[buff.buffType].FindAll((obj) => obj.id == buff.id);
                if (findList.Count > buff.maxCount) {
                    findList.Sort((a, b) => (int)(a.addTime - b.addTime));
                    int removeCount = findList.Count - buff.maxCount;
                    for (var i = 0; i < removeCount; ++i) {
                        endBuff(findList[i]);
                    }
                }
            }
        }
    }

    private bool canAddBuff(BuffBaseItem buff) {
        return true;
    }

    public void emitBuff(BuffEmitType type, Role emitData) {
        foreach (KeyValuePair<string, List<BuffBaseItem>> kv in _mapBuff) {
            if (kv.Value == null) {
                continue;
            }

            if (kv.Value.Count <= 0) {
                continue;
            }

            foreach (var buff in kv.Value) {
                if (buff.buffState == BuffState.Run) {
                    buff.dispose(type, emitData);
                }
            }
        }
    }
}
