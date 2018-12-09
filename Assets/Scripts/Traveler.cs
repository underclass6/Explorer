using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveler : MonoBehaviour {
    // 引用
    public Sprite[] sprites;

    // 字段
    private float speed;
    private int directIndex = 0;
    private Animator animator;
    private Vector3 currentPos;
    private SpriteRenderer spr;

	// Use this for initialization
	void Start () {
        currentPos = new Vector3(0, 0, 0);
        speed = 1.5f;
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Moving();
	}

    void LateUpdate()
    {
        if (!Input.anyKey)
            spr.sprite = sprites[directIndex];
    }

    private void Moving()
    {
        currentPos = transform.position;
        if (Input.anyKey)
        {
            setAnim();
            if (Input.GetKey(KeyCode.W))
            {
                currentPos.y += speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                currentPos.y -= speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                currentPos.x -= speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                currentPos.x += speed * Time.deltaTime;
            }
        }
        else
        {
            animator.SetInteger("direction", 0);
        }
        transform.position = currentPos;
    }

    private void setAnim()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            directIndex = 1;
            animator.SetInteger("direction", 2);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            directIndex = 0;
            animator.SetInteger("direction", 1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            directIndex = 2;
            animator.SetInteger("direction", 3);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            directIndex = 3;
            animator.SetInteger("direction", 4);
        }
    }
}
