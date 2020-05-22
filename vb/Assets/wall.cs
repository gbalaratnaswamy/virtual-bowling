using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    // Start is called before the first frame update
    // void ontrigger
    // {
    //   if (collision.collider.tag == "player")
    //////    {
    // //       FindObjectOfType<Gamemanager>().gameend();
    //  }
    // }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            FindObjectOfType<Gamemanager>().gameend();
        }
    }
}
