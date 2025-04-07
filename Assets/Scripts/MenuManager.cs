using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    void Start(){//iniciar coloca musica em loop e amostra o cursor, estaria invisivel se tivesse reiniciado o jogo no menu de pause
    }

    private void OnTriggerEnter2D()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadScenes(string cena){//carrega uma cena passada como argumento
        SceneManager.LoadScene(cena);
        Time.timeScale = 1;
    }

    public void Sair(){//fecha o jogo
        Application.Quit();
    }

    
}