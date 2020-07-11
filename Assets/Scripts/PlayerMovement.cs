using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    BattleLoader transition;

    public float moveSpeed = 5f;
    public Transform movePoint;
    public char lastKeyPressed;

	// Start is called before the first frame update
    void Start()
    {
        transition = GameObject.Find("BattleLoader").GetComponent<BattleLoader>();
		movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                movePoint.position += new Vector3(-0.5f, 0.75f);
                lastKeyPressed = 'W';
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                movePoint.position += new Vector3(0.5f, 0.75f);
                lastKeyPressed = 'E';
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                movePoint.position += new Vector3(-1, 0);
                lastKeyPressed = 'A';
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                movePoint.position += new Vector3(1, 0);
                lastKeyPressed = 'D';
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                movePoint.position += new Vector3(-0.5f, -0.75f);
                lastKeyPressed = 'Z';
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                movePoint.position += new Vector3(0.5f, -0.75f);
                lastKeyPressed = 'X';
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Enemy")
        {
            if (lastKeyPressed == 'W')
            {
                movePoint.position -= new Vector3(-0.5f, 0.75f);
            }
            else if (lastKeyPressed == 'E')
            {
                movePoint.position -= new Vector3(0.5f, 0.75f);
            }
            else if (lastKeyPressed == 'A')
            {
                movePoint.position -= new Vector3(-1, 0);
            }
            else if (lastKeyPressed == 'D')
            {
                movePoint.position -= new Vector3(1, 0);
            }
            else if (lastKeyPressed == 'Z')
            {
                movePoint.position -= new Vector3(-0.5f, -0.75f);
            }
            else if (lastKeyPressed == 'X')
            {
                movePoint.position -= new Vector3(0.5f, -0.75f);
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            transition.startBattle();
        }
    }
}
