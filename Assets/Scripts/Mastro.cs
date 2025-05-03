using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using TMPro;

public class Mastro : MonoBehaviour
{
    public MenuManager menuManager;
    public GameObject score;

    public AudioSource somDescida;
    public AudioSource somFim;

    public Transform bandeira;
    public Transform fundo;
    public Transform castelo;

    private void OnTriggerEnter2D(Collider2D other)//100 ate 5000, -5 ate 5
    {
        if(other.gameObject.CompareTag("Player")){
            float pontos = 100f + 490f * (other.gameObject.GetComponent<Transform>().position.y + 5f);
            menuManager.endgame = true;
            StartCoroutine(RisingScore((int)pontos));
            menuManager.Pontuar((int)pontos);
            StartCoroutine(Mover(bandeira, fundo.position, 7f));
            somDescida.Play();
            StartCoroutine(LevelClear(other.transform));
        }
    }

    private IEnumerator LevelClear(Transform mario)
    {
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

        Cursor.visible = true;
        SceneManager.LoadScene("GameOver");
    }

    public IEnumerator RisingScore(int valor){

        GameObject obj = Instantiate(score, transform.position, Quaternion.identity);
        obj.GetComponent<TextMeshPro>().text = valor.ToString();

        float feito = 0f;
        float duracao = 1f;

        while(feito < duracao){
            Vector3 pos = obj.GetComponent<RectTransform>().position;
            pos.y += 0.01f;
            obj.GetComponent<RectTransform>().position = pos;

            float t = feito/duracao;

            feito += Time.deltaTime;

            yield return null;
        }

        Destroy(obj);
    }
}
