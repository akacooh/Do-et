using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreesObjective : MonoBehaviour
{
    private int treeCount;
    public UnityEvent objectiveCompleted;

    void Start()
    {
        treeCount = transform.childCount;
        objectiveCompleted.AddListener(Game.instance.FinishLevel);
    }

    public void RemoveTree() {
        treeCount--;
        if (treeCount == 0) {
            Game.instance.winner = "Lumberjack";
            objectiveCompleted.Invoke();
        }
    }

    private void OnDestroy() {
        objectiveCompleted.RemoveAllListeners();
    }
}
