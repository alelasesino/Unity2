using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    public Text leftText, rightText, winText;
    public Button btRestart;
    public float speed = 30;
    public GameState gameState;

    void Start()
    {
        gameState = GameState.instance;
        updateLeftText();
        updateRightText();
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        winText.text = "";
        btRestart.gameObject.SetActive(false);
    }

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.N)) 
            SceneManager.LoadScene("LevelTwo");

    }

    void OnCollisionEnter2D(Collision2D col) {
        
        if(col.gameObject.name == "RacketLeft") {

            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1,y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            gameState.leftPoints++;
            checkLevelUp();

        } else if(col.gameObject.name == "RacketRight") {

            float y = hitFactor(transform.position,col.transform.position,col.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1,y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            gameState.rightPoints++;
            checkLevelUp();

        } else if(col.gameObject.name == "WallLeft") {

            gameState.leftPoints--;
            resetPosition();

        } else if(col.gameObject.name == "WallRight") {

            gameState.rightPoints--;
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
        leftText.text = "Points: " + gameState.leftPoints.ToString();
    }

    private void updateRightText() {
        rightText.text = "Points: " + gameState.rightPoints.ToString();
    }

    private void resetPosition() {

        checkWin();
        transform.position = new Vector2(0, 0);

    }

    private void checkLevelUp() {

        if(gameState.rightPoints == 15)
            SceneManager.LoadScene("LevelTwo");

    }

    private void checkWin() {

        if(gameState.rightPoints <= 0) {
            
            winText.text = "Left Player Winner!";
            btRestart.gameObject.SetActive(true);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        } else if(gameState.leftPoints <= 0) {

            winText.text = "Right Player Winner!";
            btRestart.gameObject.SetActive(true);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        }
    
    }

    public void onRestartClick() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}
