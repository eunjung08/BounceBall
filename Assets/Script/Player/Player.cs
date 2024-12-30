using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigid;
    public float jumpPower;
    public Vector2 returnPosition = new Vector2(-3.75f,-0.2f);

    public GameObject gameClearUI;
    private DataManager dataManager;

    private void Start()
    {
        //dataManager = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>();
        rigid = GetComponent<Rigidbody2D>();
        gameClearUI.SetActive(false);
        Time.timeScale = 1;
    }
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float input_x = Input.GetAxisRaw("Horizontal");

        Vector3 dir = new Vector3(input_x, 0, 0).normalized;

        transform.position += dir * speed * Time.deltaTime;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x > 1.25f || pos.x < 0.15 || pos.y > 1.2 || pos.y < 0) {transform.position = returnPosition;}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameClearUI.SetActive(true);
        Time.timeScale = 0;
    }
}
