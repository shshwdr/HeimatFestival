using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTalk : MonoBehaviour
{
    public LayerMask talkMask;
    PlayerGridMovement movement;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        movement = GetComponent<PlayerGridMovement>();

        //playerInput.actions["A"].started += OnPressA;
    }

    public void talk()
    {
        if (DialogueUtils.Instance.isInDialogue)
        {
            return;
        }
        Collider2D result = Physics2D.OverlapCircle(transform.position + new Vector3(Utils.gridSize / 2f, Utils.gridSize / 2f, 0) + (Vector3)movement.faceDir * Utils.gridSize, 0.07f, talkMask);
        if (result)
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation(result.name, result.transform, result.transform);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    Collider2D result = Physics2D.OverlapCircle(transform.position + new Vector3(Utils.gridSize / 2f, Utils.gridSize / 2f, 0) + (Vector3)movement.faceDir * Utils.gridSize, 0.07f, talkMask);
        //    if (result)
        //    {
        //        PixelCrushers.DialogueSystem.DialogueManager.StartConversation(result.name,result.transform, result.transform);
                
        //    }
        //}
    }

    public void startTalk()
    {
        //animator.SetBool("isTalking", true);
    }

    public void stopTalk()
    {
        //animator.SetBool("isTalking", false);
    }
}
