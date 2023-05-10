using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private bool wasChopped;

    void Update()
    {
        if (wasChopped) {
            transform.Translate(Vector3.up * speed * Time.deltaTime); //local
        }

        if (transform.position.y < -12) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player1") {
            other.GetComponent<Death>().Respawn();
        }
    }
    
    public void Chopped() {
        wasChopped = true;
        var coll = GetComponent<BoxCollider2D>();
        coll.size = new Vector2(1, 2);
    }

}
