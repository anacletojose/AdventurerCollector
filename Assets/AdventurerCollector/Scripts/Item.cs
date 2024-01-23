using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] float speedMax;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private GameManager _gameManager;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        speedMax = 5f;
        _rigidbody2D.gravityScale = Random.Range(1f, speedMax);
        _gameManager = FindFirstObjectByType<GameManager>();
        _audioManager = FindFirstObjectByType<AudioManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":

                switch (tag)
                {
                    case "GoodItem":
                        increaseScore();
                        _audioManager.PlayAudioClip(1);
                        break;

                    case "BadItem":
                        increaseScore();
                        _audioManager.PlayAudioClip(0);
                        break;

                    case "TimeItem":
                        increaseTime(5);
                        _audioManager.PlayAudioClip(2); 
                        break;
                }
                break;
            
            case "Floor":
                break;
        }

        Destroy(gameObject);
    }

    private void increaseTime(int time)
    {
        _gameManager.addTimeLeft(time);
    }

    private void Update(){}

    private void increaseScore()
    {
       _gameManager.setFinalScore(score);     
    }

}