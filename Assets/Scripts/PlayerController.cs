using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject StartPosition;

   

    private float BorderFall = -20f;

    private Rigidbody rb;
   
    public float Speed = 5.0f;
    public float JumpStrange = 5.0f;

    private bool isJump = true;
    private bool z = false;

    

    void Start()
    {
        Cursor.visible = z;
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            z = !z;
            Cursor.visible = z;
        }
        float moveV = Input.GetAxis("Vertical");



        if (transform.position.y <= BorderFall)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //transform.position = StartPosition.transform.position;
        }

       

        float moveH = Input.GetAxis("Horizontal");

       

        /*if ((moveV > magnitude || moveV < -magnitude) || (moveH > magnitude || moveH < -magnitude))
        {
            PlayStepPlayer();
        }*/

       



        transform.Translate(Vector3.forward * moveV * Speed * Time.deltaTime); //Движение
        transform.Translate(Vector3.right * moveH * Speed * Time.deltaTime);





        if (Input.GetButton("Jump") && isJump == false)
        {
            isJump = true;
            rb.velocity += Vector3.up * JumpStrange;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Object")
        {

            transform.parent = collision.transform;
            isJump = false;
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Object")
        {
            transform.parent = null;

        }
    }

    


   
}
