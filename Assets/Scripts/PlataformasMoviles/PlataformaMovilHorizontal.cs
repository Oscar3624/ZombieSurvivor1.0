using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovilHorizontal : PlataformaMovil
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 5f;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    //Mismo comportamiento que la vertical solo cambio el offset
    public override void Move()
    {
        float offset = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPos + new Vector3(offset, 0, 0);
    }

}
