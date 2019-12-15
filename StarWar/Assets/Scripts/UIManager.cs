using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private int score = default;
    [SerializeField] private TextMeshProUGUI txtScore = default;
    [SerializeField] private int wave = default;
    [SerializeField] private TextMeshProUGUI txtWave = default;
    [SerializeField] private TextMeshProUGUI _temps = default;
    [SerializeField] private GameObject iField = default;
    [SerializeField] private InputField iField2 = default;
    DapperDino.Scoreboards.ScoreboardEntryData entry;
    [SerializeField] DapperDino.Scoreboards.Scoreboard scoreboard;
    private float _chrono;
    [Range(0.1f, 10.0f)] [SerializeField] private float _vitJeu = 0.75f;
    private string tempsScore = null;
    private bool canDestroy = false;
    private string name = null;
    // Start is called before the first frame update

    private void Awake()
    {
        int compteurJeu = FindObjectsOfType<UIManager>().Length;
        if (compteurJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        score = 0;
        wave = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (!canDestroy)
        {
            if (!FindObjectOfType<SpawnManager>().ArretJeu())
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
                tempsScore = _temps.ToString();
            }
        }

        if (!canDestroy) 
        { 
            if (FindObjectOfType<SpawnManager>().ArretJeu())
            {
                iField.SetActive(true);
               

                
                
            }
        }
    }

    public int Getminute()
    {
        int minute = (int)(_chrono) / 60;
        return minute;
    }
    public int Getsec()
    {
        int seconde = (int)(_chrono) % 60;
        return seconde;
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
    public int GetWave()
    {
        return wave;
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
    public int GetScore()
    {
        return score;
    }

    private void sethighscore()
    {



        entry.entryName = name;
        entry.entryScore = score;
        entry.entryTime = _chrono;
        entry.entryWave = wave;
        scoreboard.AddEntry(entry);
        canDestroy = true;
    }

    public void AskName()
    {
        name = iField2.text;
        sethighscore();
        FindObjectOfType<GestionScene>().ChangerScene();
    }
    public string GetName()
    {
        iField.SetActive(false);
        return name;
    }
   public bool CanDestroy()
    {
        return canDestroy;
    }
    public void SeekAndDestroy()
    {
        Destroy(this.gameObject);
    }

}
