using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 10f;
    public Transform movePoint;
    public LayerMask colliderMask;
    public float moveAllowDistance = 0.05f;
    public float moveStepDistance = 0.16f;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) < moveAllowDistance)
        {
            var horizonMovement = Input.GetAxisRaw("Horizontal");
            var verticalMovement = Input.GetAxisRaw("Vertical");
            if (Mathf.Abs(horizonMovement) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(horizonMovement* moveStepDistance, 0, 0), .1f, colliderMask))
                {
                    movePoint.position += new Vector3(horizonMovement* moveStepDistance, 0, 0);
                }
            }
            if (Mathf.Abs(verticalMovement) == 1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, verticalMovement* moveStepDistance,  0), .1f, colliderMask))
                {
                    movePoint.position += new Vector3(0, verticalMovement* moveStepDistance, 0);
                }
            }
        }
    }
}
