using System.Collections;
using UnityEngine;

public class Blocos : MonoBehaviour
{   
    public GameObject item;
    public AudioSource somQuebra;

    public Sprite blocoVazio; 
    public int Maxhits = -1;
    public bool brick;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Maxhits == 0){
            return;
        } 

        if(collision.gameObject.CompareTag("Player") && collision.transform.DotTest(transform, Vector2.up))
        {
            if(brick && collision.gameObject.GetComponent<Mario>().crescido){
                StartCoroutine(breakBrick());
            }
            else
                Hit();
        }
    }

    private IEnumerator Animacao(Vector3 de, Vector3 para)
    {
        Transform transform = GetComponent<Transform>();

        float feito = 0f;
        float duracao = 0.125f;

        while(feito < duracao){
            float t = feito/duracao;

            transform.position = Vector3.Lerp(de, para, t);
            feito += Time.deltaTime;

            yield return null;
        }

        transform.position = para;
    }

    private void Hit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        Transform transform = GetComponent<Transform>();
        Vector3 posI = transform.position;

        if (item != null) {
            Instantiate(item, transform.position, Quaternion.identity);
        }

        StartCoroutine(Animacao(posI,  transform.position + Vector3.up * 0.5f));
        StartCoroutine(Animacao(transform.position + Vector3.up * 0.5f, posI));

        Maxhits--;
        if(Maxhits == 0){
            spriteRenderer.sprite = blocoVazio;
        }
    }

    private IEnumerator breakBrick(){

        somQuebra.Play();

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        while (somQuebra.isPlaying)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
