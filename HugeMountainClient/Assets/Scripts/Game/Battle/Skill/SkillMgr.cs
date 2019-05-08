using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillMgr {
    private Dictionary<string, SkillItemVO> _mapSkill = new Dictionary<string, SkillItemVO>();

    public void initMgr() {

    }

    public void update() {
        foreach (KeyValuePair<string, SkillItemVO> kv in _mapSkill) {
            kv.Value.update();
        }
    }

    public void addSkill(string skillId) {
        if (_mapSkill.ContainsKey(skillId)) {
            Debug.LogWarning("addSkill " + skillId + " is exist !");
        } else {
            _mapSkill.Add(skillId, SkillItemVO.create(skillId));
        }
    }

    public void removeSkill(string skillId) {
        if (_mapSkill.ContainsKey(skillId)) {
            _mapSkill.Remove(skillId);
        }
    }

    public SkillItemVO getSkill(string skillId) {
        SkillItemVO skillItemVO = null;
        if (_mapSkill.ContainsKey(skillId)) {
            skillItemVO = _mapSkill[skillId];
        }

        return skillItemVO;
    }
}
