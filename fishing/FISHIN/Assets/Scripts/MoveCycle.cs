using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCycle : MonoBehaviour
{
    public Vector2 direction = Vector2.right;
    public float speed = 1f;
    public int size = 1;
    float yPosition;
    public int Points;

    private Vector3 leftEdge;
    private Vector3 rightEdge;

    FishSpawning fishScript;

    // Start is called before the first frame update
    void Start()
    {
        int RandomDirection = Random.Range(-1, 1);
        if (RandomDirection == -1)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }

        fishScript = FindObjectOfType<FishSpawning>();
        leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        if (direction == Vector2.left)
        {
            transform.position = new Vector3(4, Random.Range(-4f, 2f), 0);
            this.gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float yPosition = transform.position.y;

        if (direction.x > 0 && (transform.position.x - size) > rightEdge.x)
        {
            fishScript.ChildCount -= 1;
            Destroy(gameObject);

        }
        else if (direction.x < 0 && (transform.position.x + size) < leftEdge.x)
        {
            fishScript.ChildCount -= 1;
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
