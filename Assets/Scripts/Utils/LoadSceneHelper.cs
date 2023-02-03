using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void LoadScene(string s)
    {
        SceneManager.LoadScene(s);
    } 
}
