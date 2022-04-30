using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
   
    private float a;
  
    private float b;
   
    private float c;
    [SerializeField]
    private bool R = true;

    [SerializeField]
    private bool TrueUp = true;

    [SerializeField]
    private float Speed1 = 0.1f;


    [SerializeField]
    private float d = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        a = transform.position.y;
        b = a + d;
        c = a - d;
    }

    // Update is called once per frame
    void Update()
    {
        if (R == true)
        {
            Speed1 = Random.Range(0.1f, 0.3f);
            d = Random.Range(0.2f, 0.5f);
        }
        
        if (TrueUp == true)
        {
            if (transform.position.y >= b)
            {
                TrueUp = false;

            }
            if (transform.position.y != b)
            {
                transform.Translate(Vector3.up * Speed1 * Time.deltaTime);
                
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
                transform.Translate(Vector3.up * -1 * Speed1 * Time.deltaTime);
                
            }
            
        }
    }
}
