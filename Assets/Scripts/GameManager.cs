using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MyInputs inputActions;

    public Transform playerLocation;

    public GameObject victoryScreen;

    int score = 0;

    int bossThreshold = 2000;

    public TextMeshProUGUI scoreText;

    string defaultText = "Score: ";

    public Action<int> changePoints;

    public void ChangeScore(int points)
    {
        if (changePoints != null)
        {
            changePoints(points);
        }
    }

    public Action beginBossFight;
    bool bossIsActive = false;

    void IncreaseScore(int points)
    {
        score += points;
        UpdateText();
        if (!bossIsActive && score >= bossThreshold)
        {
            bossIsActive = true;
            beginBossFight();
        }
    }

    void UpdateText()
    {
        scoreText.text = defaultText + score.ToString();
    }
    

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        inputActions = new MyInputs();
        inputActions.Player.Enable();
        changePoints += IncreaseScore;
        victoryScreen.SetActive(false);
    }

    private void OnDestroy()
    {
        changePoints -= IncreaseScore;
        inputActions.Player.Disable();
        changePoints = null;
        beginBossFight = null;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void WinGame()
    {
        victoryScreen.SetActive(true);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
