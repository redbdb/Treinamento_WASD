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
    public TextMeshProUGUI txtmoedas;

    public AudioSource somPause;
    public AudioSource Musica;

    public int pontos = 0;
    public int vidas;
    public int moedas = 0;

    public bool endgame;

    void Update()
    {
        txtvidas.text = "x" + gameManager.GetComponent<GameManager>().vidas.ToString();

        if(Input.GetKeyDown(KeyCode.Escape) && !pause && !endgame){
            Time.timeScale = 0;
            Musica.Pause();
            somPause.Play();
            pauseUI.SetActive(true);
            pause = true;
        }else if(Input.GetKeyDown(KeyCode.Escape) && pause && !endgame){
            Resume();
        }
    }

    void Start(){
        gameManager = GameObject.Find("GameManager");

        pauseUI.SetActive(false);
        txtvidas.text = "x" + gameManager.GetComponent<GameManager>().vidas.ToString();
        txtmoedas.text = "x00";
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
        Musica.Play();
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

    public void AddMoeda(){
        moedas++;
        txtmoedas.text = "x" + moedas.ToString().PadLeft(2, '0');
    }
}