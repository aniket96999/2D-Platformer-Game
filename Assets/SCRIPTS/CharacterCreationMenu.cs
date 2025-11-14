using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CharacterCreationMenu : MonoBehaviour
{
    public GameObject character;
    public List<OutfitChanger> outfitChangers = new List<OutfitChanger>();
    public void Submit()
    { 
	#if UNITY_EDITOR
        PrefabUtility.SaveAsPrefabAsset(character, "Assets/Player.prefab");
    #endif
        SceneManager.LoadScene(1);
    }
    public void RandomizeCharacter()
    { 
	foreach(OutfitChanger changer in outfitChangers)
	{
	    changer.Randomize();
	}
     }  
}
