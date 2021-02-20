using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody2D npcRigidbody;
    
    public bool isWalking;
    public bool isTalking;

    public float walkTime = 1.5f;
    public float walkCounter;
    
    public float waitTime = 3.0f;
    public float waitCounter;

    public bool zoneBoundaryReached = false;

    public Vector2[] walkingDirection =
    {
        new Vector2(-1,0),
        new Vector2(1,0),
        new Vector2(0,-1),
        new Vector2(0,1)
    };

    public int currentDirection = 0;
    public int latestDirection = 0;

    [SerializeField] BoxCollider2D villagerZone;

    private DialogManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
        npcRigidbody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.dialogActive)
        {
            isTalking = false;
        }

        if (isTalking)
        {
            StopWalking();
            return;
        }

        if (isWalking)
        {
            if (villagerZone != null)
            {
                if (this.transform.position.x <= villagerZone.bounds.min.x || this.transform.position.x >= villagerZone.bounds.max.x ||
                    this.transform.position.y <= villagerZone.bounds.min.y || this.transform.position.y >= villagerZone.bounds.max.y)
                {
                    if (currentDirection == 1 || currentDirection == 3)
                    {
                        currentDirection--;
                    }
                    else
                        currentDirection++;
                }
            }

            npcRigidbody.velocity = walkingDirection[currentDirection] * speed;

            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                if (zoneBoundaryReached)
                    zoneBoundaryReached = false;
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
        while (latestDirection == currentDirection)
            currentDirection = Random.Range(0, 4);
        latestDirection = currentDirection;
        walkCounter = walkTime;
    }

    private void StopWalking()
    {
        isWalking = false;
        waitCounter = waitTime;
        npcRigidbody.velocity = Vector2.zero;
    }
}

