using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehavior : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject creditsPanel;
    public GameObject levelPanel;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        ActivateMainPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DeactivateAllPanels()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(false);
        levelPanel.SetActive(false);
}

    public void ActivateMainPanel()
    {
        DeactivateAllPanels();
        mainPanel.SetActive(true);
    }
    
    public void ActivateCreditsPanel()
    {
        DeactivateAllPanels();
        creditsPanel.SetActive(true);
    }
    
    public void ActivateLevelPanel()
    {
        DeactivateAllPanels();
        levelPanel.SetActive(true);
    }
}
