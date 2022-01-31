using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTalk : MonoBehaviour
{
    public LayerMask talkMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //bad idea, use look at the trigger
            Collider2D result = Physics2D.OverlapCircle(transform.position, .2f, talkMask);
            if (result)
            {
                PixelCrushers.DialogueSystem.DialogueManager.StartConversation(result.name,result.transform, result.transform);
            }
        }
    }
}
