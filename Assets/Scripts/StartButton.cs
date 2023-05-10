using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button buttonSelf;
    
    void Start()
    {
        buttonSelf = GetComponent<Button>();
        buttonSelf.onClick.AddListener(Game.instance.GoToNextLevel);
    }

    private void OnDestroy() {
        buttonSelf.onClick.RemoveAllListeners();
    }
}
