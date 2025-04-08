using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public GameObject SomUI;
    public GameObject MenuUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volumeSlider.value = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Off(){
        SomUI.SetActive(false);
        MenuUI.SetActive(true);
    }

    public void On(){
        SomUI.SetActive(true);
        MenuUI.SetActive(false);
    }

    public void mudarVolume(){
        AudioListener.volume = volumeSlider.value;
    }
}
