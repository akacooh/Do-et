using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShot : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < -12) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player2") {
            other.GetComponent<Death>().Respawn();
        }
    }
}
