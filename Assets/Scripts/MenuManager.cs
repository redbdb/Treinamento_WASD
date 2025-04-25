using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System;

public class MenuManager : MonoBehaviour
{
    public GameObject gameManager;
    private bool pause = false;
    public GameObject pauseUI;

    public TextMeshProUGUI txtpontos;
    public TextMeshProUGUI txtvidas;

    public AudioSource somPause;
    public AudioSource Musica;

    public int pontos = 0;
    public int vidas;//tem que pega do gamemanager

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !pause){
            Time.timeScale = 0;
            Musica.Pause();
            somPause.Play();
            pauseUI.SetActive(true);
            pause = true;
        }else if(Input.GetKeyDown(KeyCode.Escape) && pause){
            Resume();
            Musica.Play();
        }
    }

    void Start(){//iniciar coloca musica em loop e amostra o cursor, estaria invisivel se tivesse reiniciado o jogo no menu de pause
        gameManager = GameObject.Find("GameManager");

        pauseUI.SetActive(false);
        txtvidas.text = gameManager.GetComponent<GameManager>().vidas.ToString();
        Pontuar(0);

        Musica.loop = true;
        Musica.Play();
    }

    public void LoadScenes(string cena){//carrega uma cena passada como argumento
        SceneManager.LoadScene(cena);
        Time.timeScale = 1;
    }

    public void Sair(){//fecha o jogo
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pause = false;
        pauseUI.SetActive(false);
    }

    public void Pontuar(int quant){
        pontos += quant;
        txtpontos.text = pontos.ToString().PadLeft(6, '0');
    }

    public void UP1(){
        vidas++;
    }
}