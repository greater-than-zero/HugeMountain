using UnityEngine;
using System.Collections;

/*
 *          id: buffId,
            name: row.name,
            desc: row.desc,
            probability: row.probability,
            maxCount: row.max_count,
            kind: row.kind,
            disperse: row.disperse,
            delay: row.delay,
            duration: row.duration,
            buffType: row.buff_type,
            isWaveClear: row.buff_is_clear === 1,
            addTimestamp: 0,
            startTimestamp: 0,
            endTimestamp: 0,
            state: BUFF_STATE_CONFIG.DEFAULT,
            data: {}
*/

public enum BuffState {
    None = 0,
    Run = 1,
    Wait = 2,
    End = 3,
}

public class BuffBaseItem {
    public int id; //BUFF ID
    public float timer; //计时器
    public float duration; //持续时间
    public int maxCount; //最大数量
    public float delay; //延迟时间
    public float addTime; //添加时间
    public float startTime; //开始时间
    public float endTime; //结束时间
    // config
    public string buffType; //BUFF类型
    public BuffState buffState; //BUFF状态

    virtual public void init(Role attacker) {

    }

    virtual public void onBegin() {

    }

    virtual public void onEnd() {

    }

    virtual public void onAttack(Role emitData) {

    }

    virtual public void onAttackHit(Role emitData) {

    }

    virtual public void onHurt(Role emitData) {

    }

    virtual public void onDodge(Role emitData) {

    }

    virtual public void onHit(Role emitData) {

    }

    virtual public void onSkill(Role emitData) {

    }

    virtual public void clear() {
        startTime = 0;
        addTime = 0;
        endTime = 0;
        duration = 0;
    }

    virtual public void onUndefine(BuffEmitType type, Role emitData) {

    }

    public void update() {
        timer += Time.fixedTime;
    }

    virtual public void dispose(BuffEmitType type, Role emitData) {
        switch (type) {
            case BuffEmitType.Attack:
                onAttack(emitData);
                break;
            case BuffEmitType.AttackHit:
                onAttackHit(emitData);
                break;
            case BuffEmitType.Dodge:
                onDodge(emitData);
                break;
            case BuffEmitType.Hit:
                onHit(emitData);
                break;
            case BuffEmitType.Skill:
                onSkill(emitData);
                break;
            case BuffEmitType.Hurt:
                onHurt(emitData);
                break;
            default:
                onUndefine(type, emitData);
                break;
        }
    }
}
