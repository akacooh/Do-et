using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private MonoBehaviour[] scripts;
    [SerializeField] private float respawnTime;
    [SerializeField] private bool isDead = false;

    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource audioSource;
    public UnityEvent died;
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Respawn() {
        if (isDead) return;
        audioSource.Play();
        died.Invoke();
        isDead = true;
        foreach (var script in scripts) {
            script.enabled = false;
        }
        rb.velocity = Vector2.zero;        
        rb.MovePosition(startPosition);
        animator.SetTrigger("Death");
        Invoke("EnableScripts", respawnTime);
    }

    private void EnableScripts() {
         foreach (var script in scripts) {
            script.enabled = true;
        }
        isDead = false;       
    }
}
