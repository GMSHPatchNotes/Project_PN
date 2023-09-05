using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] Image Health_Fill;
    public static float Health = 100;
    public static uint AD = 0;
    public static uint AP = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Health_Fill.fillAmount = Health * 0.01f;
        if(Health_Fill.fillAmount <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
