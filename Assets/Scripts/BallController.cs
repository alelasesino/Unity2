using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    public Text leftText, rightText, winText;
    public Button btRestart;
    public int leftPoints = 5;
    public int rightPoints = 5;
    public float speed = 30;

    void Start()
    {
        leftPoints = 5;
        rightPoints = 5;
        updateLeftText();
        updateRightText();
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        winText.text = "";
        btRestart.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col) {
        
        if(col.gameObject.name == "RacketLeft") {

            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1,y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            leftPoints++;

        }

        if(col.gameObject.name == "RacketRight") {

            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1,y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            rightPoints++;

        }

        if(col.gameObject.name == "WallLeft") {
            
            leftPoints--;
            resetPosition();

        } else if(col.gameObject.name == "WallRight") {
            
            rightPoints--;
            resetPosition();

        }

        updateLeftText();
        updateRightText();

    }

    float hitFactor(Vector2 ballPos,Vector2 racketPos, float racketHeight) {
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private void updateLeftText(){
        leftText.text = "Points: " + leftPoints.ToString();
    }

    private void updateRightText() {
        rightText.text = "Points: " + rightPoints.ToString();
    }

    private void resetPosition() {

        checkWin();
        transform.position = new Vector2(0, 0);

    }

    private void checkWin() {
    
        if(rightPoints <= 0) {
            
            winText.text = "Left Player Winner!";
            btRestart.gameObject.SetActive(true);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        } else if(leftPoints <= 0) {

            winText.text = "Right Player Winner!";
            btRestart.gameObject.SetActive(true);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        }
    
    }

    public void onRestartClick() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}
