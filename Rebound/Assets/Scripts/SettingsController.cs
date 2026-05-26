using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMP_Dropdown colorDrop;
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
    }

    public void ChangeColorToValue()
    {
        PlayerPrefs.SetInt("playerColor", colorDrop.value);
    }
    
    public void ChangePrefToValue()
    {
        PlayerPrefs.SetFloat("sensitivity", slider.value);
    }
}
