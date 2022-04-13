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

   [SerializeField]
    private List<AudioClip> VolumeList;

    private float BorderFall = -20f;

    private Rigidbody rb;
    private AudioSource audio;
    public float Speed = 5.0f;
    public float JumpStrange = 5.0f;

    private bool isJump = true;
    private bool z = false;

    private bool musicCan = true;
    private float timeResetCanMusic = 0;
    private float needTimePlay = 0; 

    void Start()
    {
        Cursor.visible = z;
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float moveV = Input.GetAxis("Vertical");



        if (transform.position.y <= BorderFall)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //transform.position = StartPosition.transform.position;
        }

       

        float moveH = Input.GetAxis("Horizontal");

        const float magnitude = 0.05f;

        /*if ((moveV > magnitude || moveV < -magnitude) || (moveH > magnitude || moveH < -magnitude))
        {
            PlayStepPlayer();
        }*/

        if (!musicCan) {
            timeResetCanMusic += Time.deltaTime;
        }
        if (!musicCan && (timeResetCanMusic >= needTimePlay)) {
            needTimePlay = 0;
            timeResetCanMusic = 0;
            musicCan = !musicCan;
        }



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
        if (collision.gameObject.tag == "Object")
        {

            PlayStepPlayer();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Object")
        {
            transform.parent = null;

        }
    }

    private void PlayStepPlayer() {
        if (musicCan)
        {
            musicCan = !musicCan;
            audio.pitch = 2;
            needTimePlay = VolumeList[0].length;
            audio.PlayOneShot(VolumeList[0]);
        }
    }


   
}
