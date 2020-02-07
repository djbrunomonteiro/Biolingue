using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainCharacter : MonoBehaviour
{
   public GameObject Bio;
   public GameObject Bia;
    private readonly string selectedCharacter = "SelectedCharacter";
    

    void Awake()
    {
    
    }
    void Start()
    {
        int getCharacter;
        getCharacter = PlayerPrefs.GetInt(selectedCharacter);
        if(getCharacter ==1)
        {
            Bia.SetActive(false);
            Bio.SetActive(true);
        }
        else
        {
            Bia.SetActive(true);
            Bio.SetActive(false);
        }
    }

}

