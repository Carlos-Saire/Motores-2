using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rd;
    private SpriteRenderer _sR;
    private float horizontal;
    private bool isJump;
    private bool isOneJump;
    private bool isDoubleJump;
    private bool removelifa=false;
    private RaycastHit2D hit;
    [SerializeField] private float speed;
    [SerializeField] private float life;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private GameObject finished;
    [SerializeField] private TMP_Text finishedText;
    [SerializeField] private CounterController counter;
    [SerializeField] private TMP_Text timeF;
    [SerializeField] private GameManagerController gameManager;
    private void Awake()
    {
        _rd = GetComponent<Rigidbody2D>();
        _sR = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        scrollbar.size = life/10;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
        if (life <= 0)
        {
            finishedText.text = "GAME OVER";
            finished.SetActive(true);
            timeF.text ="Time: "+ counter.Counter();
            Time.timeScale = 0;
        }
    }
    private void FixedUpdate()
    {
        _rd.velocity = new Vector2(horizontal*speed, _rd.velocity.y);
        CheckRaycast();
        if (isJump == true)
        {
            if(isOneJump == true)
            {
                _rd.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isJump = false;
            }
            else if (isDoubleJump == true)
            {
                _rd.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isDoubleJump = false;
            }
        }
    }
    private void CheckRaycast()
    {
        hit = Physics2D.Raycast(transform.position,Vector2.down, 1.03f, groundLayer);
        if (hit.collider != null)
        {
            isOneJump = true;
            isDoubleJump= true;
        }
        else
        {
            isOneJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("finished"))
        {
            finishedText.text = "WIN";
            finished.SetActive(true);
            timeF.text = "Time: " + counter.Counter();

            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("Enemy")|| collision.gameObject.CompareTag("Piso"))
        {
            gameManager.ButtonsInteracutue(false);

            if (_sR.color != collision.gameObject.GetComponent<SpriteRenderer>().color)
            {
                removelifa = true;
                RemoveLife();
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
           gameManager.ButtonsInteracutue(true);
        removelifa = false;
    }
    private void RemoveLife()
    {
        --life;
        if (removelifa == true)
        {
            Invoke("RemoveLife", 0.3f);
        }
    }
}
