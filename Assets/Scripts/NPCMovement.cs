using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody2D npcRigidbody;
    
    public bool isWalking;

    public float walkTime = 1.5f;
    private float walkCounter;
    
    public float waitTime = 3.0f;
    private float waitCounter;

    private string exitZone = null;

    public Vector2[] walkingDirection =
    {
        new Vector2(-1,0),
        new Vector2(1,0),
        new Vector2(0,-1),
        new Vector2(0,1)
    };

    public int currentDirection;

    [SerializeField] BoxCollider2D villagerZone;

    // Start is called before the first frame update
    void Start()
    {
        npcRigidbody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            if (villagerZone != null)
            {
                if (this.transform.position.x <= villagerZone.bounds.min.x)
                {
                    StopWalking();
                    exitZone = "left";
                }
                else if (this.transform.position.x >= villagerZone.bounds.max.x)
                {
                    StopWalking();
                    exitZone = "right";
                }
                else if (this.transform.position.y <= villagerZone.bounds.min.y)
                {
                    StopWalking();
                    exitZone = "down";
                }
                else if (this.transform.position.y >= villagerZone.bounds.max.y)
                {
                    StopWalking();
                    exitZone = "up";
                }
            }

            npcRigidbody.velocity = walkingDirection[currentDirection] * speed;

            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                StopWalking();
            }
        }
        else
        {
            npcRigidbody.velocity = Vector2.zero;

            waitCounter -= Time.deltaTime;
            if (waitCounter < 0)
            {
                StartWalking();
            }
        }
    }

    private void StartWalking()
    {
        isWalking = true;
        if (exitZone == null)
            currentDirection = Random.Range(0, 4);
        else if (exitZone == "left")
            currentDirection = 1;
        else if (exitZone == "right")
            currentDirection = 0;
        else if (exitZone == "down")
            currentDirection = 3;
        else if (exitZone == "up")
            currentDirection = 2;

        exitZone = null;
        walkCounter = walkTime;
    }

    private void StopWalking()
    {
        isWalking = false;
        waitCounter = waitTime;
        npcRigidbody.velocity = Vector2.zero;
    }
}

