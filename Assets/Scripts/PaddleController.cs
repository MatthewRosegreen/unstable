using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PaddleController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public bool isLeftPaddle;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var rotationZ = rb2d.transform.localRotation.eulerAngles.z;
        var isMovable = isLeftPaddle
            ? (rotationZ < 360 && rotationZ > 310)
            : (rotationZ < 355 && rotationZ > 0);

        var isResting = isLeftPaddle
            ? (rotationZ < 5 || rotationZ > 315)
            : (rotationZ < 45 || rotationZ > 355);

        //Debug.Log(rotationZ);
        if (isLeftPaddle && Input.GetKey(KeyCode.LeftArrow)){
            if (isMovable)
                rb2d.transform.Rotate(0, 0, speed);
        }
        else if (!isLeftPaddle && Input.GetKey(KeyCode.RightArrow)){
            if (isMovable)
                rb2d.transform.Rotate(0, 0, -speed);
        }
        else{
            if (isResting)
                rb2d.transform.Rotate(0, 0, (isLeftPaddle ? -speed : speed));
        }
    }

    
}
