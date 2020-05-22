using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    public Transform dir;
    public Transform ang;
    // Start is called before the first frame update
   // public Rigidbody rb;
    public int a;
    void Start()
    {
        //Debug.Log("Helloworld");
     //   rb.AddForce(0, 0, 800,ForceMode.Impulse);
       // dir.position = new Vector3(25 * Mathf.Sin(a * Mathf.PI / 180), 0,25 * Mathf.Cos(a * Mathf.PI / 180));
       // ang.rotation = Quaternion.Euler(0,a-90,0);
    }


    // Update is called once per frame
    void Update()
    {
        dir.position = new Vector3(-5.1f - 10 * Mathf.Sin(30 * Mathf.PI / 180), 4.5f, 39.7f + 10 * Mathf.Cos(30 * Mathf.PI / 180));
        dir.localRotation = Quaternion.Euler(90, -30, 0);
        //rb.AddForce(0, 0, 400*Time.deltaTime, ForceMode.Impulse);
        //if (Input.GetKey("d"))
       // {
            
       // }
    }
    void OnCollisionEnter()
    {
        
  
    }
}
