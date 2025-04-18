using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class Mastro : MonoBehaviour
{
    public Transform bandeira;
    public Transform fundo;
    public Transform castelo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            StartCoroutine(Mover(bandeira, fundo.position));
            StartCoroutine(LevelClear(other.transform));
        }
    }

    private IEnumerator LevelClear(Transform mario)//ajustar velocidade e 
    {
        mario.GetComponent<Mario>().enabled = false;

        yield return Mover(mario, fundo.position);
        yield return Mover(mario, mario.position + Vector3.right);
        yield return Mover(mario, mario.position + Vector3.right + Vector3.down);
        yield return Mover(mario, castelo.position);

        mario.gameObject.SetActive(false);
        Invoke(nameof(loadGameOver), 0.5f);//colocar delay ate acabar a musica?
    }

    private IEnumerator Mover(Transform objeto, Vector3 pos)
    {
        while(Vector3.Distance(objeto.position, pos) > 0.125f){
            objeto.position = Vector3.MoveTowards(objeto.position, pos, 6f * Time.deltaTime);
            yield return null;
        }

        objeto.position = pos;
    }

    private void loadGameOver(){
        SceneManager.LoadScene("GameOver");
    }
}
