using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGamesManager : Singleton<MiniGamesManager>
{
    string currentMinigame;
    public int saveSlotNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void startMiniGame(string minigame)
    {
        currentMinigame = minigame;
        SceneManager.LoadScene(minigame);

    }
    public void stopMiniGame()
    {
        currentMinigame = null;
        SaveSystem.SaveToSlotImmediate(saveSlotNumber);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMinigame!=null && currentMinigame.Length > 0)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                //finish mini game with succeed
                PixelCrushers.DialogueSystem.DialogueLua.SetVariable(currentMinigame, 2);
                stopMiniGame();
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                //finish mini game with failed

                stopMiniGame();
            }
        }
    }
}
