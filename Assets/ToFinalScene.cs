using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFinalScene : MonoBehaviour
{
    public GameObject[] enemies;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); 
        if (enemies.Length == 0)
        {
            SceneManager.LoadScene("Final Scene"); 
        }
    }
}
