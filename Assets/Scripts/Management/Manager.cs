using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [Header("Game UI")]
    public TMP_Text shipsLandedStat;
    public TMP_Text alienInvadersStat;
    public TMP_Text LevelDisplay;
    public GameObject VictoryText;
    public GameObject LossText;
    public GameObject ResetButton;
    public GameObject AdvanceButton;
    public GameObject GreyedOut;

    [Header("Skill UI")]
    public Image skill2ButtonUI;
    public Image skill1ButtonUI;
    public Image skill1Button;
    public Image skill2Button;
    public Image Ship1Skill1;
    public Image Ship1Skill2;
    public Image Ship2Skill1;
    public Image Ship2Skill2;
    public Image Ship3Skill1;
    public Image Ship3Skill2;
     
    [Header("Base Ship Stats")]
    public int Ship1ArmorStat;
    public int Ship2ArmorStat;
    public float Ship1SpeedStat;
    public float Ship2SpeedStat;

    // Game variables
    float currentTimeScale;
    string gameStage;
    bool victoryBool = false;
    bool lossBool = false;
    int lastLevel = 0;
    bool test;

    // Skill variables
    int generatedSkill1;
    int generatedSkill2;
    string[] skillNameArray;


    void Start()
    {
        gameStage = "playing";
        Debug.Log("Game is playing");

        // Called a single time during the start of the first level
        if (GM.InitBool == false)
        {
            GM.InitGame();
            Debug.Log("Init Called!");
        }

        // Set UI elements Inactive
        VictoryText.SetActive(false);
        LossText.SetActive(false);
        ResetButton.SetActive(false);
        AdvanceButton.SetActive(false);
        GreyedOut.SetActive(false);

        // Ensure ships & aliens srat as 0 for each scene
        GM.AlienInvaders = 0;
        GM.ShipsAcross = 0;

        // Link local skillNameArray with public skillLibrary one
        skillNameArray = SkillLibrary.skillNameArray;

        // Ensure Skill UI is not active on scene start
        skill1ButtonUI.gameObject.SetActive(false);
        skill2ButtonUI.gameObject.SetActive(false);
        skill1Button.gameObject.SetActive(false);
        skill2Button.gameObject.SetActive(false);

        // Call OnStart functions
        CheckScene();
        GenerateSkills();


    }
    void Update()
    {
        CheckScene();
        EndGame();
        ControlEndScene();
        SetUnlockedSkillSlotsActive();
        UpdateSkillDislpays();

        shipsLandedStat.text = GM.ShipsAcross.ToString();
        alienInvadersStat.text = GM.AlienInvaders.ToString();
        LevelDisplay.text = GM.CurrentLevel.ToString();

        currentTimeScale = Time.timeScale;

        if (currentTimeScale == 0f)
        {
            Debug.Log("Game is paused");
        }
        else if (currentTimeScale >= 2f)
        {
            Debug.LogError("TimeScale is higher than 2");
        }
        else
        {
           // Debug.Log("Game is running");
        }
    }

    //// Game Functions ////
    void EndGame()
    {
        if (victoryBool)
        {
            return;
        }
        else
        {
            // Check the game conditions
            if (GM.ShipsAcross >= 10 && GM.CurrentLevel != 4)
            {
                gameStage = "victory";
                Time.timeScale = 0;
                Debug.Log("Victory!");
                victoryBool = true;
            }
            else if (GM.ShipsAcross >= 10 && GM.CurrentLevel == 4)
            {
                Time.timeScale = 0;
                GreyedOut.SetActive(true);
                VictoryText.SetActive(true);
                ResetButton.SetActive(true);
                Debug.Log("Final Victory!");
                victoryBool = true;
            }
        }
        if (lossBool)
        {
            return;
        }
        else
        {
            if (GM.AlienInvaders >= 10)
            {
                GreyedOut.SetActive(true);
                LossText.SetActive(true);
                Time.timeScale = 0;
                ResetButton.SetActive(true);
                Debug.Log("Loss!");
                lossBool = true;
            }
        }
    }

    void ControlEndScene()
    {
        switch (gameStage)
        {
            case "victory":
                GreyedOut.SetActive(true);
                VictoryText.SetActive(true);
                AdvanceButton.SetActive(true);
                break;
            case "skill selection":
                GreyedOut.SetActive(true);
                VictoryText.SetActive(false);
                AdvanceButton.SetActive(false);
                break;
        }
    }

    // Checks current scene, updates static level variable, and debugs when level changes
    void CheckScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        GM.CurrentLevel = int.Parse(currentScene.name);

        if (lastLevel != GM.CurrentLevel)
        {
        Debug.Log($"Level is currently {GM.CurrentLevel}");
            lastLevel = GM.CurrentLevel;
        }
    }

    void GenerateSkills()
    {
        System.Random random = new System.Random();

        // Generate two random integers within a given range
        switch (GM.CurrentLevel)
        {
            case 1:
                // Generates only S1 skills, index 0-3
                generatedSkill1 = random.Next(0, 4);
                generatedSkill2 = random.Next(0, 4);

                // If generated skills are equal, increase generated skill 2 by 1
                Debug.Log($"GeneratedSkills: 1: {generatedSkill1}  2: {generatedSkill2}");
                if (generatedSkill1 == generatedSkill2)
                {
                    Debug.Log("Generated Skills the Same");
                    generatedSkill2 = generatedSkill2 + 1;

                    if (generatedSkill2 >= 4)
                    {
                        generatedSkill2 = 0;
                    }
                }
                break;
            case 2:
                // Generates only S1 and S2 skills, index 0-7
                generatedSkill1 = random.Next(0, 8);
                generatedSkill2 = random.Next(0, 8);

                // If generated skills are equal, increase generated skill 2 by 2
                Debug.Log($"GeneratedSkills: 1: {generatedSkill1}  2: {generatedSkill2}");
                if (generatedSkill1 == generatedSkill2)
                {
                    Debug.Log("Generated Skills the Same");
                    generatedSkill2 += 2;

                    if (generatedSkill2 >= 8)
                    {
                        generatedSkill2 = 0;
                    }
                }

                // If generated skill 1 is already obtained, increase generated skill 1 by 1
                if (generatedSkill1 == GM.unlockedSkills[0])
                {
                    Debug.Log("Generated skill 1 already unlocked");
                    generatedSkill1 += generatedSkill1 + 1;
                }

                // If generated skill 2 is already obtained, increase generated skill 2 by 1
                if (generatedSkill2 == GM.unlockedSkills[0])
                {
                    Debug.Log("Generated skill 2 already unlocked");
                    generatedSkill2 += generatedSkill2 + 1;
                }
                break;
            case 3:
                generatedSkill1 = random.Next(4, 10);
                generatedSkill2 = random.Next(4, 10);
                Debug.Log($"GeneratedSkills: 1: {generatedSkill1}  2: {generatedSkill2}");
                if (generatedSkill1 == generatedSkill2)
                {
                    Debug.Log("Generated Skills the Same");
                    generatedSkill1 = generatedSkill1 + 2;

                    if (generatedSkill1 >= 10)
                    {
                        generatedSkill1 = 0;
                    }
                }

                break;
            case 4:
                /*
                generatedSkill1 = random.Next(4, 9);
                generatedSkill2 = random.Next(4, 9);
                if (generatedSkill1 == generatedSkill2)
                {
                    generatedSkill1 = generatedSkill1 + 2;

                    if (generatedSkill1 >= 10)
                    {
                        generatedSkill1 = 0;
                    }
                }
                Debug.Log($"Level: {GM.CurrentLevel}" + $" Skill1: {skillNameArray[generatedSkill1]}" + $" Skill2: {skillNameArray[generatedSkill2]}");
                */
                break;
        }
        Debug.Log($"Level {GM.CurrentLevel} Skills: S1: {skillNameArray[generatedSkill1]} S2: {skillNameArray[generatedSkill2]}");
    }

    // Changes each skill button to the correct image based on skill generation
    void UpdateSkillDislpays()
    {
        skill1Button.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill1]}");
        skill2Button.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill2]}");
    }



    //// Button Functions////

    // OnClick, enables both skill buttons and disables Victory and Advance 
    public void AdvanceButtonFunction()
    {
        Debug.Log("Advance Button Clicked");
        gameStage = "skill selection";
        skill1ButtonUI.gameObject.SetActive(true);
        skill2ButtonUI.gameObject.SetActive(true);
        skill1Button.gameObject.SetActive(true);
        skill2Button.gameObject.SetActive(true);

    }

    //OnClick, restarts game back to level/scene 1
    public void ResetButtonFunction()
    {
        Debug.Log("Reset");
        SceneManager.LoadScene("1");

        if (currentTimeScale == 0f)
        {
            Debug.Log("Game replays");
            Time.timeScale = 1f;
            GM.AlienInvaders = 0;
            GM.ShipsAcross = 0;
            GM.Ship1Spawned = 0;
            GM.Ship2Spawned = 0;
            GM.Ship3Spawned = 0;
            GM.LastShip1SpawnTime = 0;
            GM.LastShip2SpawnTime = 0;
            GM.LastShip3SpawnTime = 0;
        }
    }

    // OnClick, sets chosen generated static skill bool as true, enables skill emblem image and updates it, then loads next scene
    public void SelectSkill1()
    {
        Debug.Log("Skill 1 is selected");

        // Switch to divide cases by scene level, 1-3 are very similar but 4 is not (final level currently)
        switch (GM.CurrentLevel)
        {
            case 1:
                // Set respective skill bool to true and add to unlocked skill array
                GM.skillBoolArray[generatedSkill1] = true;
                GM.AddUnlockedSkill(0, generatedSkill1);

                // Set S1 skill display image to corresponding sprite within Resources then set S1s1 display bool true
                GM.skillDisplayArray[0] = true;
                Ship1Skill1.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill1]}");
                Debug.Log($"Ship1Skill1 sprite is : {Ship1Skill1.sprite}");

                // Load scene 2, reset static invasion variables, set time to 1
                SceneManager.LoadScene("2");
                if (currentTimeScale == 0f)
                {
                    Debug.Log("Game advances");
                    GM.AlienInvaders = 0;
                    GM.ShipsAcross = 0;
                    Time.timeScale = 1f;
                }
                Debug.Log("Load scene 2");
                Debug.Log($"Skill 1 Selected: {skillNameArray[generatedSkill1]}");
                break;

            case 2:
                // Set respective skill bool to true and add to unlocked skill array
                GM.skillBoolArray[generatedSkill1] = true;
                GM.AddUnlockedSkill(1, generatedSkill1);

                // If generated skill 1 is for ship 2, sets skill display image to corresponding sprite within Resources then S2s1 display bool true
                if (generatedSkill1 >= 4 && generatedSkill1 <= 7)
                {
                    GM.skillDisplayArray[2] = true;
                    Ship2Skill1.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill1]}");
                    Debug.Log($"Ship2Skill1 sprite is : {Ship2Skill1.sprite}");
                }

                // Else if generated skill 1 is for ship 1, sets skill display image to corresponding sprite within Resources then S1s2 display bool true
                else if (generatedSkill1 < 4)
                {
                    GM.skillDisplayArray[1] = true;
                    Ship1Skill2.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill1]}");
                    Debug.Log($"Ship1Skill2 sprite is : {Ship1Skill2.sprite}");
                }

                // Load scene 3, reset static invasion variables, set time to 1
                SceneManager.LoadScene("3");
                if (currentTimeScale == 0f)
                {
                    Debug.Log("Game advances");
                    GM.AlienInvaders = 0;
                    GM.ShipsAcross = 0;
                    Time.timeScale = 1f;
                }
                Debug.Log("Load scene 3");
                Debug.Log($"Skill 1 Selected: {skillNameArray[generatedSkill1]}");
                break;

            case 3:
                // Set respective skill bool to true and add to unlocked skill array
                GM.skillBoolArray[generatedSkill1] = true;
                GM.AddUnlockedSkill(2, generatedSkill1);

                // If generated skill 1 is for ship 2 and ship 2 does not have S2s1, sets S2s1 display image to corresponding sprite within Resources then set display bool true
                if (generatedSkill1 >= 4 && generatedSkill1 <= 7 && GM.skillDisplayArray[2] == false)
                {
                    GM.skillDisplayArray[2] = true;
                    Ship2Skill1.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill1]}");
                    Debug.Log($"Ship2Skill1 sprite is : {Ship2Skill1.sprite}");
                }

                // If generated skill 1 is for ship 2 and ship 2 already has a S2s1, sets S2s2 display image to corresponding sprite within Resources then set display bool true
                else if (generatedSkill1 >= 4 && generatedSkill1 <= 7 && GM.skillDisplayArray[2])
                {
                    GM.skillDisplayArray[3] = true;
                    Ship2Skill2.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill1]}");
                    Debug.Log($"Ship2Skill2 sprite is : {Ship2Skill2.sprite}");
                }

                // Else if generated skill 1 is for ship 3, set S3s1 display image to corresponding sprite within Resources then set display bool true
                else if (generatedSkill1 == 8 || generatedSkill1 == 9)
                {
                    GM.skillDisplayArray[4] = true;
                    Ship3Skill1.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill1]}");
                    Debug.Log($"Ship3Skill1 sprite is : {Ship3Skill1.sprite}");
                }

                // Load scene 4, reset static invasion variables, set time to 1
                SceneManager.LoadScene("4");
                if (currentTimeScale == 0f)
                {
                    Debug.Log("Game advances");
                    Time.timeScale = 1f;
                    GM.AlienInvaders = 0;
                    GM.ShipsAcross = 0;
                }
                Debug.Log("Load scene 4");
                Debug.Log($"Skill 1 Selected: {skillNameArray[generatedSkill1]}");
                break;

        }
    }


    public void SelectSkill2()
    {

        Debug.Log("Skill 2 is selected");

        // Switch to divide cases by scene level, 1-3 are very similar but 4 is not (final level currently)
        switch (GM.CurrentLevel)
        {
            case 1:
                // Set respective skill bool to true and add to unlocked skill array
                GM.skillBoolArray[generatedSkill2] = true;
                GM.AddUnlockedSkill(0, generatedSkill2);
                // Set S1 skill display image to corresponding sprite within Resources then set S1s1 display bool true
                GM.skillDisplayArray[0] = true;
                Ship1Skill1.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill2]}");
                Debug.Log($"Ship1Skill1 sprite is : {Ship1Skill1.sprite}");

                // Load scene 2, reset static invasion variables, set time to 1
                SceneManager.LoadScene("2");
                if (currentTimeScale == 0f)
                {
                    Debug.Log("Game advances");
                    GM.AlienInvaders = 0;
                    GM.ShipsAcross = 0;
                    Time.timeScale = 1f;
                }
                Debug.Log("Load scene 2");
                Debug.Log($"Skill 2 Selected: {skillNameArray[generatedSkill2]}");
                break;

            case 2:
                // Set respective skill bool to true and add to unlocked skill array
                GM.skillBoolArray[generatedSkill2] = true;
                GM.AddUnlockedSkill(1, generatedSkill2);

                // If generated skill 1 is for ship 2, sets skill display image to corresponding sprite within Resources then S2s1 display bool true
                if (generatedSkill2 >= 4 && generatedSkill2 <= 7)
                {
                    GM.skillDisplayArray[2] = true;
                    Ship2Skill1.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill2]}");
                    Debug.Log($"Ship2Skill1 sprite is : {Ship2Skill1.sprite}");
                }

                // Else if generated skill 1 is for ship 1, sets skill display image to corresponding sprite within Resources then S1s2 display bool true
                else if (generatedSkill2 < 4)
                {
                    GM.skillDisplayArray[1] = true;
                    Ship1Skill2.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill2]}");
                    Debug.Log($"Ship1Skill2 sprite is : {Ship1Skill2.sprite}");
                }

                // Load scene 3, reset static invasion variables, set time to 1
                SceneManager.LoadScene("3");
                if (currentTimeScale == 0f)
                {
                    Debug.Log("Game advances");
                    GM.AlienInvaders = 0;
                    GM.ShipsAcross = 0;
                    Time.timeScale = 1f;
                }
                Debug.Log("Load scene 3");
                Debug.Log($"Skill 2 Selected: {skillNameArray[generatedSkill2]}");
                break;

            case 3:
                // Set respective skill bool to true and add to unlocked skill array
                GM.skillBoolArray[generatedSkill2] = true;
                GM.AddUnlockedSkill(2, generatedSkill2);

                // If generated skill 1 is for ship 2 and ship 2 does not have S2s1, sets S2s1 display image to corresponding sprite within Resources then set display bool true
                if (generatedSkill2 >= 4 && generatedSkill2 <= 7 && GM.skillDisplayArray[2] == false)
                {
                    GM.skillDisplayArray[2] = true;
                    Ship2Skill1.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill2]}");
                    Debug.Log($"Ship2Skill1 sprite is : {Ship2Skill1.sprite}");
                }

                // If generated skill 1 is for ship 2 and ship 2 already has a S2s1, sets S2s2 display image to corresponding sprite within Resources then set display bool true
                else if (generatedSkill2 >= 4 && generatedSkill2 <= 7 && GM.skillDisplayArray[2])
                {
                    GM.skillDisplayArray[3] = true;
                    Ship2Skill2.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill2]}");
                    Debug.Log($"Ship2Skill2 sprite is : {Ship2Skill2.sprite}");
                }

                // Else if generated skill 1 is for ship 3, set S3s1 display image to corresponding sprite within Resources then set display bool true
                else if (generatedSkill2 == 8 || generatedSkill2 == 9)
                {
                    GM.skillDisplayArray[4] = true;
                    Ship3Skill1.sprite = Resources.Load<Sprite>($"Sprites/{skillNameArray[generatedSkill2]}");
                    Debug.Log($"Ship3Skill1 sprite is : {Ship3Skill1.sprite}");
                }

                // Load scene 4, reset static invasion variables, set time to 1
                SceneManager.LoadScene("4");
                if (currentTimeScale == 0f)
                {
                    Debug.Log("Game advances");
                    Time.timeScale = 1f;
                    GM.AlienInvaders = 0;
                    GM.ShipsAcross = 0;
                }
                Debug.Log("Load scene 4");
                Debug.Log($"Skill 2 Selected: {skillNameArray[generatedSkill2]}");
                break;
        }
    }

    //// Skill code////

    // Checks if Skill Display Bools are unlocked and sets appropriate UI displays active, if already active, it does nothing to them
    void SetUnlockedSkillSlotsActive()
    {
        if (Ship1Skill1.isActiveAndEnabled)
        {

        }
        else if (GM.skillDisplayArray[0] == true)
        {
            Ship1Skill1.gameObject.SetActive(true);
        }

        if (Ship1Skill2.isActiveAndEnabled)
        {

        }
        else if (GM.skillDisplayArray[1] == true)
        {
            Ship1Skill2.gameObject.SetActive(true);
        }

        if (Ship2Skill1.isActiveAndEnabled)
        {

        }
        else if (GM.skillDisplayArray[2] == true)
        {
            Ship2Skill1.gameObject.SetActive(true);
        }

        if (Ship2Skill2.isActiveAndEnabled)
        {

        }
        else if (GM.skillDisplayArray[3] == true)
        {
            Ship2Skill2.gameObject.SetActive(true);
        }

        if (Ship3Skill1.isActiveAndEnabled)
        {

        }
        else if (GM.skillDisplayArray[4] == true)
        {
            Ship3Skill1.gameObject.SetActive(true);
        }

        if (Ship3Skill2.isActiveAndEnabled)
        {

        }
        else if (GM.skillDisplayArray[5] == true)
        {
            Ship3Skill2.gameObject.SetActive(true);
        }
    }
}
/* Array Order
* 
* 0 S1Armor
* 1 S1ArmorPlus
* 2 S1Speed
* 3 S1SpeedPlus
* 4 S2Armor
* 5 S2ArmorPlus
* 6 S2Speed 
* 7 S2SpeedPlus
* 8 S3Fork
* 9 S3Grow
* 
*/

/* left off:
 * 
 * Using debug displays, seems like GM.SkillBools are not being changed
 * 
 * skill displays retaining after each level but images are incorrect (mostly S1A)
 * 
 * Edgeb case found, final level ships landed and alien invaders were > 10 ai=11 sl=10, both victory and loss activated, dont know if possible each level
 * 
 * on loss need to reset skill bools before reload
 * \\\\\\\\\\\\\
 * 
 */


