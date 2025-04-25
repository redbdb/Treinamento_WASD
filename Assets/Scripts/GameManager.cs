using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    private bool pausado = false;
    public GameObject pauseUI;

    public TextMeshProUGUI mainText;
    public int pontos = 0;
    public int vidas = 3;

    public AudioSource somPause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseUI.SetActive(false);
        Pontuar(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))//ao pressionar a tecla esc
        {
            if(pausado){
                Resume();
            }
            else{
                somPause.Play();
                Time.timeScale = 0;
                pausado = true;
                pauseUI.SetActive(true);
            };
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausado = false;
        pauseUI.SetActive(false);
    }

    public void Pontuar(int quant){
        pontos += quant;
        mainText.text = pontos.ToString().PadLeft(6, '0');;
    }

    public void ResetLevel(){
        vidas--;

        if(vidas > 0){
            SceneManager.LoadScene("SampleScene");
        }else{
            SceneManager.LoadScene("GameOver");
        }
    }
}
