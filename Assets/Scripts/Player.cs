using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("Начальная позиция игрока")]
    [SerializeField] private Vector3 startPos;

    [Tooltip("Начальное количество здоровья")]
    [SerializeField] private float health = 5.0f;

    [Tooltip("Скорость игрока")]
    [Range(0.01f, 0.5f)]
    [SerializeField] private float speed = 0.1f;

    private void Start()
    {
        transform.position = startPos;
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -GameCamera.Border)
        {
            transform.Translate(Vector3.left * speed);
        }
        else
        if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < GameCamera.Border)
        {
            transform.Translate(Vector3.right * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        var obj = col.gameObject;
        if(EnemySpawner.Enemies.ContainsKey(obj))
        {
            health -= EnemySpawner.Enemies[obj].Attack;
            if(health<=0)
            {
                Destroy(gameObject);
                Debug.Log("game over");
            }
            else{
                Debug.Log(health + "hp");
            }
        }    
    }

    void OnTriggerEnter2D(Collider2D col)
        {
            var obj = col.gameObject;
            if(EnemySpawner.Enemies.ContainsKey(obj))
            {
                health -= EnemySpawner.Enemies[obj].Attack;
                if(health<=0)
                {
                    Destroy(gameObject);
                    Debug.Log("game over");
                }
                else{
                    Debug.Log(health + "hp");
                }
            }   
        }


}
