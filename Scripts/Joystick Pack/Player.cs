using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public FixedJoystick joy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    void Mover()
    {
        // Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        Vector3 movement = new Vector3(joy.Horizontal, joy.Vertical, 0f);  //controles do fixed joystick
        transform.position += movement*Time.deltaTime*speed;  //transforma a posição do objeto do script como um vetor v*dt
    } 
}
