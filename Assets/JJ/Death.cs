using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        SceneManager.LoadScene("2");
    }
}
