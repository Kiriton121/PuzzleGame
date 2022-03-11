/* Created by: Zhiyong Lu
 *Date created: March 3, 2022
 *
 *Last edited by: Zhiyong Lu
 *Last edited date: March 7, 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    public float xMin;
    public float xMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RandomColor.instance.isPassedLevel)
        {
            return;
        }
        float x = Input.GetAxis("Horizontal"); // horizontal movement
        if (x != 0)
        {
            Vector3 pos = transform.position;
            pos.x += x * Time.deltaTime * speed;
            pos.x = Mathf.Clamp(pos.x,xMin,xMax); // restrict paddle movement, make sure that it is moving between two walls
            transform.position = pos;

        }

    }
}
