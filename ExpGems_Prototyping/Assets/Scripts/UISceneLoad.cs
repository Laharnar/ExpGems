using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneLoad : MonoBehaviour
{
    public string[] scenes;

    public void SceneLoad(int i)
    {
        if (i >= scenes.Length) return;

        StringBuilder s = new StringBuilder();
        s.Append("Loading scene");
        s.Append(scenes[i]);
        Debug.Log(s.ToString());

        SceneManager.LoadScene(scenes[i]);
    }
}
