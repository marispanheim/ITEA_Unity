using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5F;
    private void Movement1(Vector3 direction)
    {
        transform.position += direction * _speed;
    }
    private void Controll()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Movement1(Vector3.forward);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            Movement1(Vector3.back);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Movement1(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Movement1(Vector3.right);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        Controll();
    }
}
