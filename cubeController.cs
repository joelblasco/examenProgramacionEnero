// INICIO EXAMEN //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cubeController : MonoBehaviour
{
    public float speed = 0.1f;
    public bool moveLeftwards = true;
    public Text objectHitInfo;
    void Start()
    {
        objectHitInfo.gameObject.SetActive(false); //desactiva el texto
    }


    void Update()
    {
        if (moveLeftwards) transform.Translate(Vector3.left * speed); //moverse a  la izquierda
        else transform.Translate(Vector3.right * speed); //moverse a la derecha

        if (transform.position.x < -270) moveLeftwards = false; // si llega al limite izquierdo, cambia de direccion
        if (transform.position.x > 270) moveLeftwards = true; // si llega al limite derecho, cambia de direccion
    }
    public void hit()
    {
        transform.rotation = new Quaternion(180, 0, 0, 0); //rotalo hacia abajo
        objectHitInfo.gameObject.SetActive(true); // activa el texto
    }
}
// FIN EXAMEN //
