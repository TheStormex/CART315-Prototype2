using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
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

    public string nextBody = "This wizard";
    public string currentBody;
    public int currentBodyNumber;
    // all wizard characters, if one is dead, the list is recreated without it. (trying the list type)
    List<string> wizardsList = new List<string>();
    public string wizardToRemove;
    public static bool win = true;
    int wizardIndex;
    int nextBodyNumber;
    bool redWizardAlive = true;
    bool blueWizardAlive = true;
    bool yellowWizardAlive = true;
    // wizard abilities
    string[] yellowAbilitiesNames = { "Rock Throw", "Mudslide", "Earthen Restoration"};
    string[] blueAbilitiesNames = { "Water Blast", "Tsunami", "River's Cleansing"};
    string[] redAbilitiesNames = { "Fireball", "Heat Wave", "Solar Warmth"};
    int[] yellowAbilitiesInfo = {2, 5, 3};
    int[] blueAbilitiesInfo = {3, 2, 5};
    int[] redAbilitiesInfo = {5, 3, 2};

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
    public Text abilityButtonFourText;
    public Text abilityButtonOneInfo;
    public Text abilityButtonTwoInfo;
    public Text abilityButtonThreeInfo;
    public Text abilityButtonFourInfo;
    public Text infoText;
    public Object redWizardObject;
    public Object blueWizardObject;
    public Object yellowWizardObject;

    // Start is called before the first frame update
    void Start()
    {
        wizardsList.Add("Yellow Wizard");
        wizardsList.Add("Blue Wizard");
        wizardsList.Add("Red Wizard");
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
        nextBodyText.text = "You'll possess " + nextBody + " next turn.";
        currentWizardText.text = currentBody;
        yellowHealthSlider.value = (float)yellowHealth / (float)yellowMaxHealth;
        blueHealthSlider.value = (float)blueHealth / (float)blueMaxHealth;
        redHealthSlider.value = (float)redHealth / (float)redMaxHealth;
        switch (currentBody)
        {
            case "Yellow Wizard":
                abilityButtonOneText.text = yellowAbilitiesNames[0] + " towards Blue Wizard";
                abilityButtonTwoText.text = yellowAbilitiesNames[0] + " towards Red Wizard";
                abilityButtonThreeText.text = yellowAbilitiesNames[1];
                abilityButtonFourText.text = yellowAbilitiesNames[2];
                abilityButtonOneInfo.text = "Deal " + yellowAbilitiesInfo[0].ToString() + " Damage to Blue Wizard";
                abilityButtonTwoInfo.text = "Deal " + yellowAbilitiesInfo[0].ToString() + " Damage to Red Wizard";
                abilityButtonThreeInfo.text = "Deal " + yellowAbilitiesInfo[1].ToString() + " Damage to all others";
                abilityButtonFourInfo.text = "Heal Self for " + yellowAbilitiesInfo[2].ToString();
                // if the player would die, lose
                if (yellowHealth <= 0)
                {
                    win = false;
                    SceneManager.LoadSceneAsync("End", LoadSceneMode.Single);
                }
                // if is the only one left, win
                if (yellowHealth > 0 && wizardsList.Count == 1)
                {
                    win = true;
                    SceneManager.LoadSceneAsync("End", LoadSceneMode.Single);
                }
                break;
            case "Blue Wizard":
                abilityButtonOneText.text = blueAbilitiesNames[0] + " towards Yellow Wizard";
                abilityButtonTwoText.text = blueAbilitiesNames[0] + " towards Red Wizard";
                abilityButtonThreeText.text = blueAbilitiesNames[1];
                abilityButtonFourText.text = blueAbilitiesNames[2];
                abilityButtonOneInfo.text = "Deal " + blueAbilitiesInfo[0].ToString() + " Damage to Yellow Wizard";
                abilityButtonTwoInfo.text = "Deal " + blueAbilitiesInfo[0].ToString() + " Damage to Red Wizard";
                abilityButtonThreeInfo.text = "Deal " + blueAbilitiesInfo[1].ToString() + " Damage to all others";
                abilityButtonFourInfo.text = "Heal Self for " + blueAbilitiesInfo[2].ToString();
                // if the player would die, lose
                if (blueHealth <= 0)
                {
                    win = false;
                    SceneManager.LoadSceneAsync("End", LoadSceneMode.Single);
                }
                // if is the only one left, win
                if (blueHealth > 0 && wizardsList.Count == 1)
                {
                    win = true;
                    SceneManager.LoadSceneAsync("End", LoadSceneMode.Single);
                }
                break;
            case "Red Wizard":
                abilityButtonOneText.text = redAbilitiesNames[0] + " towards Yellow Wizard";
                abilityButtonTwoText.text = redAbilitiesNames[0] + " towards Blue Wizard";
                abilityButtonThreeText.text = redAbilitiesNames[1];
                abilityButtonFourText.text = redAbilitiesNames[2];
                abilityButtonOneInfo.text = "Deal " + redAbilitiesInfo[0].ToString() + " Damage to Yellow Wizard";
                abilityButtonTwoInfo.text = "Deal " + redAbilitiesInfo[0].ToString() + " Damage to Blue Wizard";
                abilityButtonThreeInfo.text = "Deal " + redAbilitiesInfo[1].ToString() + " Damage to all others";
                abilityButtonFourInfo.text = "Heal Self for " + redAbilitiesInfo[2].ToString();
                // if the player would die, lose
                if (redHealth <= 0)
                {
                    win = false;
                    SceneManager.LoadSceneAsync("End", LoadSceneMode.Single);
                }
                // if is the only one left, win
                if (redHealth > 0 && wizardsList.Count == 1)
                {
                    win = true;
                    SceneManager.LoadSceneAsync("End", LoadSceneMode.Single);
                }
                break;
        }
        // if a wizard would die, remove it from the game
        if (yellowHealth <= 0 && yellowWizardAlive == true)
        {
            yellowWizardAlive = false;
            wizardToRemove = "Yellow Wizard";
            BodyDestroy();
        }
        if (blueHealth <= 0 && blueWizardAlive == true)
        {
            blueWizardAlive = false;
            wizardToRemove = "Blue Wizard";
            BodyDestroy();
        }
        if (redHealth <= 0 && redWizardAlive == true)
        {
            redWizardAlive = false;
            wizardToRemove = "Red Wizard";
            BodyDestroy();
        }
    }
    public void UseAbility(int chosenAbility)
    {
        switch (currentBody)
        {
            case "Yellow Wizard":
                switch (chosenAbility)
                {
                    case 0:
                        if (blueWizardAlive == true)
                        {
                            blueHealth -= yellowAbilitiesInfo[0];
                            NextTurn();
                        }
                        break;
                    case 1:
                        if (redWizardAlive == true)
                        {
                            redHealth -= yellowAbilitiesInfo[0];
                            NextTurn();
                        }
                        break;
                    case 2:
                        if (blueWizardAlive == true)
                        {
                            blueHealth -= yellowAbilitiesInfo[1];
                        }
                        if (redWizardAlive == true)
                        {
                            redHealth -= yellowAbilitiesInfo[1];
                        }
                        NextTurn();
                        break;
                    case 3:
                        yellowHealth += yellowAbilitiesInfo[2];
                        if (yellowHealth >= yellowMaxHealth)
                        {
                            yellowHealth = yellowMaxHealth;
                        }
                        NextTurn();
                        break;
                }
                break;
            case "Blue Wizard":
                switch (chosenAbility)
                {
                    case 0:
                        if (yellowWizardAlive == true)
                        {
                            yellowHealth -= blueAbilitiesInfo[0];
                            NextTurn();
                        }
                        break;
                    case 1:
                        if (redWizardAlive == true)
                        {
                            redHealth -= blueAbilitiesInfo[0];
                            NextTurn();
                        }
                        break;
                    case 2:
                        if (yellowWizardAlive == true)
                        {
                            yellowHealth -= blueAbilitiesInfo[1];
                        }
                        if (redWizardAlive == true)
                        {
                            redHealth -= blueAbilitiesInfo[1];
                        }
                        NextTurn();
                        break;
                    case 3:
                        blueHealth += blueAbilitiesInfo[2];
                        if (blueHealth >= blueMaxHealth)
                        {
                            blueHealth = blueMaxHealth;
                        }
                        NextTurn();
                        break;
                }
                  break;
            case "Red Wizard":
                switch (chosenAbility)
                 {
                    case 0:
                        if (yellowWizardAlive == true)
                        {
                            yellowHealth -= redAbilitiesInfo[0];
                            NextTurn();
                        }
                        break;
                    case 1:
                        if (blueWizardAlive == true)
                        {
                            blueHealth -= redAbilitiesInfo[0];
                            NextTurn();
                        }
                        break;
                    case 2:
                        if (yellowWizardAlive == true)
                        {
                            yellowHealth -= redAbilitiesInfo[1];
                        }
                        if (blueWizardAlive == true)
                        {
                            blueHealth -= redAbilitiesInfo[1];
                        }
                        NextTurn();
                        break;
                    case 3:
                        redHealth += redAbilitiesInfo[2];
                        if (redHealth >= redMaxHealth)
                        {
                            redHealth = redMaxHealth;
                        }
                        NextTurn();
                        break;
                }
                break;

         }
    }
    public void NextTurn()
    {
            currentBody = nextBody;
            currentBodyNumber = nextBodyNumber;
            findNextBody();
    }
    public void findNextBody()
    {
        nextBodyNumber = Random.Range(0, wizardsList.Count);
        nextBody = wizardsList[nextBodyNumber];
    }
    public void BodyDestroy()
    {
        switch (wizardToRemove)
        {
            case "Yellow Wizard":
                yellowHealthText.gameObject.SetActive(false);
                yellowHealthSlider.gameObject.SetActive(false);
                Destroy(yellowWizardObject);
                wizardIndex = wizardsList.IndexOf("Yellow Wizard");
                // if this wizard is next, the player loses
                if (nextBody == "Yellow Wizard")
                {
                    win = false;
                    SceneManager.LoadSceneAsync("End", LoadSceneMode.Single);
                }
                break;
            case "Blue Wizard":
                blueHealthText.gameObject.SetActive(false);
                blueHealthSlider.gameObject.SetActive(false);
                Destroy(blueWizardObject);
                wizardIndex = wizardsList.IndexOf("Blue Wizard");
                // if this wizard is next, the player loses
                if (nextBody == "Blue Wizard")
                {
                    win = false;
                    SceneManager.LoadSceneAsync("End", LoadSceneMode.Single);
                }
                break;
            case "Red Wizard":
                redHealthText.gameObject.SetActive(false);
                redHealthSlider.gameObject.SetActive(false);
                Destroy(redWizardObject);
                wizardIndex = wizardsList.IndexOf("Red Wizard");
                // if this wizard is next, the player loses
                if (nextBody == "Red Wizard")
                {
                    win = false;
                    SceneManager.LoadSceneAsync("End", LoadSceneMode.Single);
                }
                break;
        }
        wizardsList.RemoveAt(wizardIndex);
    }
}
