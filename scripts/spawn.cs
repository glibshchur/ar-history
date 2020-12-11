using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public move_obstacle[] low;
    public move_obstacle[] high;
    public float cd;
    public float spd;
    bool can_spawn=true;
    void FixedUpdate()
    {
        if (can_spawn)
        {
            int a = Random.Range(0,2);
            if (a % 2 == 0)
            {
                int b = Random.Range(0,low.Length);
                low[b].GetComponent<move_obstacle>().change(spd); 
                Instantiate(low[b], low[b].transform.position,Quaternion.identity);
            }
            else
            {
                int b = Random.Range(0, high.Length);
                 high[b].GetComponent<move_obstacle>().change(spd);
                Instantiate(high[b], high[b].transform.position, Quaternion.identity);
            }
            can_spawn = false;
            StartCoroutine(cool());
        }
    }
    IEnumerator cool()
    {
        yield return new WaitForSeconds(cd);
        can_spawn = true;
    }
}
