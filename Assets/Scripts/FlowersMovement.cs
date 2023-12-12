using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersMovement : MonoBehaviour
{

    public float speed = 10;
    public float rotSpeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime,0);

        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0, Space.World);
    }
}
