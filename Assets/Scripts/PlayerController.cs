﻿using System.Collections;
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
        walking = false;

        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
        {
            this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal) 
                * walkSpeed * Time.deltaTime, 0, 0));
            walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(horizontal), 0);
        }

        if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
        {
            this.transform.Translate(new Vector3(0, Input.GetAxisRaw(vertical)
                * walkSpeed * Time.deltaTime, 0));
            walking = true;
            lastMovement = new Vector2(0, Input.GetAxisRaw(vertical));
        }

        anim.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        anim.SetFloat(vertical, Input.GetAxisRaw(vertical));
        anim.SetBool(walkingState, walking);
        anim.SetFloat(lastHorizontal, lastMovement.x);
        anim.SetFloat(lastVertical, lastMovement.y);
    }
}
