using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 4.0f;

    private bool walking = false;
    public Vector2 lastMovement = Vector2.zero;

    //Buena practica guardar el movimiento horizontal y vertical, asi se carga una vez y no hay que cargarlos en el update
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";
    private const string attackingState = "Attacking";

    private Animator anim;
    private Rigidbody2D playerRigidBody;

    public static bool playerCreated;

    public string nextPlaceName;

    private bool attacking = false;
    public float attackTime;
    private float attackTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();

        if (!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //d = v * t
        walking = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attacking = true;
            attackTimeCounter = attackTime;
            playerRigidBody.velocity = Vector2.zero;
            anim.SetBool(attackingState, true);
        }

        if (attacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if (attackTimeCounter < 0)
            {
                attacking = false;
                anim.SetBool(attackingState, false);
            }
        }
        else
        {
            if (Mathf.Abs(Input.GetAxisRaw(horizontal))> 0.5f || Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
            {
                walking = true;
                lastMovement = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));
                playerRigidBody.velocity = lastMovement.normalized * walkSpeed * Time.deltaTime;
            }
        }

        if (!walking)
            playerRigidBody.velocity = Vector2.zero;

        anim.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        anim.SetFloat(vertical, Input.GetAxisRaw(vertical));
        anim.SetBool(walkingState, walking);
        anim.SetFloat(lastHorizontal, lastMovement.x);
        anim.SetFloat(lastVertical, lastMovement.y);
    }

}
