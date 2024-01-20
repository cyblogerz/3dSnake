using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    // Start is called before the first frame update

    void PrintInstruction(){
        Debug.Log("Hola! welcome to snake 3d!!");
    }

    void MoveSnake(){
        float xValue = -Input.GetAxis("Vertical")*Time.deltaTime*speed;
        float zValue = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        transform.Translate(xValue,0,zValue);
        

    }
    void Start()
    {
        
        PrintInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        MoveSnake();
        
    }
}
