using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "LevelReference", menuName = "Level Reference", order = 1)]
public class LevelReference : ScriptableObject
{
    public string sceneName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}