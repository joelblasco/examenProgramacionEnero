using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienController : MonoBehaviour
{
    public GameObject bullet;
    public alienManager manager;
    public Transform shotPoint;
    public int speed = 10;
    public float tic = 0.1f;
    int posX, posY;
    public int index;
    public bool move;
    
    // Start is called before the first frame update
    void Start()
    {
        posX = (int)transform.position.x;
        posY = (int)transform.position.y;
    }
    public void initMovement()
    {
        move = true;

        // INICIO EXAMEN //
        move = false; // el codigo para moverse ya esta hecho por lo que solo tengo que evitar que move sea true.
        // FIN EXAMEN //

        StartCoroutine(perform());
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(posX, posY, 0);
        transform.SetPositionAndRotation(v, Quaternion.identity);
    }
    public void goDown()
    {
        posY -= 5;
        speed *= -1;
    }
    IEnumerator perform()
    {
        if (move)
        {
            posX += speed;

            float s = Random.Range(0, 100);
            if (s > 97) //shoot if % more than 97
            {
                GameObject b = Instantiate(bullet, shotPoint);
                b.transform.parent = null;
            }
        }
        yield return new WaitForSeconds(tic);
        StartCoroutine(perform());
    }
    public void kill()
    {
        manager.killedAlien(index);
        print("Killed:" + index); 
    }
}
