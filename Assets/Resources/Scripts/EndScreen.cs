using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Text endTitleText;
    public Text endInfoText;
    string winTitle = "You Survived!";
    string loseTitle = "You Did Not Survive!";
    string winInfo = "The host body you were in survived while all the others have been defeated. You win! See, you were not lazy in your life, you were just practicing being a parasite this whole time!";
    string loseInfo = "The host body you we in was defeated and thus, you also died! You lose! It is not easy being a mind-controlling magical parasite, but hey, what is?";

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager.win)
        {
            endTitleText.text = winTitle;
            endInfoText.text = winInfo;
        }
        else
        {
            endTitleText.text = loseTitle;
            endInfoText.text = loseInfo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
