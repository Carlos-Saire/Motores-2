using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    private SpriteRenderer _sR;
    [SerializeField] GameObject objetivo;
    [SerializeField] private Color color;
    [SerializeField] private float speed;
    private void Awake()
    {
        _sR = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _sR.color = color;
    }
    private void Update()
    {
        Move();
    }
    public void SetObjetive(GameObject NewObjetivo)
    {
        objetivo= NewObjetivo;
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, objetivo.transform.position, speed * Time.deltaTime);
    }
}
