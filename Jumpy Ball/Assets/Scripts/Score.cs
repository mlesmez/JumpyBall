using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{ 
    public Text platformScore;
    public GameObject player;
    public GameObject spawner;
    private PlayerController _playerControllerScirpt;
    private PlatformCounter _platformCounterScript;
    private int score = 0;

    
    void Awake()
    {
        _playerControllerScirpt = player.GetComponent<PlayerController>();
        _platformCounterScript = spawner.GetComponent<PlatformCounter>();
        
    }
    void Update()
    {
        score = _platformCounterScript.platformCount;
        if (_playerControllerScirpt._gameOver)
        {
            setScore(score);
        }
    }

    void setScore(int platformCount)
    {
        platformScore.text = "Score: " + platformCount;
    }
}
