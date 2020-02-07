using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour
{
    public GameObject Bio;
    public GameObject Bia;
    private Vector3 CharacterPosition;
    private Vector3 OffScreen;
    private int CharacterInt = 1;
    private SpriteRenderer BioRender, BiaRender;
    private readonly string selectedCharacter = "SelectedCharacter";


    private void Awake()
    {
        CharacterPosition = Bio.transform.position;
        OffScreen = Bia.transform.position;
        BioRender = Bio.GetComponent<SpriteRenderer>();
        BiaRender = Bia.GetComponent<SpriteRenderer>();
    }

    public void NextCharacter()
    {
        switch(CharacterInt)
        {
            case 1:
            PlayerPrefs.SetInt(selectedCharacter,2);
            BioRender.enabled =false;
            Bio.transform.position =OffScreen;
            Bia.transform.position = CharacterPosition;
            BiaRender.enabled= true;
            CharacterInt++;
            print(2);
            break;
            case 2:
            PlayerPrefs.SetInt(selectedCharacter,1);
            BiaRender.enabled =false;
            Bia.transform.position =OffScreen;
            Bio.transform.position = CharacterPosition;
            BioRender.enabled= true;
            CharacterInt++;
            print(1);
            ResetInt();
            break;
            default:
            ResetInt();
            break;

        }
    }

private void ResetInt()
{
if (CharacterInt >=2)
{
    CharacterInt = 1;
}

}
public void SelecScene()
{
    SceneManager.LoadScene(2);
}

}
