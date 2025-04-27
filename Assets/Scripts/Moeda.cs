using System.Collections;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    public AudioSource som;

    void Start()
    {
        som.Play();
        GameObject.Find("MenuManager").GetComponent<MenuManager>().AddMoeda();

        StartCoroutine(Animate());
    }

    private IEnumerator Animate(){
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.enabled = false;

        yield return new WaitForSeconds(0.0625f);

        spriteRenderer.enabled = true;

        float feito = 0f;
        float duracao = 0.1f;

        Vector3 de = transform.position;
        Vector3 para = transform.position + Vector3.up * 1.5f;

        while(feito < duracao){
            float t = feito/duracao;

            transform.position = Vector3.Lerp(de, para, t);
            feito += Time.deltaTime;

            yield return null;
        }

        spriteRenderer.enabled = false;

        while (som.isPlaying)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
