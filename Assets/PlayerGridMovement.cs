using PixelCrushers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : Saver
{
    public float moveSpeed = 5f;
    public float runSpeed = 10f;
    public Transform movePoint;
    public LayerMask colliderMask;
    public float moveAllowDistance = 0.05f;
    public float moveStepDistance = 0.16f;
    public Vector2 faceDir;
    Animator animator;
    bool canRun = false;
    bool startMove = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void enableRun()
    {
        canRun = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (!SaveLoadManager.Instance.dataApplied)
        {
            //print("still loading!");
            return;
        }
        var speed = (canRun && Input.GetKey(KeyCode.X)) ? runSpeed : moveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);


        if (DialogueUtils.Instance.isInDialogue)
        {
            return;
        }
        if (Vector3.Distance(transform.position, movePoint.position) < moveAllowDistance)
        {

            var horizonMovement = Input.GetAxisRaw("Horizontal");
            var verticalMovement = Input.GetAxisRaw("Vertical");
            if (Mathf.Abs(horizonMovement) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position +new Vector3(moveStepDistance/2f, moveStepDistance / 2f ,0)+ new Vector3(horizonMovement* moveStepDistance, 0, 0), .05f, colliderMask))
                {
                    movePoint.position += new Vector3(horizonMovement* moveStepDistance, 0, 0);
                }
                faceDir = new Vector2(horizonMovement, verticalMovement);
                animator.SetBool("isWalking", true);
                if (!startMove)
                {
                    startMove = true;

                    movePoint.parent = null;
                }
            }
            else if (Mathf.Abs(verticalMovement) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(moveStepDistance / 2f, moveStepDistance / 2f, 0) + new Vector3(0, verticalMovement* moveStepDistance,  0), .05f, colliderMask))
                {
                    movePoint.position += new Vector3(0, verticalMovement* moveStepDistance, 0);
                }
                faceDir = new Vector2(horizonMovement, verticalMovement);

                animator.SetBool("isWalking", true);
                if (!startMove)
                {
                    startMove = true;

                    movePoint.parent = null;
                }
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }
    }
    [Serializable]
    public class Data
    {
        public bool canRun;
    }
    private Data m_data = new Data();
    public override string RecordData()
    {
        m_data.canRun = canRun;
        return SaveSystem.Serialize(m_data);
    }

    public override void ApplyData(string s)
    {
        var data = SaveSystem.Deserialize<Data>(s, m_data);
        if (data == null) return;
        m_data = data;
        canRun = m_data.canRun;
    }
}
