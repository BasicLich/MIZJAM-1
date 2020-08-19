using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class WordBuilder : MonoBehaviour
{

    public Image imagePrefab;
    public string words;
    private int stableAmount;
    private List<Image> imgArray =  new List<Image>();
   

    [ContextMenu("Create")]
    public void CreateWord() {
        


        if (imgArray.Count == 0) {

           

            foreach (Transform t in transform) {
                Destroy(t.gameObject);
            }


            char[] c = words.ToCharArray();

            foreach (char c1 in c) {

                Image i = Instantiate(imagePrefab, transform);
                i.sprite = SpriteAlphabet.GetSprite(c1);
                imgArray.Add(i);

            }
        } else {

            char[] c = words.ToCharArray();

            if (imgArray.Count < words.Length) {
                int i = words.Length - imgArray.Count;
                for (int x = 0; x < i; x++) {
                    Image im = Instantiate(imagePrefab, transform);
                    imgArray.Add(im);
                }
            }

            int index = 0;

            foreach (Image i in imgArray) {


                if (words.Length > index) {
                    i.gameObject.SetActive(true);
                    i.sprite = SpriteAlphabet.GetSprite(c[index]);
                } else {
                    i.gameObject.SetActive(false);
                }



                index++;
            }



        }


    }

   




  
}
