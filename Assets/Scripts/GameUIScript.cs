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
        _scoreRed.text = ScoreTracker._teamOneScore.ToString();
        _scoreBlue.text = ScoreTracker._teamTwoScore.ToString();

        string minutes = Mathf.Floor(ScoreTracker._gameTime / 60).ToString("00");
        string seconds = (ScoreTracker._gameTime % 60).ToString("00");
        _timer.text = (string.Format("{0}:{1}", minutes, seconds));
    }
}
