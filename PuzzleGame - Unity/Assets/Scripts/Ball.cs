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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0) )
        {
            Vector3 NormalizedSpeed = new Vector3(1f, 1f, 0).normalized;
            rb.velocity = NormalizedSpeed * speed * Time.deltaTime;
        } // when you click, ball starts to move
    }
}
