using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordBuilder : MonoBehaviour
{

    public Image imagePrefab;
    public string words;


    private void Awake() {
        CreateWord();
    }

    [ContextMenu("Create")]
    public void CreateWord() {
        foreach (Transform t in transform) {
            Destroy(t.gameObject);
        }


        char[] c = words.ToCharArray();


        foreach (char c1 in c) {

            Image i = Instantiate(imagePrefab, transform);
            i.sprite = SpriteAlphabet.GetSprite(c1);


        }


    }



  
}
