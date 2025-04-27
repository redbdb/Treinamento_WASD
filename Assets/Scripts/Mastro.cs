using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class Mastro : MonoBehaviour
{
    public MenuManager menuManager;

    public AudioSource somDescida;
    public AudioSource somFim;

    public Transform bandeira;
    public Transform fundo;
    public Transform castelo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            menuManager.Pontuar(2500);
            StartCoroutine(Mover(bandeira, fundo.position, 7f));
            somDescida.Play();
            StartCoroutine(LevelClear(other.transform));
        }
    }

    private IEnumerator LevelClear(Transform mario)
    {
        mario.GetComponent<Mario>().enabled = false;
        mario.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);

        yield return Mover(mario, fundo.position, 2f);
        StartCoroutine(WaitEnd(somFim));
        yield return Mover(mario, mario.position + Vector3.right, 2f);
        yield return Mover(mario, mario.position + Vector3.right + Vector3.down, 2f);
        yield return Mover(mario, castelo.position, 2f);

        mario.gameObject.SetActive(false);
    }

    private IEnumerator Mover(Transform objeto, Vector3 pos, float vel)//mais devagar? 4f base, devagar pro mario e mais ainda pra bandeira
    {

        while(Vector3.Distance(objeto.position, pos) > 0.125f){
            objeto.position = Vector3.MoveTowards(objeto.position, pos, vel * Time.deltaTime);
            yield return null;
        }

        objeto.position = pos;
    }

    public IEnumerator WaitEnd(AudioSource musga){

        menuManager.Musica.Pause();
        musga.Play();

        while (musga.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadScene("GameOver");
    }
}
