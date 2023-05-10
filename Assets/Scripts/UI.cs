using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private TMP_Text winText;
    [SerializeField] private Image winImage;
    [SerializeField] private GameObject backGround;
    [SerializeField] private Sprite[] winBG;

    private Game game;

    void Start()
    {
        game = Game.instance;
        nextLevelButton.onClick.AddListener(game.GoToNextLevel);
        game.levelFinished.AddListener(OnLevelFinished);
    }

    private void OnLevelFinished() {
        winText.text = Game.instance.winner + " wins";
        if (Game.instance.winner == "Lumberjack") {
            winImage.sprite = winBG[0];
        } else {
            winImage.sprite = winBG[1];
        }
        backGround.SetActive(true);
    }

    private void OnDestroy() {
        nextLevelButton.onClick.RemoveAllListeners();
    }
}
