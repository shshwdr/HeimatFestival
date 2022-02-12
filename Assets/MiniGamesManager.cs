using PixelCrushers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MiniGamesManager : Singleton<MiniGamesManager>
{
    string currentMinigame;
    public int saveSlotNumber = 1;
    public PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {

        playerInput = CSGameManager.Instance.playerInput;
        //playerInput.actions["A"].started += OnPressA;

        //playerInput.actions["B"].started += OnStartPressB;
        //playerInput.actions["B"].canceled += OnFinishPressB;

        //playerInput.actions["movement"].started += OnMove;
        //playerInput.actions["movement"].performed += OnMove;
        playerInput.actions["R"].started += OnPressR;
        playerInput.actions["T"].started += OnPressT;
        playerInput.actions["Y"].started += OnPressY;
        //playerInput.actions["movement"].canceled += OnMove;
    }

    private void OnPressR(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnPressT(InputAction.CallbackContext obj)
    {
        //finish mini game with succeed
        PixelCrushers.DialogueSystem.DialogueLua.SetVariable(currentMinigame, 2);
        stopMiniGame();
    }
    private void OnPressY(InputAction.CallbackContext obj)
    {
        stopMiniGame();
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
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                //finish mini game with failed

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
            }
        }
    }
}
