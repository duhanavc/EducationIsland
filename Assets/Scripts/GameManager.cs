using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject canvas;
    public TextMeshProUGUI score_TeamA;
    public TextMeshProUGUI score_TeamB;
    public TextMeshProUGUI score_TeamC;
    public int scoreA = 0;
    public int scoreB = 0;
    public int scoreC = 0;

    private bool isTabDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBoradHandler();

    }

    private void ScoreBoradHandler()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isTabDown)
        {
            canvas.SetActive(true);
            isTabDown = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isTabDown)
        {
            canvas.SetActive(false);
            isTabDown = false;
        }
    }

    public void AddScoreTeamA()
    {
        scoreA += 5;
        score_TeamA.text = $"SCORE : {scoreA}";
    }
    public void AddScoreTeamB()
    {
        scoreB += 5;
        score_TeamB.text = $"SCORE : {scoreB}";
    }
    public void AddScoreTeamC()
    {
        scoreC += 5;
        score_TeamC.text = $"SCORE : {scoreC}";
    }
}
