using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI times;
    // public List<GameObject> targets;


    // public TextMeshProUGUI gameOverText;
    // public bool isGameActive;
    // public Button restartButton;
    // public GameObject titleScreen;

    public float timeLimit = 60f; // Waktu yang ditetapkan (dalam detik)
    private float timeRemaining; // Waktu yang tersisa
 
    void Start()
    {
        timeRemaining = timeLimit;
        
    }

    // Update is called once per frame
    void Update(){

        if (timeRemaining > 1f)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            
            // Waktu habis, lakukan tindakan yang diinginkan
            Debug.Log("Waktu habis!");
        }
 }
 
     private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        times.text = "Waktu: " + timeString;
    }
}
