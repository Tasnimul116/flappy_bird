using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float topBoundary;
    public float bottomBoundary;
    void Start()
    {
      
        myRigidbody = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {

        myRigidbody.linearVelocity = Vector2.up * 10;
        }

        if (transform.position.y > topBoundary)
        {
            transform.position = new Vector3(transform.position.x, topBoundary, transform.position.z);
            myRigidbody.linearVelocity = Vector2.zero; // stop going higher
        }

        // ✅ Check bottom boundary
        if (transform.position.y < bottomBoundary)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
