using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        Controll();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
