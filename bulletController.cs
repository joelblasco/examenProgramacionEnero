using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    float speed = 10;
    public playerMovement p;
    public bool shotByPlayer;
    private void Start()
    {
        if (!shotByPlayer) speed = -5;
    }
    private void OnBecameInvisible()
    {
        //bye
        if (p != null) p.bulletActive = false;
        Destroy(this.gameObject);
    }
    private void LateUpdate()
    {

        Vector3 pos = new Vector3(transform.position.x, transform.position.y+speed, 0);
        transform.SetPositionAndRotation(pos, Quaternion.identity);
        //Debug.Break();
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.transform.tag == "Block")
        {
            Destroy(c.transform.gameObject);
            Destroy(this.gameObject);
            if(p!=null)p.bulletActive = false;
            print("Destroyed block");
        }
        else if (c.transform.tag == "Enemy" &&shotByPlayer)
        {
            c.transform.GetComponent<alienController>().kill();
            if (p != null) p.bulletActive = false;
            Destroy(this.gameObject);
        }
        else if (c.transform.tag == "Player" && !shotByPlayer)
        {
            c.transform.GetComponent<playerMovement>().hitByBullet();
        }
        // INICIO EXAMEN 
        else if (c.transform.tag == "CuboExamen") //añado el nuevo objeto como posible obstaculo
        {
            if (p != null) p.bulletActive = false; // reactivo el disparo
            Destroy(this.gameObject); //destruyo la bala
            c.transform.GetComponent<cubeController>().hit(); //le digo al objeto que le he pegado para que active su funcion
        }
        //FIN EXAMEN 
    }
}
