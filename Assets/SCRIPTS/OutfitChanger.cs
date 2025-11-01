using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class OutfitChanger : MonoBehaviour
{
    [Header("Sprite to chng")]
    public SpriteRenderer BodyPart;

    [Header("List")]
    public List<Sprite> options = new List<Sprite>();

    private int CurentOption = 0;


    public void Prev()
    {
        CurentOption--; 
        if (CurentOption <= 0)
        {
            CurentOption = options.Count - 1;
        }
        BodyPart.sprite = options[CurentOption];

    }

    public void Next()
    {
        CurentOption++;
        if (CurentOption >= options.Count)
        {
            CurentOption = 0;
        }
        
        BodyPart.sprite = options[CurentOption];
    } 
    public void Randomize()
    {
	CurentOption = Random.Range(0, options.Count - 1);
	BodyPart.sprite = options[CurentOption]; 
    }


}
