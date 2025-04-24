using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public AudioSource Musica;

    private bool pas = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !pas){
            Musica.Pause();
            pas = true;
        }else if(Input.GetKeyDown(KeyCode.Escape) && pas){
            Musica.Play(0);
            pas = false;
        }
    }

    void Start(){//iniciar coloca musica em loop e amostra o cursor, estaria invisivel se tivesse reiniciado o jogo no menu de pause
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

    
}