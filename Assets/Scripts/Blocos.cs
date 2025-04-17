using System.Collections;
using UnityEngine;

public class Blocos : MonoBehaviour
{   
    public Sprite blocoVazio; 
    public int Maxhits = -1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.transform.DotTest(transform, Vector2.up))//se for tijolo e o mario tiver grande some
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
        Transform transform = GetComponent<Transform>();
        Vector3 posI = transform.position;

        StartCoroutine(Animacao(posI,  transform.position + Vector3.up * 0.5f));
        StartCoroutine(Animacao(transform.position + Vector3.up * 0.5f, posI));

        Maxhits--;
        if(Maxhits == 0){
            spriteRenderer.sprite = blocoVazio;
        }
    }
}
