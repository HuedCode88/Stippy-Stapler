using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRoom4 : MonoBehaviour
{
    public GameObject[] enemies;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Checks if enemies are available with tag "Enemy". Note that you should set this to your enemies in the inspector.
        if (enemies.Length == 0)
        {
            SceneManager.LoadScene("Room 4"); // Load the scene with name "OtherSceneName"
        }
    }
}
