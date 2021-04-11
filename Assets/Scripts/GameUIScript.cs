using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{
    [SerializeField]
    Text _timer;
    [SerializeField]
    Text _scoreRed;
    [SerializeField]
    Text _scoreBlue;

    // Update is called once per frame
    void Update()
    {
        _scoreBlue.text = ScoreTracker.TeamOneScore.ToString();
        _scoreRed.text = ScoreTracker.TeamTwoScore.ToString();

        string minutes = Mathf.Floor(ScoreTracker.GameTime / 60).ToString("00");
        string seconds = (ScoreTracker.GameTime % 60).ToString("00");
        _timer.text = (string.Format("{0}:{1}", minutes, seconds));
    }
}
