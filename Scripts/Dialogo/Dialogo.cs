using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialog; // para ativar e desativar a caixinha
    public Image profile;
    public Text speechtxt;
    public Text actorNametxt;

    [Header("Settings")]
    public float typingSpeed;
    public string[] sentences;
    public int index;
    private DiaNPC NPC;
    public bool falando=false;

    private void Start()
    {
        NPC = FindObjectOfType<DiaNPC>();
    }

    public void Speech(Sprite p,string[] txt, string actorname) //metodo para atribuir os elementos do dialogo
    {
        dialog.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNametxt.text = actorname;
        StartCoroutine(TypeSentence());
        falando = true;
    }
    IEnumerator TypeSentence()   //metodo para escrever a frase letra por letra
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechtxt.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentece()
    {

        if(speechtxt.text == sentences[index])
        {

            if(index<sentences.Length-1) //verifica se há mais frases para serem ditas (tamanho do array - 1) -- ainda há textos
            {
                index++;
                speechtxt.text = "";
                StartCoroutine(TypeSentence());
            }

            else //quando acaba os textos   
            {
                speechtxt.text = "";
                index = 0;
                dialog.SetActive(false); //desliga o dialogo
                //falando = false;
            }
        }   
    }
}
