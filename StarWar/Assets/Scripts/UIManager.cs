using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{

    [SerializeField] private int score = default;
    [SerializeField] private TextMeshProUGUI txtScore = default;
    [SerializeField] private int wave = default;
    [SerializeField] private TextMeshProUGUI txtWave = default;
    [SerializeField] private TextMeshProUGUI _temps = default;
    private float _chrono;
    [Range(0.1f, 10.0f)] [SerializeField] private float _vitJeu = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        wave = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = _vitJeu;
        _chrono += Time.deltaTime;
        int minute = (int)(_chrono) / 60;
        int seconde = (int)(_chrono) % 60;
        if (seconde == 0 || seconde == 1 || seconde == 2 || seconde == 3 || seconde == 4 || seconde == 5 || seconde == 6 || seconde == 7 || seconde == 8 || seconde == 9)
        {
            _temps.SetText(minute + ": 0" + seconde);
        }
        else
        {
            _temps.SetText(minute + " : " + seconde);
        }
    }

    public void AddWave()
    {
        wave++;
        setWave();
    }
    private void setWave()
    {
        txtWave.text = "Wave " + wave.ToString();
    }
    public void AddScore(int points)
    {
        score += points;
        setScore();
    }
    private void setScore()
    {
        txtScore.text = "Score: " + score.ToString();
    }
}
