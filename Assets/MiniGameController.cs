using Pool;
using RhythmHeavenMania;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{

    public Text scoreLabel;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject tutorialPanel;
    public AudioSource tutorialAudio;
    // Start is called before the first frame update
    void Start()
    {
        tutorialPanel.SetActive(true);

        EventPool.OptIn("minigameLose", onGameLose);
        EventPool.OptIn("minigameWin", onGameWin); 
        EventPool.OptIn("scoreChange", onScoreChange);
        Time.timeScale = 0;
    }

    public void stopTutorial()
    {

        Time.timeScale = 1;
        GameManager.instance.Play(GameManager.instance.startBeat);
        tutorialAudio.loop = false;
    }
    public void onScoreChange()
    {
        scoreLabel.text = $"Score: { GameScoreManager.Instance.currentScore}/{GameScoreManager.Instance.maxScore}";
    }
    public void onGameLose()
    {
        losePanel.SetActive(true);
    }
    public void onGameWin()
    {
        winPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
