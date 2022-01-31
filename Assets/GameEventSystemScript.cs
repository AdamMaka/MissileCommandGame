using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameEventSystemScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject scoreAndLivesCanvas;
    GameObject ui;
    GameObject scoreText;
    GameObject livesText;
    RectTransform arrowPosition;
    int score;
    int lives;
    int timeThing;
    void Start()
    {
        score = 0;
        lives = 10;
        this.scoreAndLivesCanvas = new GameObject("ScoreAndLivesCanvas");
        this.ui =                  GameObject.Find("UI");
        scoreAndLivesCanvas.transform.parent = this.ui.transform; //joins canvas menu with the ui object

        //canvas component setup
        Canvas scoreAndLivesCanvasCanvasComponent = scoreAndLivesCanvas.AddComponent<Canvas>();
        scoreAndLivesCanvasCanvasComponent.renderMode = RenderMode.ScreenSpaceOverlay;
        scoreAndLivesCanvas.AddComponent<CanvasScaler>();
        scoreAndLivesCanvas.AddComponent<GraphicRaycaster>();

        //text game object setup
        GameObject scoreText = new GameObject("ScoreText");
        scoreText.transform.SetParent(this.scoreAndLivesCanvas.transform);
        Text scoreTextTextComponent = scoreText.AddComponent<Text>();

        //text component setup
        scoreTextTextComponent.text =      "Score: "+score;
        scoreTextTextComponent.font =      Resources.GetBuiltinResource<Font>("Arial.ttf");
        scoreTextTextComponent.fontSize =  12;
        scoreTextTextComponent.alignment = TextAnchor.LowerCenter;

        //rectTransform component of scoretext game object setup
        RectTransform rectTransform = scoreTextTextComponent.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, Screen.height-100, 0);
        rectTransform.sizeDelta =     new Vector2(400, 200);

        //lives game object setup
        GameObject livesText =        new GameObject("LivesText");
        livesText.transform.SetParent(this.scoreAndLivesCanvas.transform);
        Text livesTextTextComponent = livesText.AddComponent<Text>();

        //lives text component setup
        livesTextTextComponent.text =      lives.ToString();
        livesTextTextComponent.font =      Resources.GetBuiltinResource<Font>("Arial.ttf");
        livesTextTextComponent.fontSize =  12;
        livesTextTextComponent.alignment = TextAnchor.LowerLeft;

        //rectTransform component of arrowtext game object setup
        RectTransform meh = livesTextTextComponent.GetComponent<RectTransform>();
        meh.localPosition = new Vector3(10, Screen.height - 100, 0);
        meh.sizeDelta =     new Vector2(400, 200);
    }

    // Update is called once per frame
    void Update()
    {
        timeThing += 1;
        if (timeThing > 100)
        {
            timeThing = 0;

            //so this is the facade pattern I didnt think I would use but here we are
            //instantiate an enemy missile game object. Instatiate more than one with a for loop
            //this doesnt have to be time-constrained, I could add another if statement for the number of enemy projectiles and reset timeThing there
            //randomly generate its starting X position and ending X position and slowly modify its current Y position every frame to go towards those ending positions
            //maybe use a vector addition instead of this dry Y addition
            //keep in mind the positional constraints so that the enemy missiles stay on the screen with some margain
            
            
        }
        //get key inputs to modify the crosshair position much like the arrow on the menu screen
        //get one for shooting
        //get another circle object for an explosion
        //explode the missiles, destroy them and create "the dreaded circle" explosion that increases size over time and destroys itself
        //this could be managed with another variable for timing this
        //this could also be done on a Start() method of the circle object
    }
    void LateUpdate()
    {
        //detect collission with the circle explosion radius
        //^this could be done in Update method in the Explosion Game Object
        //For every shot missile and every destroyed missile, modify score
        //for every enemy projectile that reaches the bottom or below, destroy it, substract from the number of lives, substract from score
    }

    //there is still a lot that could be done
    //a lot of it is in the UML diagram, a lot I didn't write because I'm tired as heck as I'm writing this and didn't update the document. I had to speedrun.
    //I hope this can still make it to GitHub before 8. It's 7:30 now.
}
