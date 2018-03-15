using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnToMenu : MonoBehaviour {

    private void Update()
    {
        if(Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(0);
        }
    }

}
