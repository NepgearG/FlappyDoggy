using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMgr : MonoBehaviour
{

    public GameObject block;

    float timer = 0;
    float totalTimer = 0;
    int _cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        totalTimer += Time.deltaTime;
        if(timer < 0)
        {
            Vector3 position = transform.position;
            position.y = Random.Range(-4, 5);
            GameObject obj = Instantiate(block, position, Quaternion.identity);
            Block blockScript = obj.GetComponent<Block>();
            float speed = 100 + (totalTimer * 10);
            blockScript.setSpeed(-speed);
            _cnt++;
            if (_cnt % 10 > 8)
            {
                timer += 0.2f;
            } else if (_cnt % 10 < 2)
            {
                timer += 0.3f;
            }
            else
            {
                timer += 0.5f;
            }
        }
    }
}
