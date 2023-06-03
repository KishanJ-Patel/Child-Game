using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [Header("UI Canvasses")]
    [SerializeField]
    private GameObject Play_UI_Canvas;
    [SerializeField]
    private GameObject Settings_and_Pause_UI_Canvas;
    [SerializeField]
    private GameObject Credits_UI_Canvas;
    [SerializeField]
    private GameObject Share_UI_Canvas;

    [Header("Volume Sliders")]
    [SerializeField]
    private GameObject Music_Volume_Slider;
    [SerializeField]
    private GameObject Sound_Volume_Slider;

    [Header("Audio Mixers")]
    [SerializeField]
    private AudioMixer Music_Audio_Mixer;
    [SerializeField]
    private AudioMixer Sound_Audio_Mixer;

    [Header("Background_Fade_and_Touch_Blocker_Panel")]
    [SerializeField]
    private GameObject Background_Fade_and_Touch_Blocker_Panel;

    private float Music_Volume_Slider_Value;
    private float Sound_Volume_Slider_Value;

    void Start()
    {
        if(!PlayerPrefs.HasKey("Music_Volume_Slider_Value"))
        {
            PlayerPrefs.SetFloat("Music_Volume_Slider_Value", 1f);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("Sound_Volume_Slider_Value"))
        {
            PlayerPrefs.SetFloat("Sound_Volume_Slider_Value", 1f);
            PlayerPrefs.Save();
        }

        Music_Volume_Slider_Value = PlayerPrefs.GetFloat("Music_Volume_Slider_Value");

        Sound_Volume_Slider_Value = PlayerPrefs.GetFloat("Sound_Volume_Slider_Value");

        Music_Volume_Slider.GetComponent<Slider>().value = Music_Volume_Slider_Value;

        Sound_Volume_Slider.GetComponent<Slider>().value = Sound_Volume_Slider_Value;

        Set_Music_Volume(Music_Volume_Slider_Value);

        Set_Sound_Volume(Sound_Volume_Slider_Value);
    }

    void Update()
    {
        
    }

    public void Open_Play_UI_Canvas()
    {
        Background_Fade_and_Touch_Blocker_Panel.SetActive(true);
        Play_UI_Canvas.SetActive(true);
    }

    public void Close_Play_UI_Canvas()
    {
        Background_Fade_and_Touch_Blocker_Panel.SetActive(false);
        Play_UI_Canvas.SetActive(false);
    }

    public void Open_Settings_UI_Canvas()
    {
        Background_Fade_and_Touch_Blocker_Panel.SetActive(true);
        Settings_and_Pause_UI_Canvas.SetActive(true);
    }

    public void Close_Settings_UI_Canvas()
    {
        Background_Fade_and_Touch_Blocker_Panel.SetActive(false);
        Settings_and_Pause_UI_Canvas.SetActive(false);
    }

    public void Open_Credits_UI_Canvas()
    {
        Background_Fade_and_Touch_Blocker_Panel.SetActive(true);
        Credits_UI_Canvas.SetActive(true);
    }

    public void Close_Credits_UI_Canvas()
    {
        Background_Fade_and_Touch_Blocker_Panel.SetActive(false);
        Credits_UI_Canvas.SetActive(false);
    }

    public void Open_Share_UI_Canvas()
    {
        Background_Fade_and_Touch_Blocker_Panel.SetActive(true);
        Share_UI_Canvas.SetActive(true);
    }

    public void Close_Share_UI_Canvas()
    {
        Background_Fade_and_Touch_Blocker_Panel.SetActive(false);
        Share_UI_Canvas.SetActive(false);
    }

    public void Set_Music_Volume(float Music_Volume_Slider_Value)
    {
        Music_Audio_Mixer.SetFloat("Music_Volume_Value", Mathf.Log10(Music_Volume_Slider_Value) * 20f);

        PlayerPrefs.SetFloat("Music_Volume_Slider_Value", Music_Volume_Slider_Value);
        PlayerPrefs.Save();
    }

    public void Set_Sound_Volume(float Sound_Volume_Slider_Value)
    {
        Sound_Audio_Mixer.SetFloat("Sound_Volume_Value", Mathf.Log10(Sound_Volume_Slider_Value) * 20f);

        PlayerPrefs.SetFloat("Sound_Volume_Slider_Value", Sound_Volume_Slider_Value);
        PlayerPrefs.Save();
    }
}
