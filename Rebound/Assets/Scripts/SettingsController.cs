using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] Slider slider;
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
    }

    
    public void ChangePrefToValue()
    {
        PlayerPrefs.SetFloat("sensitivity", slider.value);
    }
}
