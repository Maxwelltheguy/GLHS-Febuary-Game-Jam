using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using Mirror;


public class SettingsController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMP_Dropdown colorDrop;
    [SerializeField] TMP_Dropdown sceneDrop;
    [SerializeField] string[] levelScenes;
    [SerializeField] Toggle VRToggle;
    [SerializeField] NetworkManager networkManager;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("sensitivity") == null)
        {
            PlayerPrefs.SetFloat("sensitivity", 2f);
        }
        else
        {
            slider.value = PlayerPrefs.GetFloat("sensitivity", 2f);
        }
        colorDrop.value = PlayerPrefs.GetInt("playerColor", 0);
        bool isOn;
        if (PlayerPrefs.GetInt("VRMode", 0) == 0)
        {
            isOn = false;
        }
        else
        {
            isOn = true;
        }

            VRToggle.isOn = isOn;
    }

    public void ChangeColorToValue()
    {
        PlayerPrefs.SetInt("playerColor", colorDrop.value);
    }
    
    public void ChangeMapToValue()
    {
        networkManager.onlineScene = levelScenes[sceneDrop.value];
    }

    public void ChangePrefToValue()
    {
        PlayerPrefs.SetFloat("sensitivity", slider.value);
    }

    public void SetVRMode()
    {
        if (VRToggle.isOn)
        {
            PlayerPrefs.SetInt("VRMode", 1);
        }
        else
        {
            PlayerPrefs.SetInt("VRMode", 0);
        }
    }

    public void ChangeSceneToValue()
    {
        
    }
}
