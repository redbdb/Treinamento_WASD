using System.Collections;
using UnityEngine;

public class BlocoItem : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate(){
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        CircleCollider2D hitbox = GetComponent<CircleCollider2D>();
        BoxCollider2D trigger = GetComponent<BoxCollider2D>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        rigidbody.isKinematic = true;
        trigger.enabled = false;
        hitbox.enabled = false;
        spriteRenderer.enabled = false;

        yield return new WaitForSeconds(0.25f);

        spriteRenderer.enabled = true;

        float feito = 0f;
        float duracao = 0.5f;

        Vector3 de = transform.position;
        Vector3 para = transform.position + Vector3.up;

        while(feito < duracao){
            float t = feito/duracao;

            transform.position = Vector3.Lerp(de, para, t);
            feito += Time.deltaTime;

            yield return null;
        }

        rigidbody.isKinematic = false;
        hitbox.enabled = true;
        trigger.enabled = true;
    }
}
