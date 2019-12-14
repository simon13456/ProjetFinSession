using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    [SerializeField] GameObject instructions = default;
    [SerializeField] GameObject scoreFinal = default;
    [SerializeField] GameObject leaderBoard = default;
    public void Instruction()
    {
        instructions.SetActive(true);
    }
    public void QuitInstruction()
    {
        instructions.SetActive(false);
    }
    public void SeeLeaderBoard()
    {
        leaderBoard.SetActive(true);
        scoreFinal.SetActive(false);
    }
    public void QuitLeaderBoard()
    {
        leaderBoard.SetActive(false);
        scoreFinal.SetActive(true);
    }
    
    public void ChangerScene()
    {
        int indexSceneCourante = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexSceneCourante + 1);

    }
    public int getNiveau()
    {
        int SceneCourante = SceneManager.GetActiveScene().buildIndex;
        return SceneCourante;
    }

    public void quitter()
    {
        Application.Quit();
    }
    public void reco()
    {
        int indexSceneCourante = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }
}
