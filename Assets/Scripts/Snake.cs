using UnityEngine;
using System.Collections.Generic;


public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private Vector2 input;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize =4;

    void Start() {
        ResetState();
    }
    void Update()
    {
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W)) {
                input = Vector2.up;
            } else if (Input.GetKeyDown(KeyCode.S)) {
                input = Vector2.down;
            }
        }

        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D)) {
                input = Vector2.right;
            } else if (Input.GetKeyDown(KeyCode.A)) {
                input = Vector2.left;
            }
        }
    }
    private void FixedUpdate() {
        
        if( input != Vector2.zero) {
            direction = input;
        }
        
        for( int i = _segments.Count - 1; i > 0; i--) {
            _segments[i].position = _segments[i -1].position;
        }

        this.transform.position =  new Vector2(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y
        );
    }
    private void Grow() {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        segment.localScale =  _segments[_segments.Count - 1].localScale;
        _segments.Add(segment);
    }
    private void ResetState() {        

        Time.fixedDeltaTime = 0.1f;
        direction = Vector2.right;
        this.transform.position = Vector3.zero;

        for (int i=1; i < _segments.Count; i++) {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 0; i < this.initialSize - 1; i++) {
            Grow();
        }

        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Food") {
            Grow();
        } else if (other.tag == "Obstacle"){ 
            ResetState();
            Food.points = 0;
        }
            
    } 
}
