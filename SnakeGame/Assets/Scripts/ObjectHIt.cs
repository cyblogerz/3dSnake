using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHit : MonoBehaviour
{


    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            case "Food":
               snakeController.GrowSnake();
               Destroy(other.gameObject);
               break;

            case "Obstacle":
               SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
               Debug.Log("Chathu myre");
               break;

            
            default:
                break;
        }
        if(other.gameObject.CompareTag("Food"))
        {
            
            Debug.Log("ate");
        }
        Debug.Log("Hey man");
    }
    private SnakeController snakeController;

    private void Start() {
        snakeController = GetComponent<SnakeController>();
    }
   
 
}
