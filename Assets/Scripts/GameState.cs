using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    
    public static GameState instance;
    public int leftPoints;
    public int rightPoints;

    private void Awake() {
        if(instance == null){
            instance = this;
            leftPoints = 5;
            rightPoints = 5;
            DontDestroyOnLoad(gameObject);
        } else if(instance != this){
            Destroy(gameObject);
        }
    }
}
