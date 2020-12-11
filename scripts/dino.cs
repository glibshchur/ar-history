using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dino : MonoBehaviour
{
    public GameObject[] players;
    public int[] Jumps;
    GameObject character;
    Rigidbody rb;
    public float radius;
    public float speed;
    public float jumpF;
    int max_jump,cur_jump;
 
    void Awake()
    {
        int pos = Random.Range(0,players.Length);
        character = Instantiate(players[pos], 
            new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        character.transform.parent = gameObject.transform;
        max_jump = Jumps[pos];
        cur_jump = max_jump;
    }
     void Start()
    {
        rb = character.GetComponent<Rigidbody>();  
    }
    void FixedUpdate()
    {
        if (character.transform.position.z < -50)
        {
            Destroy(GameObject.FindGameObjectWithTag("game_over"));
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("spawner"));
            GameObject[] obs = GameObject.FindGameObjectsWithTag("obstacle");
            foreach (var a in obs)
            {
                Destroy(a);
            }
        }
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        check();
        if (Input.GetButtonDown("Jump") &&cur_jump!=0)
        {

             rb.AddForce(new Vector3(0, 2, 0)* jumpF, ForceMode.Impulse);
           cur_jump--;
        }
    }
    void check()
    {
        Collider[] hitColliders = Physics.OverlapSphere(character.transform.position, radius);
        foreach (var hitCollider in hitColliders)
            if (hitCollider.gameObject.name == "Ground")
            {
                cur_jump=max_jump;
                print(hitCollider.gameObject.name);
            }
                
    }

}
