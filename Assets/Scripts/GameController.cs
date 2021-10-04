using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float elapsedTime;
    public float timeSinceLastBlock;
    public float refreshTime;
    private Text timeText;
    private RectTransform successText;
    public GoalController goalPost;
    public GameObject woodenBoxPrefab;
    public GameObject greenBoxPrefab;
    public GameObject blueBoxPrefab;
    private bool isSuccessMessageDisplayed;


    // Start is called before the first frame update
    void Start()
    {
        timeText = transform.Find("TimeText")
			.GetComponent<Text>();
        goalPost = transform.Find("Goal")
            .GetComponent<GoalController>();
        successText = transform.Find("SuccessMessage")
            .GetComponent<RectTransform>();
        elapsedTime = 0;
        timeSinceLastBlock = 0;
        refreshTime = 1;
        isSuccessMessageDisplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
            RestartGame();

        if (Input.GetKey(KeyCode.Q))
            QuitGame();
        
        if (!goalPost.isGameOver){
            UpdateTime();
            UpdateHUD();
        }
        if (goalPost.isGameOver && !isSuccessMessageDisplayed){
            MoveSuccessMessageIntoView();
            SaveHighScore();
            isSuccessMessageDisplayed = true;
        }
    }

    private void MoveSuccessMessageIntoView(){
        successText.anchoredPosition = new Vector3(0f, 150f, 0f);
    }

    private void UpdateTime()
	{
		elapsedTime += (Time.deltaTime);
        timeSinceLastBlock += (Time.deltaTime);

        if (timeSinceLastBlock > refreshTime)
		{
            var state = UnityEngine.Random.Range(0, 3);
            GameObject leftObject = this.gameObject;

            switch(state){
                case 0:
                    leftObject = Instantiate(woodenBoxPrefab);
                    break;
                case 1:
                    leftObject = Instantiate(greenBoxPrefab);
                    break;
                case 2:
                    leftObject = Instantiate(blueBoxPrefab);
                    break;
                default:
                    break;
            }

            state = UnityEngine.Random.Range(0, 3);
            var pos = leftObject.GetComponent<Rigidbody2D>().position;
            var vec3 = new Vector3(-pos.x, pos.y, 0);

            switch(state){
                case 0:
                    Instantiate(woodenBoxPrefab, vec3, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(greenBoxPrefab, vec3, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(blueBoxPrefab, vec3, Quaternion.identity);
                    break;
                default:
                    break;
            }
			
			timeSinceLastBlock = 0;
		}
	}

    private void UpdateHUD()
	{
		if (string.IsNullOrEmpty(elapsedTime.ToString()))
			return;
		timeText.text = "Time: " + (int)elapsedTime + " seconds";
		PlayerPrefs.SetInt("score", (int)elapsedTime);
	}

    private void RestartGame()
	{
        SceneManager.LoadScene("game", LoadSceneMode.Single);
	}

    public void QuitGame()
    {
        Application.Quit();
    }
    
    private void SaveHighScore()
	{
		var currentScore = PlayerPrefs.GetInt("score", 9999);
		var highscore = PlayerPrefs.GetInt("highscore", 9999);

		if (currentScore < highscore)
		{
			PlayerPrefs.SetInt("highscore", currentScore);
            timeText.text = (int)elapsedTime
                + " seconds is the best time so far!";
		}
        else{
            timeText.text = (int)elapsedTime
                + " seconds - can you beat the best time ("
                + highscore
                + " seconds)?";
        }
	}
}
