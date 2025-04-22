using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Public Variables
    public string sceneName;
    public Activator activator;

    // Private Variables
    private float _timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activator.isActive)
        {
            _timer += Time.deltaTime;

            if (_timer >= 1)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
