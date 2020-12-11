using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_obstacle : MonoBehaviour
{
  public  float speed;
    public int end;
    void Update()
    {
        transform.position -= new Vector3(0,0,speed*Time.deltaTime);
        if (transform.position.z >= end)
            Destroy(gameObject);
    }
    public void change(float spd)
    {
        speed = spd;
    }
}
