using UnityEngine;
using System.Collections;

public class MainPlayer : MonoBehaviour {
    private Player _player = null;
    public bool isJump = false;
    public bool isJumpHold = false;

    void Awake() {
    }

    void Start() {
        _player = gameObject.GetComponent<Player>();
    }

    void Update() {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        isJump = Input.GetButtonDown("Jump");
        isJumpHold = Input.GetButton("Jump");

        _player.moveRole(H, V);
    }

    void FixedUpdate() {
        if (isJump) {
            _player.jump();
        }

        if (isJumpHold) {
            _player.jump(true);
        }
    }
}
