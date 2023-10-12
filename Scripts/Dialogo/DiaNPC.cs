using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaNPC : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string[] speechTxt2;
    public string actorName;


    public LayerMask playerLayer;
    public float radius;
    bool onRadius;
   



    private Dialogo dc;
    // Start is called before the first frame update
    private void Start()
    {
        dc=FindObjectOfType<Dialogo>();  //pega o script do dialogo (classe)
    }
    private void Update()
    {

        if (Input.GetButtonDown("Submit") && onRadius && dc.falando == false) //chama o dialogo quando o persongem pode interagir com o NPC (esta proximo)
        {
            dc.Speech(profile, speechTxt, actorName);

        }
    }

    private void FixedUpdate()
    {
        Interact();

        //if (Input.GetButtonDown("Submit") && onRadius && dc.falando == false)
        //{
        //    dc.Speech(profile, speechTxt, actorName);
        //}

        if(dc.dialog.activeSelf==false) //verifica se o canvas esta desativo (ou seja parou de falar) // coloquei no fixed para ter DELAY n
        {
            dc.falando = false;
        }
    }
    public void Interact()   //Quando o personagem esta perto do NPC, ele fica ativo 
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position,radius,playerLayer);
        if(hit != null)
        {
            onRadius = true;
        }
        else
        {
            onRadius = false;
        }



    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
