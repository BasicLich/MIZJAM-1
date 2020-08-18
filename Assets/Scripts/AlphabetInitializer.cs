using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetInitializer : MonoBehaviour
{

    public SpriteAlphabet alpha;

    [ContextMenu("Setup")]
    public void initAlphabet() {

        SpriteAlphabet.SetupDicitionary(alpha.charSprites);

    }

    private void Awake() {
        initAlphabet();
    }



}
