using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const int SPR_FALL = 0;
    const int SPR_JUMP = 1;

    [SerializeField]
    float JUMP_VELOCITY = 500;
    public Sprite[] SPR_LIST;
    public GameObject gameMgr;

    Rigidbody2D _rigidbody2D;
    SpriteRenderer sRender;
    GameMgr _gameMgr;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        sRender = GetComponent<SpriteRenderer>();

        _gameMgr = gameMgr.GetComponent<GameMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(new Vector2(0, JUMP_VELOCITY));
        }

        if (_rigidbody2D.velocity.y < 0)
        {
            sRender.sprite = SPR_LIST[SPR_FALL];
        }
        else
        {
            sRender.sprite = SPR_LIST[SPR_JUMP];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        _gameMgr.GameOver();
    }

    private void FixedUpdate()
    {
        Vector3 position = transform.position;

        float y = transform.position.y;
        float vx = _rigidbody2D.velocity.x;

        if (y > GetTop())
        {
            _rigidbody2D.velocity = Vector2.zero;
            position.y = GetTop();
        }
        else if (y < GetBottom())
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(new Vector2(0, JUMP_VELOCITY));
            position.y = GetBottom();
        }

        transform.position = position;
    }

    float GetTop()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
        return max.y;
    }

    float GetBottom()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        return min.y;
    }
}
