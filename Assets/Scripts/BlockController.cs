using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
	private Rigidbody2D rb2d;
	//private float speed;
    public BlockType blockType;
    public GameObject cyanWastePrefab;
    public int blockId;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
        blockId = UnityEngine.Random.Range(0, 9999);
        /*
		speed = 0.1f;

		var possibleRows = new int[] { -4, -2, 0, 2, 4 };
		var yCoordinate = possibleRows[Random.Range(0, possibleRows.Length - 1)];
		Debug.Log("Fireball spawned at " + yCoordinate);
		rb2d.MovePosition(new Vector2(10, yCoordinate));
        */
	}
	
	// Update is called once per frame
	void Update () {
		//MovePosition();
	}

    private void OnTriggerEnter2D(Collider2D collision)
	{
        if (blockType == BlockType.Wooden)
            return;

		if (collision.gameObject.name.Contains("Prefab"))
		{
            var controller = collision.gameObject.GetComponent<BlockController>();
            if (controller == null)
                return;
            
            var collisionType = controller.blockType;
			var blueCollision = blockType == BlockType.Green && collisionType == BlockType.Blue;
            var greenCollision = blockType == BlockType.Blue && collisionType == BlockType.Green;
            if (blueCollision || greenCollision){
                var pos = rb2d.position;
                Instantiate(cyanWastePrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(this);
            }
        }
	}

	private void MovePosition()
	{
		//var pos = rb2d.position;
		//rb2d.MovePosition(new Vector2(pos.x - speed, pos.y));
	}
}
