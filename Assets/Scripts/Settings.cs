using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;



public class Settings : MonoBehaviour
{
    //object references
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Dropdown textureDropdown;
    public Dropdown aaDropdown;
    public Slider volumeSlider;
    float currentVolume;
    Resolution[] resolutions; 

    //audio
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume = volume;
    }

    //fullscreen
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    //resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //texture quality
    public void SetTextureQuality(int textureIndex)
    {
        QualitySettings.masterTextureLimit = textureIndex;
        qualityDropdown.value = 6;
    }

    //anti aliasing
    public void SetAntiAliasing(int aaIndex)
    {
        QualitySettings.antiAliasing = aaIndex;
        qualityDropdown.value = 6;
    }

    //qualityPreset
    public void SetQuality(int qualityIndex)
    {
        //check if user has selected the "custom" option
        if (qualityIndex !=6) QualitySettings.SetQualityLevel(qualityIndex);
            switch (qualityIndex)
            {
                case 0: //quality level - very low
                    textureDropdown.value = 3;
                    aaDropdown.value = 0;
                    break;
                case 1: //quality level - low
                    textureDropdown.value = 2;
                    aaDropdown.value = 0;
                    break;
                case 2: //quality level - medium
                    textureDropdown.value = 1;
                    aaDropdown.value = 0;
                    break;
                case 3: //quality level - high
                    textureDropdown.value = 0;
                    aaDropdown.value = 0;
                    break;
                case 4: //quality level - very high
                    textureDropdown.value = 0;
                    aaDropdown.value = 1;
                    break;
                case 5: //quality level - ultra
                    textureDropdown.value = 0;
                    aaDropdown.value = 2;
                    break;
            }
            qualityDropdown.value = qualityIndex;
    }

    //save settings
    public void SaveSettings()
    {
        //store setting values as int
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("TextureQualityPreference", textureDropdown.value);
        PlayerPrefs.SetInt("AntiAliasingPreference", aaDropdown.value);
        //fullscreen convert boolean to int
        PlayerPrefs.SetInt("FullscreenPreference", Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference", currentVolume);
    }

    //load settings
    public void LoadSettings(int currentResolutionIndex)
    {
        //quality preset
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        //if no setting defined, use default value
        else 
            qualityDropdown.value = 3;
        //resolution
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else 
            resolutionDropdown.value = currentResolutionIndex;
        //texture quality
        if (PlayerPrefs.HasKey("TextureQualityPreference"))
            textureDropdown.value = PlayerPrefs.GetInt("TextureQualityPreference");
        else
            textureDropdown.value = 0;
        //Anti Aliasing
        if (PlayerPrefs.HasKey("AntiAliasingPreference"))
            aaDropdown.value = PlayerPrefs.GetInt("AntiAliasingPreference");
        else
            aaDropdown.value = 1;
        //fullscreen
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
        //Volume
        if (PlayerPrefs.HasKey("VolumePreference"))
            volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
        else
            volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
    }



    // Start is called before the first frame update
    void Start()
    {
        //auto creating list of resolutions
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        //search through resolutions
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = 1;
        }

        //update resolution list in menu
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
