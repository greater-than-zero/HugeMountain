using UnityEngine;
using System.Collections;

public class MainPlayer : MonoBehaviour {
    private Player _player = null;

    private void Awake() {
        _player = gameObject.GetComponent<Player>();
    }

    void Start() {

    }

    void FixedUpdate() {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        _player.moveRole(H, V);
    }
}
