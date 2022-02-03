using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CleanData : MonoBehaviour
{
    public void cleanData()
    {
        SaveSystem.DeleteSavedGameInSlot(1);
        SaveSystem.RestartGame(SceneManager.GetActiveScene().name);
       // SaveSystem.ClearSavedGameData();
       //// GameObject.FindObjectOfType<DiskSavedGameDataStorer>().ClearSavedGames();
       // StartCoroutine(loadScene());
    }
    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
