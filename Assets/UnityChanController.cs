using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    Animator animator;
    Rigidbody2D rigid2D;

    private float groundLevel = -3.0f;

    //ジャンプ減速
    private float dump = 0.8f;
    //ジャンプ速度
    float jumpVelocity = 20;

    //ゲームオーバー位置
    private float deadLine = -9;

	// Use this for initialization
	void Start () {

        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        //走るアニメ再生のため、Animatorパラ調整
        this.animator.SetFloat("Horizontal", 1);

        //着地判定
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //ジャンプ状態時、ボリューム０
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
		
        //着地状態でクリック時
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //クリックやめたら上方向速度を減速
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //ゲームオーバー
        if (transform.position.x < this.deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            Destroy(gameObject);
        }

	}
}
