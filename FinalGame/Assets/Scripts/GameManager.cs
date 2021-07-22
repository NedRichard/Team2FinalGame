using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    


    public GameObject LoungeKeyText;
    public GameObject GeneratorPartText;

    void Start() {
        LoungeKeyText.SetActive(false);
        GeneratorPartText.SetActive(false);
    }


}
