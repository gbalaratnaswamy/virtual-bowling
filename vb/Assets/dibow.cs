using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class dibow : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM6", 9600);
    // Start is called before the first frame update
    public Rigidbody rb;
    public Transform dir;
    public Gamemanager Gamemanager;
    //public AudioSource au;
    //  public Text text;
    int a = 0, angle;
    int velocity;
    int b = 0;
    int r = 20;

    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 100;
        // au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a < 3)
        {
            if (sp.IsOpen)
            {
                b = Int32.Parse(sp.ReadLine());
                if (a == 0 && b == 3000)
                {
                    // StartCoroutine(HandleIt());
                    a = 1;

                }
                else if (a == 0)
                {
                    dir.position = new Vector3(-r * Mathf.Sin(b * Mathf.PI / 180), 0, r * Mathf.Cos(b * Mathf.PI / 180));
                    //transform.Rotate(0, 0, Int32.Parse(sp.ReadLine()));
                    angle = b;
                    //  Debug.Log(b);

                }
                else if (a == 1 && b == 5000)
                {
                    a = 2;
                }
                else if (a == 1)
                {
                    velocity = b;
                }
                else if (a == 2)
                {
                    //  transform.Translate(5*Time.deltaTime,5*Time.deltaTime, 0);
                    rb.AddForce(-100 * velocity * Mathf.Sin(angle * Mathf.PI / 180) * Time.deltaTime, 0, 100 * velocity * Mathf.Cos(angle * Mathf.PI / 180) * Time.deltaTime, ForceMode.Impulse);
                    a = 3;
                    //rb.AddForce(0, 0, 100);
                    // Debug.Log("object moves");
                    //  Debug.Log(Mathf.Cos(angle*Mathf.PI/180));
                    // text.text = b

                }


                // IEnumerator HandleIt()
                // {

                //     // process pre-yield
                //     yield return new WaitForSeconds(1.0f);
                //    // process post-yield
                //    Debug.Log("paused");

                // }

            }
        }
        else if (a == 3)
        {
            Vector3 v3Velocity = rb.velocity;
            if (rb.velocity.x < 0.25 && rb.velocity.z < 0.25)
            {
                FindObjectOfType<Gamemanager>().gameend();
                // au.Play();
            }
        }
    }
}

