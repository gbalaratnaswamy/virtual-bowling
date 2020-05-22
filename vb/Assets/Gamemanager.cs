using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public Transform k1;
    public Transform k2;
    public Transform k3;
    public Transform k4;
    public Transform k5;
    public Transform k6;
    public Transform k7;
    public Transform k8;
    public Transform k9;
    public Transform k10;
    public Text score;
    public GameObject scoreui;
    bool g = false;

    public void gameend()
    {
        if (g == false)
        {
            g = true;
            //Debug.Log("gameend");
            Invoke("end", 5f);
        }
    }
    void end()
    {
        
        int a = 0;
        if ((int)k1.localRotation.eulerAngles.x > 40 ||(int)k1.localRotation.eulerAngles.z> 40|| k1.localPosition.z>33)
            {
                a = a + 1;
            }
        Debug.Log(a);
        if ((int)k2.localRotation.eulerAngles.x > 40 || (int)k2.localRotation.eulerAngles.z > 40 || k2.localPosition.z > 40)
        {
            a = a + 1;
        }
        Debug.Log(a);
        if ((int)k3.localRotation.eulerAngles.x > 40 || (int)k3.localRotation.eulerAngles.z > 40 || k3.localPosition.z > 33)
        {
            a = a + 1;
        }
        Debug.Log(a);
        Debug.Log(k3.localPosition.z);
        Debug.Log((int)k3.localRotation.eulerAngles.z);
        Debug.Log((int)k3.localRotation.eulerAngles.x);
        if ((int)k4.localRotation.eulerAngles.x > 40 || (int)k4.localRotation.eulerAngles.z > 40 || k4.localPosition.z > 33)
        {
            a = a + 1;
        }
        Debug.Log(a);
        if ((int)k5.localRotation.eulerAngles.x > 40 || (int)k5.localRotation.eulerAngles.z > 40 || k5.localPosition.z > 45)
        {
            a = a + 1;
        }
        Debug.Log(a);
        if ((int)k6.localRotation.eulerAngles.x > 40 || (int)k6.localRotation.eulerAngles.z > 40 || k6.localPosition.z > 36)
        {
            a = a + 1;
        }
        Debug.Log(a);
        if ((int)k7.localRotation.eulerAngles.x > 40 || (int)k7.localRotation.eulerAngles.z > 40 || k7.localPosition.z >36)
        {
            a = a + 1;
        }
        Debug.Log(a);
        if ((int)k8.localRotation.eulerAngles.x > 40 || (int)k8.localRotation.eulerAngles.z > 40 || k8.localPosition.z > 40)
        {
            a = a + 1;
        }
        Debug.Log(a);
        if ((int)k9.localRotation.eulerAngles.x > 40 || (int)k9.localRotation.eulerAngles.z > 40 || k9.localPosition.z > 33)
        {
            a = a + 1;
        }
        Debug.Log(a);
        if ((int)k10.localRotation.eulerAngles.x > 40 || (int)k10.localRotation.eulerAngles.z > 40 || k10.localPosition.z > 36)
        {
            a = a + 1;
        }
        score.text = a.ToString();
        Debug.Log(a);
        if (a == 10)
        {
            score.text = "Strike!!!";
        }
        
        scoreui.SetActive(true);
        Invoke("restart", 10f);

    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Start is called before the first frame update

}
