using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [Header("Audios")]
    [SerializeField] private AudioSource spawnItemsSound;

    [Header ("UI")]
    [SerializeField] private UIManager uiManager;
    [SerializeField] private float timeLeft;
    [SerializeField] private int finalScore;

    [Header("Objects")]
    [SerializeField] private List<GameObject> items;
    [SerializeField] private Transform parent;

     
    private bool gameEnded;


    public float getTimeLeft()
    {
        return timeLeft;
    }
    
    public void setTimeLeft()
    {
        timeLeft -= Time.deltaTime;
    }
    
    public void addTimeLeft(int time)
    {
        timeLeft += time;
    }

    public int getFinalScore()
    {
        return finalScore;
    }
    public void setFinalScore(int score)
    {
        this.finalScore += score;
    }

    private void Awake() {
        uiManager = UIManager.FindFirstObjectByType<UIManager>();
    }  

    void Start()
    {                              
        gameEnded = false;
        InvokeRepeating("spawnItem", 3f, 2f);
        InvokeRepeating("spawnHourglass", 2f, 20f);
    }

    void Update()
    {
            gameOperating();
            uiManager.updateScore();
    }

    private void spawnItem(){                                        //Spawns a random item in a random position

        spawnItemsSound.Play();
        var i = Random.Range(0 , items.Count);
        var itemTemporal = Instantiate(items[i]);
        var position = new Vector2(Random.Range(-15.3f, 15.53f), 13f);   
        itemTemporal.transform.position = position;
        itemTemporal.gameObject.name = items[i].name;
        itemTemporal.transform.parent = parent.transform;
    
    }

    private void gameOver() 
    { 
        gameEnded = true;
        this.pauseGame();
        CancelInvoke("spawnItem");
        CancelInvoke("spawnHourglass");
        uiManager.activateEndPanel();
    }

    public void pauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void resumeGame()
    {
        Time.timeScale = 1.0f;
    }

    public void gameOperating() {  // Checks the remaining time and ends the game when it's 0

        if (!gameEnded)
        {
            if (timeLeft > 1)
            {
                uiManager.updateTime();
            }
            else
            {
                gameOver();
            }
        }
    }

   private void spawnHourglass(){  //Spawns a hourglass after a certain amount of time in a random position

        spawnItemsSound.Play();
        var timerTemporal = Instantiate(items[6]);
        var positionTimer = new Vector2(Random.Range(-15.3f, 15.53f), 13f);
        timerTemporal.transform.position = positionTimer;
        timerTemporal.gameObject.name = items[6].name;
        timerTemporal.transform.parent = parent.transform;
    
    }
}