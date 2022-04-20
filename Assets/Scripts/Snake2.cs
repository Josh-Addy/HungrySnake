using UnityEngine;
using System.Collections.Generic;


public class Snake2 : MonoBehaviour
{
    private Vector2 direction2 = Vector2.right;
    private Vector2 input2;
    private List<Transform> _segments2 = new List<Transform>();
    public Transform segmentPrefab2;
    public int initialSize2 =4;

    void Start() {
        ResetState();
    }
    void Update()
    {
        if (direction2.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                input2 = Vector2.up;
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                input2 = Vector2.down;
            }
        }

        else if (direction2.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                input2 = Vector2.right;
            } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                input2 = Vector2.left;
            }
        }
    }
    private void FixedUpdate() {
        
        if( input2 != Vector2.zero) {
            direction2 = input2;
        }
        
        for( int i = _segments2.Count - 1; i > 0; i--) {
            _segments2[i].position = _segments2[i -1].position;
        }

        this.transform.position =  new Vector2(
            Mathf.Round(this.transform.position.x) + direction2.x,
            Mathf.Round(this.transform.position.y) + direction2.y
        );
    }
    private void Grow() {
        Transform segment = Instantiate(this.segmentPrefab2);
        segment.position = _segments2[_segments2.Count - 1].position;
        segment.localScale =  _segments2[_segments2.Count - 1].localScale;
        _segments2.Add(segment);
    }
    private void ResetState() {        

        Time.fixedDeltaTime = 0.1f;
        direction2 = Vector2.right;
        this.transform.position = Vector3.zero;

        for (int i=1; i < _segments2.Count; i++) {
            Destroy(_segments2[i].gameObject);
        }

        _segments2.Clear();
        _segments2.Add(this.transform);

        for (int i = 0; i < this.initialSize2 - 1; i++) {
            Grow();
        }

        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Food") {
            Grow();
        } else if (other.tag == "Obstacle" ||other.tag == "Player"){ 
            ResetState();
            Food.points = 0;
        }
            
    } 
}
