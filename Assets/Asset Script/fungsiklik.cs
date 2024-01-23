using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fungsiklik : MonoBehaviour
{
    public void Loadbyindex(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void keluar()
    {
        Application.Quit();
    }
}
