/* Created by: Zhiyong Lu
 *Date created: March 3, 2022
 *
 *Last edited by: Zhiyong Lu
 *Last edited date: March 7, 2022
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody rb;
    public float speed; //speed of ball
    public Transform paddle;
    private const float yreset = -5F;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0) && !RandomColor.instance.isPlaying)
        {
            Vector3 NormalizedSpeed = new Vector3(1f, 1f, 0).normalized;
            rb.velocity = NormalizedSpeed * speed;
            RandomColor.instance.isPlaying = true;
        } // when you click, ball starts to move

        if (!RandomColor.instance.isPlaying)
        {
            Vector3 pos = transform.position;
            pos.x = paddle.position.x;
            pos.y = yreset;
            transform.position = pos;
        } // if the game hasn't started, when you move the paddle, the ball will follow the paddle

        if (Input.GetKey(KeyCode.Keypad0))
        {
            Vector3 pos = paddle.position;
            pos.x = transform.position.x;
            paddle.position = pos;
        }

    }
}
