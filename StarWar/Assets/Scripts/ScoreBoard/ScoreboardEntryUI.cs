using TMPro;
using UnityEngine;


namespace DapperDino.Scoreboards
{

    public class ScoreboardEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entryNameText = null;
        [SerializeField] private TextMeshProUGUI entryScoreText = null;
        [SerializeField] private TextMeshProUGUI entryTimeText = null;
        [SerializeField] private TextMeshProUGUI entryWaveText = null;

        //public void Initialise(ScoreboardEntryData scoreEntryData)
        public void Initialise(ScoreboardEntryData scoreEntryData)
        {          
            
            entryNameText.text = scoreEntryData.entryName;
            entryScoreText.text = scoreEntryData.entryScore.ToString();
            entryTimeText.text = scoreEntryData.entryTime.ToString();               
            entryWaveText.text = scoreEntryData.entryWave.ToString();

            
               int minute = (int)(scoreEntryData.entryTime) / 60;
               int seconde = (int)(scoreEntryData.entryTime) % 60;
                if (seconde == 0 || seconde == 1 || seconde == 2 || seconde == 3 || seconde == 4 || seconde == 5 || seconde == 6 || seconde == 7 || seconde == 8 || seconde == 9)
                {
                    entryTimeText.SetText(minute + ": 0" + seconde);
                }
                else
                {
                    entryTimeText.SetText(minute + " : " + seconde);
                }
        }

    }
}

  
