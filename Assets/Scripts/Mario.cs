using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Mario : MonoBehaviour
{
    public float velocidade;
    public Rigidbody2D corpo;

    public Collider2D colisorPequeno;
    public Collider2D colisorGrande;
    public GameObject mariozinho;
    public GameObject mariozao;

    public float ForcaPulo;
    public bool isGrounded;
    public bool correndo;
    public bool sentido;
    public bool crescido;
    public bool starp = false;//{ get; private set; }

    public AudioSource somPuloPequeno;
    public AudioSource somPuloGrande;
    public AudioSource somMorte;

    public MenuManager menu;
    public GameManager gameManager;

    private new Camera camera;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        camera = Camera.main;
    }

    void Update()
    {
        isGrounded = corpo.Raycast(Vector2.down);

        if(Mathf.Abs(corpo.linearVelocity.x) > 0.25f)
            correndo = true;
        else
            correndo = false;

        Mover();
        Pular();
    }

    void Mover()
    {
        Vector2 bordaE = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 bordaD = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        corpo.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * velocidade, corpo.linearVelocity.y);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, bordaE.x + 0.4f, bordaD.x - 0.4f);
        transform.position = pos;
    }

    public void Pular()
    {
        if(Input.GetButtonDown("Jump") && isGrounded){//verificar se esta grande ou nao pra tocar o som
            if(crescido)
                somPuloGrande.Play();
            else
                somPuloPequeno.Play();
            corpo.AddForce(new Vector2(0f, ForcaPulo), ForceMode2D.Impulse);
        }       
    }

    public void TakeHit()
    {//colocar invencibilidade
        if(!starp){
            if(crescido){
                crescido = false;
                colisorPequeno.enabled = true;
                colisorGrande.enabled = false;
                mariozinho.SetActive(true);
                mariozao.SetActive(false);
            } else{
                Dies();
            }
        } 
    }

    public void Grow(){
        if(crescido)
            return;
        else{
            sentido = true;
            colisorPequeno.enabled = false;
            colisorGrande.enabled = true;
            mariozao.SetActive(true);
            mariozinho.SetActive(false);
            crescido = true;
        }
    }

    public void CogumeloUP(){
        gameManager.UP();
    }

    public void Starpower(){
        StartCoroutine(StarpowerAnimation());
    }

    public IEnumerator StarpowerAnimation(){
        starp = true;

        float feito = 0f;
        float duracao = 10f;

        while(feito < duracao){
            float t = feito/duracao;

            
            feito += Time.deltaTime;

            if(Time.frameCount % 4 == 0){
                mariozinho.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                mariozao.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
            }

            yield return null;
        }

        mariozinho.GetComponent<SpriteRenderer>().color = Color.white;
        mariozao.GetComponent<SpriteRenderer>().color = Color.white;
        starp = false;
    }

    public void Dies(){
        menu.Musica.Pause();
        somMorte.Play();
        gameManager.ResetLevel();
        //colocar aqui reação da morte
    }
}
