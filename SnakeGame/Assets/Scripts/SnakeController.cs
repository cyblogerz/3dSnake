using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeController : MonoBehaviour
{


    // Start is called before the first frame update
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float SteerSpeed = 100f;
    [SerializeField] int Gap = 100;

    [SerializeField] float BodySpeed = 5f;
    [SerializeField] GameObject BodyPrefab;

    List<GameObject> BodyParts = new List<GameObject>();
    List<Vector3> PositionsHistory = new List<Vector3>();

    void Start()
    {
        GrowSnake();
        GrowSnake();
        GrowSnake();
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveSnake();
    }

    void MoveSnake(){
        //move forward direction.
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // store head position in array
        PositionsHistory.Insert(0,transform.position);

        //steer to any part
        float steerDirection  = Input.GetAxis("Horizontal");

        //move part by keeping the body part to previous head position.
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index *,0,PositionsHistory.Count-1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);


            index ++;
        }

        //steer
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);


    }

     private void GrowSnake() {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }
}
