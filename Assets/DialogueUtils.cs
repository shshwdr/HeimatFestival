using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUtils : Singleton<DialogueUtils>
{
    public bool isInDialogue;
    public List<GameObject> hideItems;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void startConversation()
    {
        isInDialogue = true;
        foreach (var item in hideItems)
        {
            item.SetActive(false);
        }
        GameObject.FindObjectOfType<PlayerTalk>().startTalk();
    }
    public void started()
    {

    }
    public void endConversation()
    {
        isInDialogue = false;
        foreach (var item in hideItems)
        {
            item.SetActive(true);
        }
        GameObject.FindObjectOfType<PlayerTalk>().stopTalk();
    }
}
