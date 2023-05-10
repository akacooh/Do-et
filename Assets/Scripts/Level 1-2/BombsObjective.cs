using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombsObjective : MonoBehaviour
{
    [SerializeField] private int bombCount;
    [SerializeField] private Sprite[] sprites;
    
    private SpriteRenderer sRenderer;
    public UnityEvent objectiveCompleted;
    private int bombsAtStart;

    void Start()
    {
        objectiveCompleted.AddListener(Game.instance.FinishLevel);
        bombsAtStart = bombCount;
        sRenderer = GetComponent<SpriteRenderer>();
    }

    public void RemoveBomb() {
        bombCount--;
        if (bombCount < bombsAtStart/3) {
            sRenderer.sprite = sprites[0];
        } else if (bombCount < bombsAtStart*2/3) {
            sRenderer.sprite = sprites[1];
        } else {
            sRenderer.sprite = sprites[2];
        }

        if (bombCount == 0) {
            Game.instance.winner = "Pirate";
            objectiveCompleted.Invoke();
        }
    }

    private void OnDestroy() {
        objectiveCompleted.RemoveAllListeners();
    }
}
