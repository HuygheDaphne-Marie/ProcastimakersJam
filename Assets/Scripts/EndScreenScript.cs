using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{
    [SerializeField]
    Sprite _TeamOneWonTexture;
    [SerializeField]
    Sprite _TeamTwoWonTexture;
    [SerializeField]
    Text _scoreRed;
    [SerializeField]
    Text _scoreBlue;

    Image _currentImage;
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        _currentImage = canvas.transform.GetChild(0).GetComponent<Image>();

        _scoreRed = canvas.transform.GetChild(1).GetComponent<Text>();
        _scoreBlue = canvas.transform.GetChild(2).GetComponent<Text>();

        if (ScoreTracker.TeamOneScore > ScoreTracker.TeamTwoScore)
        {
            _currentImage.sprite = _TeamOneWonTexture;

            var temp = _scoreRed.transform.position;
            _scoreRed.transform.position = _scoreBlue.transform.position;
            _scoreBlue.transform.position = temp;
        }
        else if (ScoreTracker.TeamOneScore < ScoreTracker.TeamTwoScore)
        {
            _currentImage.sprite = _TeamTwoWonTexture;
        }
        else
        {
            _currentImage.sprite = _TeamOneWonTexture;

           var temp = _scoreRed.transform.position;
           _scoreRed.transform.position = _scoreBlue.transform.position;
           _scoreBlue.transform.position = temp;
        }

        _scoreBlue.text = ScoreTracker.TeamOneScore.ToString();
        _scoreRed.text = ScoreTracker.TeamTwoScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
