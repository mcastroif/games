using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D rig;  //variavel de data type (rigidbody2d) da unity
    private Animator anim; //pega as componentes do animator da unity (no caso queremos as booleanas de anima��o)
    
    public float JumpForce; //Variavel para o Jump (similar ao speed)

    public bool isJumping; //booleana para pulo

    public bool doubleJump; //booleana para pulo duplo



    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); //recebe a componente rigidbody2d da Unity, e manipula ela em codigo
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.position += movement * Time.deltaTime * Speed; /// A multiplica��o � para poder controlar V
        if (Input.GetAxis("Horizontal")>0) // cada condi��o do movimento, feita desse jeito para podermos espelhar a anima��o
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f); //Metodo para rotacionar no transform (neste caso para virar a direita
        }
        if(Input.GetAxis("Horizontal")<0)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f); //Metodo para rodar (neste caso para esquerda +180graus)
        }
        if(Input.GetAxis("Horizontal")==0)
        {
            anim.SetBool("walk", false);
        }
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump")) //Aperta o bot�o e o boneco n�o esta pulando
        {
            if(!isJumping) //se o personagem esta no ch�o -> isJumping=false
            {
                //Recebe a variavel jumpforce em y (controlada visualmente) e diz q essa for�a deve ser do tipo impulso
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true; //se esta pulando pode dar mais um pulo
                anim.SetBool("jump", true);
            }
            else
            {
                if(doubleJump) //Se esta pulando, pode dar mais um pulo
                {
                    rig.AddForce(new Vector2(0f, JumpForce*1.2f), ForceMode2D.Impulse);
                    doubleJump=false;
                }
            }

            //Recebe a variavel jumpforce em y (controlada visualmente) e diz q essa for�a deve ser do tipo impulso 
            
        }
    }
    void OnCollisionEnter2D(Collision2D collision)   //verifica se o personagem esta no ch�o
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = false; // O personagem n�o esta pulando, esta no ch�o
            anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)  //verifica se o personagem esta FORA do ch�o
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping=true;
            anim.SetBool("jump", true);
        }
           
    }
}
