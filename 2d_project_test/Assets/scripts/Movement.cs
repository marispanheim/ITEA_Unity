using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 23;
    public float rightScreenEdge;
    public float lefttScreenEdge;
    public GameManeger gm;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    void FixedUpdate()
    {
        if (gm.gameOver)
        {
            return;
        }
        Controll();
        ScreenCorners();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
    }
    public void Controll()
    {
        if (Input.GetKey(KeyCode.A))
        {
            PlatformMovement(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlatformMovement(Vector3.right);
        }
    }
    public void PlatformMovement(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
    }

    public void ScreenCorners()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * Vector2.right * Time.deltaTime * _speed);
        
        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }
        if (transform.position.x < lefttScreenEdge)
        {
            transform.position = new Vector2(lefttScreenEdge, transform.position.y);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AddLife"))
        {

        }
        gm.UpdateLives(1);
        Destroy(other.gameObject);
    }



}
