using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGame : MonoBehaviour
{

    public GameObject obstacleDynamic;

    void Start()
    {
        
        StartCoroutine("start");

    }

    IEnumerator start() {

        while(true) {
            
            yield return new WaitForSeconds(1f);
            OutputTime();
            yield return new WaitForSeconds(1f);
            
            GameObject[] obstacles =  GameObject.FindGameObjectsWithTag("Obstacle");
            
            foreach(GameObject obstacle in obstacles)
                    Destroy(obstacle);

        }

    }

    private void OutputTime() {

        int randomNumber = Mathf.RoundToInt(Random.Range(1,4));

        for(int i = 1; i<= randomNumber; i++){
            Vector3 position = new Vector3(Random.Range(5.0f,49.0f),Random.Range(14.0f,-14.0f),0);
            Instantiate(obstacleDynamic,position,Quaternion.identity);
        }
        
    }

}
