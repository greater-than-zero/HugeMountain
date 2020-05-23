using UnityEngine;
using System.Collections;

public class Role : MonoBehaviour {
    public int hp = 0;
    public int mp = 0;
    public float attSpeed = 0;//攻击频率
    public float missRate = 0;//闪避
    public float powerAttRate = 0;//暴击概率

    public float jumpForce = 6.3f;
    public float jumpHoldForce = 1.9f;
    public float jumpHoldDuration = 0.1f;
    public float crouchJumpBoost = 2.5f;

    private float jumpTime;

    public bool isOnGround;
    public bool isJump;

    public float footOffset = 0.4f;
    public float headDistance = 0.5f;
    public float groudDistance = 0.2f;
    public LayerMask groundMask;

    public int maxHp = 0;
    public int maxMp = 0;
    public bool isDead;

    public Vector2 speed = new Vector2(5, 0);
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _coll;
    private Animator _animator;

    private SkillMgr _skillMgr = new SkillMgr();
    private BuffMgr _buffMgr = new BuffMgr();

    private int _hitCount = 0;
    private AnimatorStateInfo _playerAnimInfo;


    virtual public void Awake() {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        if (_rigidbody == null) {
            _rigidbody = gameObject.AddComponent<Rigidbody2D>();
        }

        _coll = gameObject.GetComponent<BoxCollider2D>();
        _animator = gameObject.GetComponent<Animator>();
    }

    virtual public void Start() {

    }

    virtual public void Update() {
        _skillMgr.update();
        _buffMgr.update();

        _playerAnimInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if ((_playerAnimInfo.IsName("Attack1") ||
            _playerAnimInfo.IsName("Attack2")) && _playerAnimInfo.normalizedTime > 1.0f) {
            if (_playerAnimInfo.IsName("Attack1")) {
                Debug.Log("Attack1");
            } else if (_playerAnimInfo.IsName("Attack2")) {
                Debug.Log("Attack2");
            } else if (_playerAnimInfo.IsName("Attack3")) {
                Debug.Log("Attack3");
            }
            _hitCount = 0;   //将hitCount重置为0，即Idle状态
            _animator.SetInteger("Attack1", _hitCount);
        } else {
            if (_playerAnimInfo.IsName("Attack3")) {
                _hitCount = 0;   //将hitCount重置为0，即Idle状态
                _animator.SetInteger("Attack1", _hitCount);
            }
        }
    }

    virtual public void FixedUpdate() {
        physicsCheck();
    }

    public void initRole() {
        _skillMgr.initMgr();
        _buffMgr.initMgr();
    }

    virtual public void moveRole(float x, float y) {
        Vector2 transformValue = new Vector2(x * speed.x, _rigidbody.velocity.y);
        //_rigidbody.AddForce(transformValue * speed);
        if (x != 0) {
            _animator.SetBool("Run", true);
        } else {
            _animator.SetBool("Run", false);
        }

        _rigidbody.velocity = transformValue;
        filpDirction();
    }

    virtual public void jump(bool isHold = false) {
        if (!isJump && isOnGround) {
            isOnGround = false;
            isJump = true;
            jumpTime = Time.time + jumpHoldDuration;
            _rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        } else if (isJump) {
            if (isHold) {
                _rigidbody.AddForce(new Vector2(0f, jumpHoldForce), ForceMode2D.Impulse);
            }

            if (jumpTime < Time.time) {
                isJump = false;
            }
        }
    }

    virtual public bool attack() {
        _playerAnimInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (_playerAnimInfo.IsName("Idle") && _hitCount == 0) {
            _hitCount = 1;
            _animator.SetInteger("Attack1", _hitCount);
        } else if (_playerAnimInfo.IsName("Attack1") && _hitCount == 1 && _playerAnimInfo.normalizedTime > 0.5f) {
            _hitCount = 2;
            _animator.SetInteger("Attack1", _hitCount);
        } else if (_playerAnimInfo.IsName("Attack2") && _hitCount == 2 && _playerAnimInfo.normalizedTime > 0.5f) {
            _hitCount = 3;
            _animator.SetInteger("Attack1", _hitCount);
        }
        return true;
    }

    virtual public void onAttack1() {
    }

    virtual public void onAttack2() {
    }

    virtual public void onAttack3() {
    }

    virtual public void dead() {

    }

    public void filpDirction() {
        if (_rigidbody.velocity.x < 0) {
            transform.localScale = new Vector2(-1, 1);
        } else if (_rigidbody.velocity.x > 0) {
            transform.localScale = new Vector2(1, 1);
        }
    }

    public void physicsCheck() {
        RaycastHit2D leftHit = raycast(new Vector2(-footOffset, 0f), Vector2.down, groudDistance, groundMask);
        RaycastHit2D rightHit = raycast(new Vector2(footOffset, 0f), Vector2.down, groudDistance, groundMask);
        if (leftHit || rightHit) {
            isOnGround = true;
        } else {
            isOnGround = false;
        }
    }

    public RaycastHit2D raycast(Vector2 offset, Vector2 diraction, float lenght, LayerMask layer) {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, diraction, lenght, layer);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(pos + offset, diraction * lenght, color);
        return hit;
    }
}
