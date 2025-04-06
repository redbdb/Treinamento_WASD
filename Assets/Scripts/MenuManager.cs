using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string Jogo;
    [SerializeField] private GameObject Menu;

    void Start(){//iniciar coloca musica em loop e amostra o cursor, estaria invisivel se tivesse reiniciado o jogo no menu de pause
    }

    public void LoadScenes(string cena){//carrega uma cena passada como argumento
        SceneManager.LoadScene(cena);
    }

    public void Sair(){//fecha o jogo
        Application.Quit();
    }

    
}