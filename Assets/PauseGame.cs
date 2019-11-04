using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("game is paused");

            Time.timeScale = 0f;
        }
    }

}
