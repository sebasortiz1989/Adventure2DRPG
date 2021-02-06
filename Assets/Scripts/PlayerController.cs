using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 4.0f;

    //Buena practica guardar el movimiento horizontal y vertical
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //d = v * t

        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
        {
            this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal) 
                * walkSpeed * Time.deltaTime, 0, 0));
        }

        if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
        {
            this.transform.Translate(new Vector3(0, Input.GetAxisRaw(vertical)
                * walkSpeed * Time.deltaTime, 0));
        }

        anim.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        anim.SetFloat(vertical, Input.GetAxisRaw(vertical));
    }
}
