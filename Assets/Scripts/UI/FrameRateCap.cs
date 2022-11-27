using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class FrameRateCap : MonoBehaviour
{
    #region Resolution Variables
    public Resolution[] resolution;
    //the array of resolutions include the screen's available resolutions
    public Dropdown resDropdown;
    //resolution dropdown
    #endregion
    #region Refresh Rates Variables
    public Dropdown refreshRates;
    //refreshrate dropdown
    public int refRate;
    public int targetFrameRate;
    public int currentFrameRate;
    public bool frameRateSet;
    public TextMeshProUGUI fpsText;
    public List<int> fps = new List<int>(3 );
    public int currentFps;
    public Slider fpsCap;
    public int fpsValue;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        #region Set List of Resolutions
        resolution = Screen.resolutions;
        //gets all available resolutions.
        resDropdown.ClearOptions();
        //removes all options (this is just in case the player starts the game with a new screen)
        List<string> options = new List<string>();
        //a new list that will store all the options ie (1280 x 720)

        int currentResolutionIndex = 0;
        //the position in the array of resolutions that the game is currently using 
        for (int i = 0; i < resolution.Length; i++)
        {
            string option = resolution[i].width + " x " + resolution[i].height + " @ " + resolution[i].refreshRate;
            //each option for the resolutions displays the current resolution dimensions as a string
            options.Add(option);
            if (resolution[i].width == Screen.width && resolution[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResolutionIndex;
        resDropdown.RefreshShownValue();
        #endregion
        #region Add FrameRates
        fps.Add(30);
        fps.Add(60);
        fps.Add(120);
        //this piece of shit code still results in an empty list fuck it I'll do it manually
        #endregion
        frameRateSet = false; 

        int[] refreshRates = new Int32[resolution.Length];
        for (int i = 0; i < refreshRates.Length; i++)
        {
            refreshRates[i] = resolution[i].refreshRate;
        }
        targetFrameRate = refRate;

        
    }
    

    // Update is called once per frame
    void Update()
    {
        UpdateFrameRate();
    }
    public void FPSButtonLeft()
    {
        fpsValue--;
        Debug.Log("Current Capped FPS preset is " + currentFps.ToString());
        if (fpsValue < 0)
        {
            fpsValue = 0;
            Debug.LogError("Already at Lowest Framerate");
        }
    }
    public void FPSButtonRight()
    {
        fpsValue++;
        if (fpsValue > 2)
        {
            fpsValue = 2;
            Debug.LogError("Already at Maximum Framerate");
        }
    }
    public void UpdateFrameRate()
    {
        fpsText.text = currentFps.ToString();
        currentFps = fps[fpsValue];
        if(frameRateSet == false)
        {
            targetFrameRate = currentFps;
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            QualitySettings.vSyncCount = 1;   
        }
        PlayerPrefs.SetInt("framerate", currentFps);
    }
    public void FPSCapped()
    {
        frameRateSet = !frameRateSet;
    }
}
