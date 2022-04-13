using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerPlatform : MonoBehaviour
{
    [SerializeField]
    
   

   
    private float a;

    private float b;

    private float c;
    [SerializeField]
    private bool DangerGo = false;

    [SerializeField]
    private bool Danger = false;
    
   
    [SerializeField]
    private bool TrueUp = true;
    

    [SerializeField]
    private float Speed = 0.1f;


    [SerializeField]
    private float d = 0.2f;

    

    
    void Start()
    {

        GetComponent<BoxCollider>();


        a = transform.position.y;
        b = a + d;
        c = a - d;
       

    }

   
    void Update()
    {
        
        if (DangerGo == true)
        {
            GetComponent<MeshRenderer>().enabled = false;
            
            transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(TestCoroutine2());
            DangerGo = false;
            
        }
        
        if (Danger == false)
        {

            if (TrueUp == true)
            {
                if (transform.position.y >= b)
                {
                    TrueUp = false;

                }
                if (transform.position.y != b)
                {
                    transform.Translate(Vector3.up * Speed * Time.deltaTime);

                }


            }
            if (TrueUp == false)
            {
                if (transform.position.y <= c)
                {
                    TrueUp = true;

                }
                if (transform.position.y != c)
                {
                    transform.Translate(Vector3.up * -1 * Speed * Time.deltaTime);

                }

            }
        }
        if (Danger == true)
        {
            StartCoroutine(TestCoroutine());
          
        }
    }
   
    IEnumerator TestCoroutine()
    {
            yield return new WaitForSeconds(2);
            DangerGo = true;
            
        
    }
    IEnumerator TestCoroutine2()
    {
        yield return new WaitForSeconds(2);
        GetComponent<MeshRenderer>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;
        Danger = false;
}
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player" )
        {
            Danger = true;
           
        }
    }
    

}

