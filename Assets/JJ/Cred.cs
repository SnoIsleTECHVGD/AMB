using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cred : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Credit scene");
    }
}