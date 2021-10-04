using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GoalController : MonoBehaviour
{
    public bool isGameOver;
    private Rigidbody2D rb2d;
    private List<int> blockList;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isGameOver = false;
        blockList = new List<int>();
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver){
            if (blockList.Any()){
                elapsedTime += (Time.deltaTime);
            }
            else{
                elapsedTime = 0;
            }
        }

        if (elapsedTime > 3)
            isGameOver = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var controller = other.gameObject.GetComponent<BlockController>();
        if (controller != null){
            blockList.Add(controller.blockId);
        }               
    }
    
    // If the player is not colliding reset our timer
    void OnTriggerExit2D(Collider2D other)
    {
        var controller = other.gameObject.GetComponent<BlockController>();
        if (controller != null){
            blockList.Remove(controller.blockId);
        } 
    }
}
