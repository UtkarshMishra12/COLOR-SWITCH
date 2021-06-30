using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Circle;
    public GameObject colorChanger;
    private PlayerController playerController;
    int i = 11, y=7;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine("SpawnCircle");
        StartCoroutine("SpawnColorChanger");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnCircle()
    {
        yield return new WaitForSeconds(1.0f);
        Vector3 pos = new Vector3(0, 1*i, 0);
        Instantiate(Circle, pos, Circle.transform.rotation);
        StartCoroutine("SpawnCircle");
        i += 8;
        if(playerController.transform.position.y > i + 5)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnColorChanger()
    {
        yield return new WaitForSeconds(1);
        Vector3 pos = new Vector3(0, y,0);
        Instantiate(colorChanger, pos, colorChanger.transform.rotation);
        StartCoroutine("SpawnColorChanger");
        y = y+8;
    }


}
