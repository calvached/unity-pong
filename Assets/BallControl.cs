using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {
    private Rigidbody2D rb2d;

    void GoBall() {
      float rand = Random.Range(0, 2);

      if(rand < 1) {
        rb2d.AddForce(new Vector2(20, -15));
      } else {
        rb2d.AddForce(new Vector2(-20, -15));
      }
    }

    // Start is called before the first frame update
    void Start() {
      rb2d = GetComponent<Rigidbody2D>();
      Invoke("GoBall", 2);
    }

    void ResetBall() {
      rb2d.velocity = new Vector2 (0, 0);
      transform.position = Vector2.zero;
    }

    void RestartGame() {
      ResetBall();
      Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D (Collision2D collision) {
      if(collision.collider.CompareTag("Player")) {
        Vector2 vel;
        vel.x = rb2d.velocity.x;
        vel.y = (rb2d.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
        rb2d.velocity = vel;
      }
    }

}
