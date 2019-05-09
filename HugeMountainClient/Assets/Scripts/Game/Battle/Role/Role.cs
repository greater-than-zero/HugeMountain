using UnityEngine;
using System.Collections;

public class Role : MonoBehaviour {
    public int hp = 0;
    public int mp = 0;
    public float attSpeed = 0;//攻击频率
    public float missRate = 0;//闪避
    public float powerAttRate = 0;//暴击概率

    public int maxHp = 0;
    public int maxMp = 0;
    public bool isDead;

    public Vector2 speed = new Vector2(10, 10);
    private Rigidbody2D _rigidbody;

    private SkillMgr _skillMgr = new SkillMgr();
    private BuffMgr _buffMgr = new BuffMgr();

    private void Awake() {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        if (_rigidbody == null) {
            _rigidbody = gameObject.AddComponent<Rigidbody2D>();
            _rigidbody.gravityScale = 0;
            _rigidbody.drag = 1;
        }
    }

    void Start() {

    }

    void Update() {
        _skillMgr.update();
        _buffMgr.update();
    }

    public void initRole() {
        _skillMgr.initMgr();
        _buffMgr.initBuff();
    }

    public void moveRole(float x, float y) {
        Vector2 transformValue = new Vector2(x, y);
        _rigidbody.AddForce(transformValue * speed);
    }

    public void jump() {

    }

    public bool attack() {
        return false;
    }

    public void dead() {

    }
}
