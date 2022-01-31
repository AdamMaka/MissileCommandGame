using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEventSystemScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject introCanvasGameObject;
    GameObject menuEventSystemGameObject;
    void Start()
    {
        this.introCanvasGameObject =     GameObject.Find("IntroCanvas");
        GameObject scriptsGameObject =   GameObject.Find("Scripts");
        this.menuEventSystemGameObject = scriptsGameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.introCanvasGameObject == null)
        {
            this.menuEventSystemGameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
    void OnDestroy()
    {

    }
}
