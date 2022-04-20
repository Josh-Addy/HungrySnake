using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public static int points = 0;
    public static int highScore = 0;
    private void Start() {
        RandomizePosition();
    }
    private void RandomizePosition() {
        Bounds bounds = this.gridArea.bounds;

        int checks = 0;
             float x = 0; float y=0;
             while (checks <5000) {
                 checks++;
                 // get random coordinate between -120 and  + 120.
                 x = Random.Range(bounds.min.x, bounds.max.x);
                 y = Random.Range(bounds.min.y, bounds.max.y);
                 if(!Physics2D.OverlapCircle(new Vector2(x, y), 0.5f)){break;}
             }
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        Debug.Log("I checked " + checks + " places before i found a spot");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            RandomizePosition();
            points++;
            
            if ( highScore< points) {
                highScore++;
            }
        } else if (other.tag == "Obstacle") {
            RandomizePosition();
        }
    }
}