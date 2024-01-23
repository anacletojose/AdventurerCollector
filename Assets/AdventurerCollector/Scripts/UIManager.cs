using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeLeftText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI currentTimeLeftText;

    [Header("Panels")]
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject pausePanel; 
    [SerializeField] private GameObject optionPanel;


    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    void Start()
    {
        
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Delete) && !pausePanel.activeInHierarchy && !finalPanel.activeInHierarchy && !optionPanel.activeInHierarchy)
        {
            activatePausePanel();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Delete) && (pausePanel.activeInHierarchy || optionPanel.activeInHierarchy))
            {
                resume();
            }
        }
    }

    private void resume()
    {
        pausePanel.SetActive(false);
        optionPanel.SetActive(false);
        gameManager.resumeGame();
    }

    public void activateEndPanel()
    {
        if (finalPanel != null)
        {
            finalPanel.SetActive(true);
        }
        finalScoreText.text = gameManager.getFinalScore().ToString();
    }

    public void updateTime()
    {
        gameManager.setTimeLeft();
        timeLeftText.text = Mathf.FloorToInt(gameManager.getTimeLeft()).ToString();
    }

    public void updateScore()
    {
        scoreText.text = gameManager.getFinalScore().ToString();
    }

    public void activatePausePanel()
    {
        if (!pausePanel.activeInHierarchy && !finalPanel.activeInHierarchy)
        {
            pausePanel.SetActive(true);
            currentScoreText.text = gameManager.getFinalScore().ToString();
            currentTimeLeftText.text = Mathf.FloorToInt(gameManager.getTimeLeft()).ToString();
            gameManager.pauseGame();
        }
    }

    public void deactivatePausePanel()
    {
        if (pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
            gameManager.resumeGame();
        }
    }

    public void activateOptionPanel()
    {
        if (!optionPanel.activeInHierarchy)
        {
            optionPanel.SetActive(true);
            pausePanel.SetActive(false);
        }
    }

    public void deactivateOptionPanel()
    {
        if (optionPanel.activeInHierarchy)
        {
            optionPanel.SetActive(false);
            pausePanel.SetActive(true);
        }
    }

    public void goToMenu()
    {
        gameManager.resumeGame();
        SceneManager.LoadScene("Menu");
    }

    public void restartGame()
    {
        gameManager.resumeGame();
        SceneManager.LoadScene("Game");
    }
}
