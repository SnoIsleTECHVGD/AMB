using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject Menu;

    private void OnMouseDown()
    {
        Menu.SetActive(true);
    }

}
