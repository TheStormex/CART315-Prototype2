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
    public int currentBodyNumber;
    string[] wizardsList = { "Yellow Wizard", "Blue Wizard", "Red Wizard"};
    public static bool win = true;
    // wizard abilities
    int chosenAbility;

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
        currentBodyNumber = Random.Range(0, 2);
        currentBody = wizardsList[currentBodyNumber];
        // choose next body, repeat until not the same as current body
        int nextBodyNumber = Random.Range(0, 2);
        while (nextBodyNumber == currentBodyNumber)
        {
            nextBodyNumber = Random.Range(0, 2);
        }
        nextBody = wizardsList[nextBodyNumber];

        yellowHealthSlider.gameObject.SetActive(true);
        blueHealthSlider.gameObject.SetActive(true);
        redHealthSlider.gameObject.SetActive(true);
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
        yellowHealthSlider.value = (float)yellowHealth / (float)yellowMaxHealth;
        blueHealthSlider.value = (float)yellowHealth / (float)yellowMaxHealth;
        redHealthSlider.value = (float)yellowHealth / (float)yellowMaxHealth;
    }
    public void UseAbility(int chosenButton)
    {

    }
    public void OthersAbility()
    {

    }
    public void nextTurn()
    {
        switch (currentBody)
        {
            case "Yellow Wizard":

                break;
        }
    }
}
