using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool pausado = false;
    public GameObject pauseUI;

    public AudioSource somPause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseUI.SetActive(false);
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
}
