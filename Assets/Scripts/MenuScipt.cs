using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScipt : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        ScoreTracker.GameTime = 120;
        PlayerColour.BlueteamPlayers = 0;
        PlayerColour.RedTeamPlayers = 0;
        ScoreTracker.TeamOneScore = 0;
        ScoreTracker.TeamTwoScore = 0;
        PauseScript._isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void Resume()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1;
        PauseScript._isPaused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
