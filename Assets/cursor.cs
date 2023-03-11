using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    // Timer
    private float nextActionTime = 0.0f;
    public float timeBetweenTwoSpriteRes = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime) {
            transform.position = transform.position + new Vector3(0.0f, -100.0f, 0.0f);

            nextActionTime += timeBetweenTwoSpriteRes;
        }
    }
}
