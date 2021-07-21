using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(speed, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        if(position.x < GetLeft())
        {
            Destroy(gameObject);
        }
    }

     float GetLeft()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        return min.x;
    }

    public void setSpeed (float speed)
    {
        this.speed = speed;
    }
}
