using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Circle;
    Vector3 pos;
    float add;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomCircle", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
       add= (add+10 )* Time.deltaTime ;
       pos = new Vector3(0, add * Time.deltaTime, 0);
    }

    void SpawnRandomCircle()
    {
       
        Instantiate(Circle, pos, Circle.transform.rotation);
    }
}
