using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarryBomb : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] BombsObjective objective;

    public UnityEvent bombPlanted;
    private bool hasBomb = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.tag == "Bombs") && (!hasBomb)) {
            hasBomb = true;
            bomb.SetActive(true);
            objective.RemoveBomb();
        }
        if ((other.tag == "Target") && (hasBomb)) {
            hasBomb = false;
            bomb.SetActive(false);
            bombPlanted.Invoke();
        }
    }
}
