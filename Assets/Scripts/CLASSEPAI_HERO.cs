using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using System;

[System.Serializable]
public class InfosChar
{
    public float puloMenorY = 6.0f, puloMaiorY = 2;
    public Rigidbody2D rb;
    public bool face = true;
    [Range(1, 20)]
    public float maxSpeed = 7f;
    public float move;
    public bool nochao;
    public Transform noChaoCheck;
    public float nochaoRaio = 0.48f;
    public LayerMask oqEChao;
    [Range(1, 20)]
    public float jumpForce = 5F;
    public Button pulo;
    public JoyControl joyC;
    
}


public abstract class CLASSEPAI_HERO : MonoBehaviour
{
    public InfosChar infChar;
    public virtual void Start()
    {
        infChar.pulo = GameObject.FindWithTag("pulo").GetComponent<Button>();
        infChar.pulo.onClick.AddListener(Pulo);

    }
    public abstract void Pulo();

     void FaceMetodo(Transform t)
    {
		
		//novidade
		if (infChar.nochao) {
			if (infChar.move > 0 && !infChar.face) {
				Flip (t);


			} else if (infChar.move < 0 && infChar.face) {
				Flip (t);

			}
		}
    }
    void Flip(Transform obj)
    {
        infChar.face = !infChar.face;
        Vector3 tempScale = obj.localScale;
        tempScale.x *= -1;
		obj.localScale = tempScale;
    }
  
    protected void InfosPulo()
    {
         infChar.nochao = Physics2D.OverlapCircle(infChar.noChaoCheck.position, infChar.nochaoRaio, infChar.oqEChao);
        if (infChar.rb.velocity.y < 0)
        {
            infChar.rb.gravityScale = infChar.puloMenorY;

        }
        else if (infChar.rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            infChar.rb.gravityScale = infChar.puloMaiorY;
        }
        else
        {
            infChar.rb.gravityScale = 1;
        }
        if(infChar.nochao)
        {
            infChar.rb.velocity = new Vector2(infChar.move*infChar.maxSpeed,infChar.rb.velocity.y);
            FaceMetodo(transform);
        }
        

    }
}
