using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchPlayer : MonoBehaviour
{
    // Hold Players and Cameras
    public List<ThirdPersonMovement> playerMovers;
    public List<GameObject> playerCameras;
    public KeyCode switcherKey = KeyCode.E;
    public KeyCode escapeKey = KeyCode.Escape;

    private int _activePlayerIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Turn off Movers
        for (int i = 0; i < playerMovers.Count; i++)
        {
            playerMovers[i].isActive = false;
        }

        // Turn off Cameras
        for (int i = 0; i < playerCameras.Count; i++)
        {
            playerCameras[i].SetActive(false);
        }

        playerMovers[_activePlayerIndex].isActive = true;
        playerCameras[_activePlayerIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Perform Switch
        if (Input.GetKeyDown(switcherKey))
        {
            // Deactivate Current Player
            playerMovers[_activePlayerIndex].isActive = false;
            playerCameras[_activePlayerIndex].SetActive(false);

            // Increase Index
            if (_activePlayerIndex < playerMovers.Count - 1 && _activePlayerIndex < playerCameras.Count - 1)
            {
                _activePlayerIndex++;
            }
            else
            {
                _activePlayerIndex = 0;
            }

            // Apply the Switch
            playerMovers[_activePlayerIndex].isActive = true;
            playerCameras[_activePlayerIndex].SetActive(true);

            Debug.Log(_activePlayerIndex);
        }

        // Allow Return to Main Menu
        if (Input.GetKeyDown(escapeKey))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
