using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float MoveSpeed = 5;
    [SerializeField] float SteerSpeed = 100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveSnake();
    }

    void MoveSnake(){
        float steerDirection  = Input.GetAxis("Horizontal");
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);


    }
}
