using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tut : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Player Guide");
    }
}
