using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public int frameRate;
    public TextMeshProUGUI forceCount;
    public GameObject player;
    public GameObject winScreen;
    public TextMeshProUGUI fpsCounter;
    // Start is called before the first frame update
    void Start()
    {
       frameRate = PlayerPrefs.GetInt("framerate", Application.targetFrameRate);
        Application.targetFrameRate = frameRate;
    }

    // Update is called once per frame
    void Update()
    {
        forceCount.text = "Throw Force = " + player.GetComponentInChildren<GravityGun>().throwForce.ToString();
        fpsCounter.text = (1.0f / Time.deltaTime).ToString();
    }

    public void VictoryScreen()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
