using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange1 : MonoBehaviour
{
    public void press()
    {
        SceneManager.LoadScene("CreditScene");
    }
}