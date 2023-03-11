using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }
    private void Update(){
    isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
    isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer) && !isInAttackRange;

    // Вычисляем направление к игроку
    dir = target.position - transform.position;

    // Вычисляем угол между направлением на игрока и осью X
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

    // Нормализуем направление
    dir.Normalize();

    // Поворачиваем бота в направлении игрока
    if (shouldRotate){
        anim.SetFloat("X", dir.x);
        anim.SetFloat("Y", dir.y);
    }

    // Устанавливаем анимацию бега, если игрок находится в зоне преследования
    anim.SetBool("isRunning", isInChaseRange);
}

private void FixedUpdate() {
    if(isInChaseRange){
        MoveCharacter(dir);
    }
    if(isInAttackRange){
        rb.velocity = Vector2.zero;
    }
}

private void MoveCharacter(Vector2 dir){
    rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
}
}
