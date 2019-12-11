using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{

    [SerializeField] private int score = default;
    [SerializeField] private TextMeshProUGUI txtScore = default;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
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
