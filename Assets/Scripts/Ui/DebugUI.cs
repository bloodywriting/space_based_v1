using TMPro;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    [Header("UI Debug Displays")]
    public TMP_Text lastSpawnTimeStat;
    public TMP_Text timeStat;
    public TMP_Text S1ArmorStat;
    public TMP_Text S1ArmorPlusStat;
    public TMP_Text S1SpeedStat;
    public TMP_Text S1SpeedPlusStat;
    public TMP_Text S2ArmorStat;
    public TMP_Text S2ArmorPlusStat;
    public TMP_Text S2SpeedStat;
    public TMP_Text S2SpeedPlusStat;
    public TMP_Text S3ForkStat;
    public TMP_Text S3GrowStat;

    // Update is called once per frame
    void Update()
    {
        DebugStaticSkillBools();
        Debugger();
        timeStat.text = Time.time.ToString();
        lastSpawnTimeStat.text = GM.LastShip1SpawnTime.ToString();
    }
    private void Debugger()
    {
        /*
        Debug.Log("/d Time: " + Time.time);
        Debug.Log("/d LastShip1SpawnTime: " + GM.LastShip1SpawnTime);
        Debug.Log("/d LastShip2SpawnTime: " + GM.LastShip2SpawnTime);
        Debug.Log("/d LastShip3SpawnTime: " + GM.LastShip3SpawnTime);
        Debug.Log("/d Ship1SpawnCooldown: " + GM.Ship1SpawnCooldown);
        Debug.Log("/d Ship2SpawnCooldown: " + GM.Ship2SpawnCooldown);
        Debug.Log("/d Ship3SpawnCooldown: " + GM.Ship3SpawnCooldown);

        if (launchShip != null)
        {
            Debug.Log("LastShipSpawnTime: " + GM.lastSpawnTime);
            Debug.Log("SpawnerCooldown: " + launchShip.spawnCooldown);
        }
        else
        {
            Debug.LogError("LaunchShip is null");
        }
        */
    }


    // Checks the state of static skill bools, updating the /d UI GameObjects
    void DebugStaticSkillBools()
    {
        // Check S1Armor
        if (GM.S1Armor == true)
        {
            Debug.Log("S1Armor is true");
            S1ArmorStat.text = "T";
        }
        else if (GM.S1Armor == false)
        {
            Debug.Log("S1Armor is false");
            S1ArmorStat.text = "F";
        }
        else
        {
            Debug.Log("S1Armor is error");
            S1ArmorStat.text = "Er";
        }

        // Check S1ArmorPlus
        if (GM.S1ArmorPlus == true)
        {
            S1ArmorPlusStat.text = "T";
            Debug.Log("S1ArmorPlus is true");
        }
        else if (GM.S1ArmorPlus == false)
        {
            Debug.Log("S1ArmorPlus is false");
            S1ArmorPlusStat.text = "F";
        }
        else
        {
            Debug.Log("S1ArmorPlus is error");
            S1ArmorPlusStat.text = "Er";
        }

        // Check S1Speed
        if (GM.S1Speed == true)
        {
            Debug.Log("S1Speed is true");
            S1SpeedStat.text = "T";
        }
        else if (GM.S1Speed == false)
        {
            Debug.Log("S1Speed is false");
            S1SpeedStat.text = "F";
        }
        else
        {
            Debug.Log("S1Speed is error");
            S1SpeedStat.text = "Er";
        }

        // Check S1SpeedPlus
        if (GM.S1SpeedPlus == true)
        {
            Debug.Log("S1SpeedPlus is true");
            S1SpeedPlusStat.text = "T";
        }
        else if (GM.S1SpeedPlus == false)
        {
            Debug.Log("S1SpeedPlus is false");
            S1SpeedPlusStat.text = "F";
        }
        else
        {
            Debug.Log("S1SpeedPlus is error");
            S1SpeedPlusStat.text = "Er";
        }

        // Check S2Armor
        if (GM.S2Armor == true)
        {
            Debug.Log("S2Armor is true");
            S2ArmorStat.text = "T";

        }
        else if (GM.S2Armor == false)
        {
            Debug.Log("S2Armor is false");
            S2ArmorStat.text = "F";
        }
        else
        {
            Debug.Log("S2Armor is error");
            S2ArmorStat.text = "Er";
        }

        // Check S2ArmorPlus
        if (GM.S2ArmorPlus == true)
        {
            Debug.Log("S2ArmorPlus is true");
            S2ArmorPlusStat.text = "T";
        }
        else if (GM.S2ArmorPlus == false)
        {
            Debug.Log("S2ArmorPlus is false");
            S2ArmorPlusStat.text = "F";
        }
        else
        {
            Debug.Log("S2ArmorPlus is error");
            S2ArmorPlusStat.text = "Er";
        }

        // Check S2Speed
        if (GM.S2Speed == true)
        {
            Debug.Log("S2Speed is true");
            S2SpeedStat.text = "T";
        }
        else if (GM.S2Speed == false)
        {
            Debug.Log("S2Speed is false");
            S2SpeedStat.text = "F";
        }
        else
        {
            Debug.Log("S2Speed is error");
            S2SpeedStat.text = "Er";
        }

        // Check S2SpeedPlus
        if (GM.S2SpeedPlus == true)
        {
            Debug.Log("S2SpeedPlus is true");
            S2SpeedPlusStat.text = "T";
        }
        else if (GM.S2SpeedPlus == false)
        {
            Debug.Log("S2SpeedPlus is false");
            S2SpeedPlusStat.text = "F";
        }
        else
        {
            Debug.Log("S2SpeedPlus is error");
            S2SpeedPlusStat.text = "Er";
        }

        // Check S3Fork
        if (GM.S3Fork == true)
        {
            Debug.Log("S3Fork is true");
            S3ForkStat.text = "T";
        }
        else if (GM.S3Fork == false)
        {
            Debug.Log("S3Fork is false");
            S3ForkStat.text = "F";
        }
        else
        {
            Debug.Log("S3Fork is error");
            S3ForkStat.text = "Er";
        }

        // Check S3Grow
        if (GM.S3Grow == true)
        {
            Debug.Log("S3Grow is true");
            S3GrowStat.text = "T";
        }
        else if (GM.S3Grow == false)
        {
            Debug.Log("S3Grow is false");
            S3GrowStat.text = "F";
        }
        else
        {
            Debug.Log("S3Grow is error");
            S3GrowStat.text = "Er";
        }
    }
}
