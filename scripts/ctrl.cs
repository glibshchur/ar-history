using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrl : MonoBehaviour
{
    public GameObject dino;
    public GameObject spawner;
    public GameObject go;
    public Button button;
    public Button end;
    public Text text;
    public void Start_game()
    {

        Destroy(GameObject.FindGameObjectWithTag("player"));
        Destroy(GameObject.FindGameObjectWithTag("spawner"));
        Destroy(GameObject.FindGameObjectWithTag("game_over"));
        Instantiate(dino , dino.transform.position,Quaternion.identity);
        Instantiate(spawner, spawner.transform.position, Quaternion.identity);
        Instantiate(go, go.transform.position, Quaternion.identity);
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("player") != null)
        {
            button.interactable = false;
            end.interactable = true;
        }
        else
        {
            end.interactable = false;
            button.interactable = true;
        }
    }
    public void End_game()
    {
        Destroy(GameObject.FindGameObjectWithTag("player"));
        Destroy(GameObject.FindGameObjectWithTag("spawner"));
        Destroy(GameObject.FindGameObjectWithTag("game_over"));
        GameObject[] obs = GameObject.FindGameObjectsWithTag("obstacle");
        foreach (var a in obs)
        {
            Destroy(a);
        }
    }
}
