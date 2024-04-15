using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Rotate")]
    public float mouseSpeed;
    float yRotation;
    float xRotation;
    Camera cam;

    [Header("Movement")]
    public float speed;    
    float hAxis;
    float vAxis;

    [Header("Fire")]
    bool fDown;
    public bool rDown;
    bool isFireReady;
    float fireDelay = 0f;
    public Weapon weapon;

    Vector3 moveVec;
    [Header("Animation")]
    Animator anim;
    Rigidbody rigid;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rigid = GetComponent<Rigidbody>();
        rigid.freezeRotation = true;

        cam = Camera.main;
    }

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Rotate();
        Fire();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = transform.right * hAxis + transform.forward * vAxis;
        moveVec = moveVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(transform.position + moveVec);
        anim.SetBool("isRun", moveVec != Vector3.zero);
    }

    void Rotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void Fire()
    {
        fDown = Input.GetButton("Fire1");
        if(!rDown)
            rDown = Input.GetKeyDown(KeyCode.R);
        fireDelay += Time.deltaTime;
        isFireReady = weapon.delay < fireDelay;

        if(rDown && fDown && isFireReady)
        {
            weapon.Use(0);
            anim.SetTrigger("doFire");
            fireDelay = 0;
            rDown = false;
        }
    }

}
