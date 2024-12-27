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

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Move();
        rigid.freezeRotation=true;
    }

    private void Move()
    {
        float input_x = Input.GetAxisRaw("Horizontal");

        Vector3 dir = new Vector3(input_x, 0, 0).normalized;

        transform.position += dir * speed * Time.deltaTime;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x > 1.25f || pos.x < 0.15 || pos.y > 1.2 || pos.y < 0) {Debug.Log("인식"); transform.position = returnPosition;}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log(collision.transform.name);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log(collision.transform.name);
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Finsh");
    }
}