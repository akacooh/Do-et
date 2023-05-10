using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Chopping : MonoBehaviour
{
    [SerializeField] private float timeToChop;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TreesObjective objective;
    [SerializeField] private AudioClip chopSound;

    private AudioSource audioSource;
    private Animator animator;
    private float choppingTime;
    private bool actionIsComing = false;
    private GameObject tree;
    private bool nearTree = false;

    private void Awake() {
        progressBar.maxValue = timeToChop;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Tree") {
            tree = other.gameObject;
            nearTree = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Tree") {
            ResetProgress();
            if (other.gameObject == tree) {
                nearTree = false;
            }
        }        
    }
    public void OnInteract(InputAction.CallbackContext context) {
        if (!nearTree) return;
        if (context.performed) {
            actionIsComing = true;
            animator.SetBool("Chopping", true);
        }
    }

    private void Update() {
        if (actionIsComing) {
            choppingTime += Time.deltaTime;
            progressBar.value = choppingTime;
            if (choppingTime >= timeToChop) {
                audioSource.PlayOneShot(chopSound);
                var treeScript = tree.GetComponent<Tree>();
                treeScript.Chopped();
                ResetProgress();
                objective.RemoveTree();
            }
        }
    }

    private void ResetProgress() {
        choppingTime = 0;
        progressBar.value = choppingTime;
        actionIsComing = false;
        animator.SetBool("Chopping", false);
    }
}