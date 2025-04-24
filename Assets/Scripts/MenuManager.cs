using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public AudioSource Musica;

    private bool pause = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !pause){
            Musica.Pause();
            pause = true;
        }else if(Input.GetKeyDown(KeyCode.Escape) && pause){
            Musica.Play();
            pause = false;
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