using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chara : MonoBehaviour
{
    //Animator animator;
    public bool waterflag;
    public bool plantflag;
    GameObject player;
    GameObject plant;

    Rigidbody2D rigid2D;
    float jumpForce = 200.0f;
    float walkForce = 10.0f;
    float walkSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.player = GameObject.Find("mizu");
        this.plant = GameObject.Find("chara");
        waterflag = false;
        plantflag = false;
        //this.animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // ジャンプする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        float key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 0.25f;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -0.25f;

        // プレイヤの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // スピード制限
        if (speedx < this.walkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 動く方向に応じて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d= dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if(d<r1+r2)
        {
            waterflag = true;
            Destroy(GameObject.Find("mizu"));
        }
        if(waterflag==true)
        {
            this.player = GameObject.Find("plant");
            Vector2 p3= transform.position;
            Vector2 p4 = this.player.transform.position;
            Vector2 dir2 = p3 - p4;
            float d2 = dir2.magnitude;
            float r3 = 0.5f;
            float r4 = 1.0f;
            if (d2 < r3 + r4 )
            {
                plantflag = true;

                //this.animator.SetTrigger("changeTrigger");

               // Destroy(GameObject.Find("plant"));
            }
        }
    }
}
