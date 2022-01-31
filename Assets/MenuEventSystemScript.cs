using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEventSystemScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject menuCanvas;
    GameObject ui;
    GameObject menuArrow;
    RectTransform arrowPosition;
    void Start()
    {
        //canvas game object setup
        this.menuCanvas = new GameObject("MenuCanvas");
        this.ui =         GameObject.Find("UI");
        menuCanvas.transform.parent = this.ui.transform; //joins canvas menu with the ui object

        //canvas component setup
        Canvas menuCanvasCanvasComponent =     menuCanvas.AddComponent<Canvas>();
        menuCanvasCanvasComponent.renderMode = RenderMode.ScreenSpaceOverlay;
        menuCanvas.AddComponent<CanvasScaler>();
        menuCanvas.AddComponent<GraphicRaycaster>();

        //text game object setup
        GameObject uiText = new GameObject("MenuText");
        uiText.transform.SetParent(this.menuCanvas.transform);
        Text myText =       uiText.AddComponent<Text>();
       
        //text component setup
        myText.text =      "Start\n\nOptions\n\nExit";
        myText.font =      Resources.GetBuiltinResource<Font>("Arial.ttf");
        myText.fontSize =  12;
        myText.alignment = TextAnchor.MiddleCenter;

        //rectTransform component of text game object setup
        RectTransform rectTransform = myText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta =     new Vector2(400, 200);

        //arrow text game object setup
        GameObject arrowText =        new GameObject("ArrowText");
        arrowText.transform.SetParent(this.menuCanvas.transform);
        Text arrowTextTextComponent = arrowText.AddComponent<Text>();

        //arrow text component setup
        arrowTextTextComponent.text =      "-->";
        arrowTextTextComponent.font =      Resources.GetBuiltinResource<Font>("Arial.ttf");
        arrowTextTextComponent.fontSize =  12;
        arrowTextTextComponent.alignment = TextAnchor.MiddleCenter;

        //rectTransform component of arrowtext game object setup
        this.arrowPosition =          arrowTextTextComponent.GetComponent<RectTransform>();
        arrowPosition.localPosition = new Vector3(-40, 28.5f, 0);
        arrowPosition.sizeDelta =     new Vector2(400, 200);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (arrowPosition.localPosition.y < 28) { arrowPosition.localPosition = new Vector3(arrowPosition.localPosition.x, arrowPosition.localPosition.y + 28.5f, 0); }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (arrowPosition.localPosition.y > -28) { arrowPosition.localPosition = new Vector3(arrowPosition.localPosition.x, arrowPosition.localPosition.y - 28.5f, 0); }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (arrowPosition.localPosition.y < -28) Application.Quit();

            if (arrowPosition.localPosition.y > 28)
            {
                Destroy(menuCanvas);
                GameObject gameEventSystemGameObject = this.transform.parent.transform.GetChild(1).gameObject;
                gameEventSystemGameObject.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
