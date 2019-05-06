using UnityEngine;
using System.Collections;
using System.Linq;

public class Role : MonoBehaviour {
    public int hp = 0;
    public int mp = 0;
    public Vector2 speed = new Vector2(10, 10);
    private Rigidbody2D _rigidbody;

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

    }

    public void moveRole(float x, float y) {
        Vector2 transformValue = new Vector2(x, y);
        _rigidbody.AddForce(transformValue * speed);
    }
}
