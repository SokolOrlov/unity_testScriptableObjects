using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private EnemyData _data;

    public void Init(EnemyData data)
    {
        _data = data;
        GetComponent<SpriteRenderer>().sprite = data.MainSprite;
    }

    public float Attack
    {
        get {return _data.Attack;}
        protected set {}
    }

    public static Action<GameObject> OnEnemyOverFly;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * _data.Speed);

        if (transform.position.y < -10 && OnEnemyOverFly !=null)
        OnEnemyOverFly(gameObject);
    }
}
