using UnityEngine.SceneManagement;
using UnityEngine;
using System;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int vidas { get; private set; } = 3;

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    public void ResetLevel(){
        vidas--;

        if(vidas > 0){
            SceneManager.LoadScene("SampleScene");
        }else{
            Cursor.visible = true;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void UP(){
        vidas++;
    }

    public void RestartUP(){
        vidas = 3;
    }
}
