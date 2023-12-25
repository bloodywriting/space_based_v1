using UnityEngine;

public class SkillLibrary : MonoBehaviour
{
    public static string[] skillNameArray = new string[] { "S1Armor", "S1ArmorPlus", "S1Speed", "S1SpeedPlus", "S2Armor", "S2ArmorPlus", "S2Speed", "S2SpeedPlus", "S3Fork", "S3Grow" };

    // Update is called once per frame
    void Update()
    {
        S1ArmorFunc();
        S1ArmorPlusFunc();
        S1SpeedFunc();
        S1SpeedPlusFunc();
        S2ArmorFunc();
        S2ArmorPlusFunc();
        S2SpeedFunc();
        S2SpeedPlusFunc();
        S3GrowFunc();
    }

    // Library of skills
    public void S1ArmorFunc()
    {
        if (GM.S1Armor)
        {
            GM.Ship1ArmorStat += 1;
        }
    }

    public void S1ArmorPlusFunc()
    {
        if (GM.S1ArmorPlus)
        {
            GM.Ship1ArmorStat += 3;
        }
    }

    public void S1SpeedFunc()
    {
        if (GM.S1Speed)
        {
            GM.Ship1SpeedStat += 0.5f;
        }
    }

    public void S1SpeedPlusFunc()
    {
        if (GM.S1SpeedPlus)
        {
            GM.Ship1SpeedStat += 1.2f;
        }
    }

    public void S2ArmorFunc()
    {
        if (GM.S2Armor)
        {
            GM.Ship2ArmorStat += 2;
        }
    }

    public void S2ArmorPlusFunc()
    {
        if (GM.S2ArmorPlus)
        {
            GM.Ship2ArmorStat += 4;
        }
    }

    public void S2SpeedFunc()
    {
        if (GM.S2Speed)
        {
            GM.Ship2SpeedStat += 0.5f;
        }
    }

    public void S2SpeedPlusFunc()
    {
        if (GM.S2SpeedPlus)
        {
            GM.Ship2SpeedStat += 1.5f;
        }
    }

    public void S3GrowFunc()
    {
        if (GM.S3Grow)
        {
            GM.Ship3GrowthStat += 0.3f;
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
}
