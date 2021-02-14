using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    // variables

    public int yellowHealth = 30;
    public int yellowMaxHealth = 30;
    public int redHealth = 20;
    public int redMaxHealth = 20;
    public int blueHealth = 25;
    public int blueMaxHealth = 25;
    public int turnsBeforeChange = 2;
    public string nextBody = "This wizard";
    public string currentBody;
    string[] wizardsList = { "Yellow Wizard", "Blue Wizard", "Red Wizard"};
    public static bool win = true;

    // references
    public Text yellowHealthText;
    public Text blueHealthText;
    public Text redHealthText;
    public Slider yellowHealthSlider;
    public Slider blueHealthSlider;
    public Slider redHealthSlider;
    public Text nextBodyText;
    public Text currentWizardText;

    // Start is called before the first frame update
    void Start()
    {
        // start in a random body
        int chooseBody = Random.Range(0, 2);
        currentBody = wizardsList[chooseBody];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // present the UI
        yellowHealthText.text = yellowHealth.ToString() + " / " + yellowMaxHealth.ToString();
        blueHealthText.text = blueHealth.ToString() + " / " + blueMaxHealth.ToString();
        redHealthText.text = redHealth.ToString() + " / " + redMaxHealth.ToString();
        nextBodyText.text = "You'll possess " + nextBody + " in " + turnsBeforeChange + " turns.";
        currentWizardText.text = currentBody;
    }
}
