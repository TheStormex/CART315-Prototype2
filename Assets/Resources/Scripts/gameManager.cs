using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    // variables

    public int yellowHealth = 30;
    public int yellowMaxHealth = 30;
   // public int yellowDamageOutgoing = 100;
   // public int yellowDamageIncoming = 100;
    public int redHealth = 20;
    public int redMaxHealth = 20;
  //  public int redDamageOutgoing = 100;
  //  public int redDamageIncoming = 100;
    public int blueHealth = 25;
    public int blueMaxHealth = 25;
  //  public int blueDamageOutgoing = 100;
  //  public int blueDamageIncoming = 100;

    public int turnsBeforeChange = 2;
    public string nextBody = "This wizard";
    public string currentBody;
    public string[] bodyCycle;
    public int currentBodyNumber;
    // active character (ploayer or computer)
    public string activeChar;
    public string[] wizardsList = { "Yellow Wizard", "Blue Wizard", "Red Wizard"};
    public static bool win = true;
    // wizard abilities
    string[] yellowAbilitiesNames = { "Rock Throw", "Mudslide"};
    string[] blueAbilitiesNames = { "Water Blast", "Tsunami"};
    string[] redAbilitiesNames = { "Fireball", "Heat Wave"};
    int[] yellowAbilitiesInfo = {5, 3};
    int[] blueAbilitiesInfo = {4, 4};
    int[] redAbilitiesInfo = {6, 2};
    // timer for explanation before effects happen
    float timer = 1.5f;
    float timerLimit = 1.5f;
    // phases of turns: 0 - choosing ability (player is active); 1 - explain what will happen; 2 - the effect happens.
    int phases = 0;

    // references
    public Text yellowHealthText;
    public Text blueHealthText;
    public Text redHealthText;
    public Slider yellowHealthSlider;
    public Slider blueHealthSlider;
    public Slider redHealthSlider;
    public Text nextBodyText;
    public Text currentWizardText;
    public Text abilityButtonOneText;
    public Text abilityButtonTwoText;
    public Text abilityButtonThreeText;
    public Text abilityButtonOneInfo;
    public Text abilityButtonTwoInfo;
    public Text abilityButtonThreeInfo;
    public Text infoText;

    // Start is called before the first frame update
    void Start()
    {
        // start in a random body
        currentBodyNumber = Random.Range(0, 3);
        currentBody = wizardsList[currentBodyNumber];
        // choose next body and last, repeat until not the same as old ones
        findNextBody();
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
        blueHealthSlider.value = (float)blueHealth / (float)blueMaxHealth;
        redHealthSlider.value = (float)redHealth / (float)redMaxHealth;
        Debug.Log(timer);
        switch (currentBody)
        {
            case "Yellow Wizard":
                abilityButtonOneText.text = yellowAbilitiesNames[0] + " towards Blue Wizard";
                abilityButtonTwoText.text = yellowAbilitiesNames[0] + " towards Red Wizard";
                abilityButtonThreeText.text = yellowAbilitiesNames[1];
                abilityButtonOneInfo.text = "Deal " + yellowAbilitiesInfo[0].ToString() + " Damage to Blue Wizard";
                abilityButtonTwoInfo.text = "Deal " + yellowAbilitiesInfo[0].ToString() + " Damage to Red Wizard";
                abilityButtonThreeInfo.text = "Deal " + yellowAbilitiesInfo[1].ToString() + " Damage to all others";
                break;
            case "Blue Wizard":
                abilityButtonOneText.text = blueAbilitiesNames[0] + " towards Yellow Wizard";
                abilityButtonTwoText.text = blueAbilitiesNames[0] + " towards Red Wizard";
                abilityButtonThreeText.text = blueAbilitiesNames[1];
                abilityButtonOneInfo.text = "Deal " + blueAbilitiesInfo[0].ToString() + " Damage to Yellow Wizard";
                abilityButtonTwoInfo.text = "Deal " + blueAbilitiesInfo[0].ToString() + " Damage to Red Wizard";
                abilityButtonThreeInfo.text = "Deal " + blueAbilitiesInfo[1].ToString() + " Damage to all others";
                break;
            case "Red Wizard":
                abilityButtonOneText.text = redAbilitiesNames[0] + " towards Yellow Wizard";
                abilityButtonTwoText.text = redAbilitiesNames[0] + " towards Blue Wizard";
                abilityButtonThreeText.text = redAbilitiesNames[1];
                abilityButtonOneInfo.text = "Deal " + redAbilitiesInfo[0].ToString() + " Damage to Yellow Wizard";
                abilityButtonTwoInfo.text = "Deal " + redAbilitiesInfo[0].ToString() + " Damage to Blue Wizard";
                abilityButtonThreeInfo.text = "Deal " + redAbilitiesInfo[1].ToString() + " Damage to all others";
                break;

        }
        if (phases == 0)
        {
            activeChar = currentBody;
            infoText.text = "Choose an ability!";
        }
        else if (phases == 1)
        {
            infoText.text = activeChar + " uses " ;
            if (timer > 0) 
            {
                timer -= Time.deltaTime;
            }

            if (timer <= 0)
            {
                timer = timerLimit;
                phases = 2;
            }
        }
        else if (phases == 2)
        {

        }
    }
    public void UseAbility(int chosenAbility)
    {
        if (phases == 0)
        {

            switch (activeChar)
            {
                case "Yellow Wizard":
                    switch (chosenAbility)
                    {
                        case 0:
                            blueHealth -= yellowAbilitiesInfo[0];
                            break;
                        case 1:
                            redHealth -= yellowAbilitiesInfo[0];
                            break;
                        case 2:
                            blueHealth -= yellowAbilitiesInfo[1];
                            redHealth -= yellowAbilitiesInfo[1];
                            break;
                    }
                    break;
                case "Blue Wizard":
                    switch (chosenAbility)
                    {
                        case 0:
                            yellowHealth -= blueAbilitiesInfo[0];
                            break;
                        case 1:
                            redHealth -= blueAbilitiesInfo[0];
                            break;
                        case 2:
                            yellowHealth -= blueAbilitiesInfo[1];
                            redHealth -= blueAbilitiesInfo[1];
                            break;
                    }
                    break;
                case "Red Wizard":
                    switch (chosenAbility)
                    {
                        case 0:
                            yellowHealth -= redAbilitiesInfo[0];
                            break;
                        case 1:
                            blueHealth -= redAbilitiesInfo[0];
                            break;
                        case 2:
                            yellowHealth -= redAbilitiesInfo[1];
                            blueHealth -= redAbilitiesInfo[1];
                            break;
                    }
                    break;
            }
            timer = timerLimit;
            Debug.Log(timer+"new");
            phases = 1;
        }
    }
    public void OthersAbility()
    {
        string[] remainingWizards = { };
    }
    public void nextTurn()
    {
        // find if need to switch body, if yes, do so
        turnsBeforeChange -= 1;
        if (turnsBeforeChange <= 0)
        {
            currentBody = nextBody;
            findNextBody();
        }
    }
    public void findNextBody()
    {
        int nextBodyNumber = Random.Range(0, 3);
        while (nextBodyNumber == currentBodyNumber)
        {
            nextBodyNumber = Random.Range(0, 3);
        }
        nextBody = wizardsList[nextBodyNumber];
    }
    public void AbilityHappen()
    {

    }
}
