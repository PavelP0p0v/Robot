using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    // Start is called before the first frame update
    private float Fall = -100f;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Object")
        {

            transform.parent = collision.transform;
            
        }
       
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Object")
        {
            transform.parent = null;

        }
    }

    void Update()
    {
        if (transform.position.y <= Fall)
        {
            Destroy(this.gameObject);
        }
    }
}
