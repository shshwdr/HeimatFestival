using PixelCrushers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGridMovement : Saver
{
    public float moveSpeed = 5f;
    public float runSpeed = 10f;
    public Transform movePoint;
    public LayerMask colliderMask;
    public float moveAllowDistance = 0.05f;
    public float moveStepDistance = 0.16f;
    public Vector2 faceDir;
    public GameObject spriteObject;
    public bool facingRight = true;
    Animator animator;
    bool canRun = false;
    bool startMove = false;
    public PlayerInput playerInput;
    bool isPressingB;
    bool inputStarted;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        animator = GetComponentInChildren<Animator>();

        playerInput = CSGameManager.Instance.playerInput;
        playerInput.actions["A"].started += OnPressA;

        playerInput.actions["B"].started += OnStartPressB;
        playerInput.actions["B"].canceled += OnFinishPressB;

        playerInput.actions["Move"].started += OnMove;
        playerInput.actions["Move"].performed += OnMove;
        playerInput.actions["Move"].canceled += OnMove;
    }

    

    public override void OnDisable()
    {

        playerInput.actions["A"].started -= OnPressA;
        playerInput.actions["B"].started -= OnStartPressB;
        playerInput.actions["B"].canceled -= OnFinishPressB;

        playerInput.actions["Move"].started -= OnMove;
        playerInput.actions["Move"].performed -= OnMove;
        playerInput.actions["Move"].canceled -= OnMove;
        base.OnDisable();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("start move " +context);
        inputStarted = true;

    }

    private void OnFinishPressB(InputAction.CallbackContext obj)
    {
        isPressingB = false;
    }

    private void OnStartPressB(InputAction.CallbackContext obj)
    {
        isPressingB = true;
    }

    public void OnPressA(InputAction.CallbackContext context)
    {
        GetComponent<PlayerTalk>().talk();
    }

        void flip()
    {
        facingRight = !facingRight;
        if (spriteObject)
        {

            Vector3 scaler = spriteObject.transform.localScale;
            scaler.x = -scaler.x;
            // spriteObject.transform.position = new Vector3(spriteObject.transform.position.x + 1, spriteObject.transform.position.y, -1);
            spriteObject.transform.localScale = scaler;
            //spriteObject.GetComponent<SpriteRenderer>().flipX = !facingRight;
        }
    }
    public void testFlip(float movement)
    {
        if (facingRight == false && movement > 0.1f)
        {
            flip();
        }
        if (facingRight == true && movement < -0.1f)
        {
            flip();
        }
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
        var isRunning = (canRun && isPressingB);
        var speed = isRunning ? runSpeed : moveSpeed;
        animator.SetBool("isRunning", isRunning);
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);


        if (DialogueUtils.Instance.isInDialogue)
        {
            return;
        }
        if (Vector3.Distance(transform.position, movePoint.position) < moveAllowDistance)
        {
            //if (inputStarted)
            // {
            var horizonMovement = Mathf.CeilToInt((playerInput.actions["Move"].ReadValue<Vector2>().x));
            var verticalMovement = Mathf.CeilToInt((playerInput.actions["Move"].ReadValue<Vector2>().y));
            //}
            //var horizonMovement = Input.GetAxisRaw("Horizontal");
            //var verticalMovement = Input.GetAxisRaw("Vertical");
            if (Mathf.Abs(horizonMovement) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position +new Vector3(moveStepDistance/2f, moveStepDistance / 2f ,0)+ new Vector3(horizonMovement* moveStepDistance, 0, 0), .05f, colliderMask))
                {
                    movePoint.position += new Vector3(horizonMovement* moveStepDistance, 0, 0);
                }
                faceDir = new Vector2(horizonMovement, verticalMovement);
                animator.SetBool("isWalking", true);
                animator.SetFloat("horizontalSpeed", horizonMovement);
                animator.SetFloat("verticalSpeed", 0);
                if (!startMove)
                {
                    startMove = true;

                    movePoint.parent = null;
                }

                testFlip(horizonMovement);
            }
            else if (Mathf.Abs(verticalMovement) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(moveStepDistance / 2f, moveStepDistance / 2f, 0) + new Vector3(0, verticalMovement* moveStepDistance,  0), .05f, colliderMask))
                {
                    movePoint.position += new Vector3(0, verticalMovement* moveStepDistance, 0);
                }
                faceDir = new Vector2(horizonMovement, verticalMovement);

                animator.SetBool("isWalking", true);
                animator.SetFloat("verticalSpeed", verticalMovement);
                animator.SetFloat("horizontalSpeed", 0);
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
