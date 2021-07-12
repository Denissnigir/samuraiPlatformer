using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4f; // Скорость передвижения
    private float jumpForce = 230f; // Сила прыжка

    [SerializeField] private Sprite playerRight; // Спрайт персонажа, повёрнутого вправо
    [SerializeField] private Sprite playerLeft; // Спрайт персонажа, повёрнутого влево

    private SpriteRenderer spriteRenderer; // Компонент спрайтрендер персонажа

    private Rigidbody2D rgBody; // Физика персонажа

    private bool isJumping = false; // Проверка на касание земли 

    private Animator playerAnim; // Аниматор игрока

    private bool isRight = true;

    void Start()
    {
        // Инициализируем спрайтрендер персонажа
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Ставим по дефолту лицом вправо
        spriteRenderer.sprite = playerRight;

        // Инициализируем физику персонажа
        rgBody = GetComponent<Rigidbody2D>();

        playerAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверка на соприкосновение с землёй
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

    void Update()
    {
        // Инициализируем движение по оси X
        float move = Input.GetAxis("Horizontal");

        // Смена спрайта в зависимости от направления
        if (move < 0 && isJumping == false)
        {
            spriteRenderer.sprite = playerLeft;
            playerAnim.Play("player_left_run");
            isRight = false;
        } else if (move > 0 && isJumping == false)
        {
            spriteRenderer.sprite = playerRight;
            playerAnim.Play("player_right_run");
            isRight = true;
        }

        // Само движение
        transform.Translate(Vector2.right * Time.deltaTime * move * speed);

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rgBody.AddForce(Vector2.up * jumpForce);
            isJumping = true;

            if (move < 0 || isRight == false)
            {
                playerAnim.Play("player_left_jump");
            } else if (move > 0 || isRight == true)
            {
                playerAnim.Play("player_right_jump");
            }
        }
    }

}
