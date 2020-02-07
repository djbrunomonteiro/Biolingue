using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class DOTWEEN_EX1 : MonoBehaviour
{
    
    public RectTransform imagemRect =null;
    public Image imagemSr = null;

    [SerializeField]
    private float velF =2; 
    private float velS=1;
    [SerializeField]
    private bool fade =true;
    private bool scale=true;
    
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        AnimacaoScala(velF,velS,fade,scale);
    }

    void AnimacaoScala(float velF, float velS, bool fade, bool scale)
    {

        if (scale)
        {
            if (imagemRect.localScale.x== 1)
            {
                imagemRect.DOScale(new Vector3(1.2f, 1.2f, 1.2f), velS);
            }
            else if (imagemRect.localScale.x == 1.2f)
            {
                imagemRect.DOScale(new Vector3(1f, 1f, 1f), velS);

            }
        }
        if (fade)
        {
            if (imagemSr.color.a == 1)
            {
                imagemSr.DOFade(0, velF);
            }
            else if (imagemSr.color.a == 0)
            {
                imagemSr.DOFade(1, velF);

            }
        }


    }


}
