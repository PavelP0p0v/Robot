using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlatform : MonoBehaviour
{
    public Vector3 MovableAxis = Vector3.zero;
    public float Speed = 5f;
    public float Distance = 10f;

    private bool moveBack = false;
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }

    void Update()
    {

        if (MovableAxis == Vector3.up)
        {
            if ((StartPosition + (MovableAxis * Distance)).y < transform.position.y && moveBack == false)
            {
                moveBack = true;
            }
            else if ((StartPosition - (MovableAxis * Distance)).y > transform.position.y && moveBack == true)
            {
                moveBack = false;
            }
        }

        if (MovableAxis == Vector3.right)
        {
            if ((StartPosition + (MovableAxis * Distance)).x < transform.position.x && moveBack == false)
            {
                moveBack = true;
            }
            else if ((StartPosition - (MovableAxis * Distance)).x > transform.position.x && moveBack == true)
            {
                moveBack = false;
            }
        }

        if (MovableAxis == Vector3.forward)
        {
            if ((StartPosition + (MovableAxis * Distance)).z < transform.position.z && moveBack == false)
            {
                moveBack = true;
            }
            else if ((StartPosition - (MovableAxis * Distance)).z > transform.position.z && moveBack == true)
            {
                moveBack = false;
            }
        }

        if (moveBack == false)
        {
            transform.Translate(MovableAxis * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(MovableAxis * -Speed * Time.deltaTime);
        }
    }
}
