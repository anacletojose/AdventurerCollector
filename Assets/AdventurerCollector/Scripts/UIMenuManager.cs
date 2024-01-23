using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    [Header("MenuPanels")]
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject creditPanel;
    [SerializeField] private GameObject tutorialPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deactivateOptionsPanel()
    {
        if (optionsPanel.activeInHierarchy)
        {
            menuPanel.SetActive(true);
            optionsPanel.SetActive(false);
        }
    }

    public void activateOptionsPanel()
    {
        if (!optionsPanel.activeInHierarchy)
        {
            menuPanel.SetActive(false);
            optionsPanel.SetActive(true);
        }
    }

    public void deactivateCreditsPanel()
    {
        if (creditPanel.activeInHierarchy)
        {
            menuPanel.SetActive(true);
            creditPanel.SetActive(false);
        }
    }

    public void activateCreditsPanel()
    {
        if (!creditPanel.activeInHierarchy) 
        {
            menuPanel.SetActive(false);
            creditPanel.SetActive(true);
        }
    }
    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void deactivateTutorialPanel()
    {
        if (tutorialPanel.activeInHierarchy)
        {
            menuPanel.SetActive(true);
            tutorialPanel.SetActive(false);
        }
    }

    public void activateTutorialPanel()
    {
        if (!tutorialPanel.activeInHierarchy)
        {
            menuPanel.SetActive(false);
            tutorialPanel.SetActive(true);
        }
    }

}
