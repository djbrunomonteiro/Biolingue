using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class HeroiMove_copiSeg : MonoBehaviour
{


    [SerializeField]
    public float puloMenorY = 6.0f, puloMaiorY = 2;
    private Rigidbody2D rb;
    public bool face = true;
    [Range(1, 20)]
    public float maxSpeed = 7f;
    public float move;
    //
    public bool nochao;
    public Transform noChaoCheck;
    public float nochaoRaio = 0.48f;
    public LayerMask oqEChao;
    [Range(1, 20)]
    public float jumpForce = 5F;

    //

    public Animator animH;
    [SerializeField]
    private int direcao = 0;

    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        animH = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (nochao == true && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        //Animação Andar
        if (nochao)
        {
            
            //move = Input.GetAxis("Horizontal");
			move = direcao;
            animH.SetFloat("X", Mathf.Abs(move));

        }

        //Animação Pulo

        animH.SetFloat("Y", rb.velocity.y);
        animH.SetBool("chao", nochao);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(noChaoCheck.position, nochaoRaio);
    }

    private void FixedUpdate()
    {
        nochao = Physics2D.OverlapCircle(noChaoCheck.position, nochaoRaio, oqEChao);
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = puloMenorY;

        }
        else if (rb.velocity.y > 0 && !CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            rb.gravityScale = puloMaiorY;
        }
        else
        {
            rb.gravityScale = 1;
        }

        //

        if (nochao)
        {
            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        }

        //

        if (move > 0 && !face)
        {
            Flip();
        }
        else if (move < 0 && face)
        {
            Flip();
        }

    }

    void Flip()
    {
        face = !face;
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }

    public void Direita()
    {
        direcao = 2;
    }
    public void Esquerda()
    {
        direcao = -2;
    }

    public void Parado()
    {
        direcao = 0;
    }

}

