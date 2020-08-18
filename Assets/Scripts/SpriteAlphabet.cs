using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CharSprite {

    public char ch;
    public Sprite spr;


}


[CreateAssetMenu(fileName = "New Alphabet", menuName = "Alphabet", order = 1)]
public class SpriteAlphabet : ScriptableObject
{
    public List<CharSprite> charSprites;
    private static Dictionary<char, Sprite> dict;



    


    public static void SetupDicitionary(List<CharSprite> charSprites) {
        dict = new Dictionary<char, Sprite>();

        foreach (CharSprite s in charSprites) {
            dict.Add(s.ch, s.spr);
        }

    }


    public static Sprite GetSprite(char ch) {
        return dict[char.ToLower(ch)];
    }

}
