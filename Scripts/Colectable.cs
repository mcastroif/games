using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : MonoBehaviour
{
    private SpriteRenderer sr; //atribui a classe que é o elemento da unity para as variaveis (começo da chamada)
    private CircleCollider2D cc;
    public GameObject coletado; //variavel associada a fazer o efeito de colect aparecer (n importa o nome, por ser public seta visualmente)
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();  //atribui o componente a variavel
        cc = GetComponent<CircleCollider2D>();
    }

    //Metodo para fazer o item reconhecer a colisão no caso em que ele é do tipo TRIGGER (atravessavel) (parecido com o collisionEnter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") //Verifica se o objeto(que ta com o script) colidiu com objeto de tag Player
        {
            sr.enabled = false; //desativa o sprite da cena
            cc.enabled = false; //desativa o colider do objeto
            coletado.SetActive(true);
            Destroy(gameObject,0.3f); //g minusculo para pegar o proprio objeto que esta com o script, e o tempo para acontecer a animação
        }
    }
}
