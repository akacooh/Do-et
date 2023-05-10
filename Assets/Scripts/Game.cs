using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    private int currentLevel;
    public static Game instance;
    public UnityEvent levelFinished;
    private AudioSource audioSource;
    public string winner;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        Application.targetFrameRate = 60;
        Screen.SetResolution(1920, 1080, true);
    }

    public void GoToNextLevel() {
        currentLevel++;
        if (currentLevel >= SceneManager.sceneCountInBuildSettings) currentLevel = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(currentLevel);
        if (currentLevel != 0) audioSource.Play();
    }

    public void FinishLevel() {
        Time.timeScale = 0;
        levelFinished.Invoke();
        audioSource.Stop();
    }

}
