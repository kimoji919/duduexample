using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///���ƽ�ɫ�ƶ���������������

public class Playercontroller : MonoBehaviour
{
    public float speed = 5f;///�ƶ��ٶ�

    public float maxHealth = 20;
    public float timeInvincible = 1.0f;


    public float health { get { return currentHealth; } }
    public Transform RespawnPosition;
    public Image healthmeter;
    float currentHealth;

    bool isInvincible;
    float invincibleTimer;


    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private Vector2 _lookDirection = Vector2.down;
    private Vector2 _currentInput;

    private float _x;
    private float _y;

    public GameObject dialogControl;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();///�Ѿ�ʵ����
        currentHealth = maxHealth / 2;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");///��ȡxy

        Vector2 movement = new Vector2(_x, _y);
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (!Mathf.Approximately(a: movement.x, b: 0.0f) || !Mathf.Approximately(a: movement.y, b: 0.0f))
        {
            _lookDirection.Set(movement.x, movement.y);
            _lookDirection.Normalize();
        }

        _animator.SetFloat(name: "lookX", _lookDirection.x);
        _animator.SetFloat(name: "lookY", _lookDirection.y);
        _animator.SetFloat(name: "speed", movement.magnitude);

        _currentInput = movement;
        //Npc交互：
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(_rigidbody2D.position + Vector2.up * 0.2f, _lookDirection, 2f,
                LayerMask.GetMask("NPC"));//射线（发射的位置，发射方向，射线长度，射线目标（找相应layer））

            if (hit)
            {
                NpcController npcController = hit.collider.GetComponent<NpcController>();
                if (npcController)
                {
                    dialogControl.SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RaycastHit2D hit = Physics2D.Raycast(_rigidbody2D.position + Vector2.up * 0.2f, _lookDirection, 2f,
                LayerMask.GetMask("NPC"));//射线（发射的位置，发射方向，射线长度，射线目标（找相应layer））

            if (hit)
            {
                NpcController npcController = hit.collider.GetComponent<NpcController>();
                if (npcController)
                {
                    dialogControl.SetActive(false);
                }
            }


        }
    }

    private void FixedUpdate()
    {
        Vector2 position = _rigidbody2D.position;
        position += _currentInput * speed * Time.deltaTime;
        _rigidbody2D.MovePosition(position);
    }

    public void ChangeHealth(float amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        // Debug.Log(currentHealth + "/" + maxHealth);
        print("current health:" + currentHealth);
        if (currentHealth == 0)
        {
            Respawn();
        }
        Amount();
    }

    private void Respawn()
    {
        ChangeHealth(maxHealth / 2);
        _rigidbody2D.position = RespawnPosition.position;
    }

    public void Amount()
    {
        healthmeter.fillAmount = currentHealth/maxHealth;
        print("current fillamount:"+healthmeter.fillAmount);
    }
}
