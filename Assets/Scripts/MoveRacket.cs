using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{

    public float speed = 30;
    public string axis = "Vertical";

    void Start(){
        StartCoroutine("start");
    }

    void FixedUpdate()
    {
        float y = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,y) * speed;
    }

    IEnumerator start() {

        while(true) {

            yield return new WaitForSeconds(3f);
            OutputTime();

        }

    }

    private void OutputTime() {
        
        if(transform.localScale.y > 1)
            transform.localScale = transform.localScale - new Vector3(0f,0.1f);

    }

}
