using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distancia : MonoBehaviour
{
    public GameObject drone;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = drone.transform.position + new Vector3(40,5,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = drone.transform.position + new Vector3(40,5,0);
    }
}
