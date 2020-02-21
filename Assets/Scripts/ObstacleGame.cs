using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGame : MonoBehaviour
{

    public GameObject obstacleDynamic;
    private GameObject obstacleDynamicCreated;

    void Start()
    {
        StartCoroutine("start");
    }

    IEnumerator start() {

        while(true) {
            
            yield return new WaitForSeconds(3f);
            OutputTime();
            yield return new WaitForSeconds(3f);
            Destroy(obstacleDynamicCreated);

        }

    }

    private void OutputTime() {

        Vector3 position = new Vector3(Random.Range(5.0f,49.0f),Random.Range(14.0f,-14.0f),0);
        obstacleDynamicCreated = Instantiate(obstacleDynamic,position,Quaternion.identity);
        
    }

}
