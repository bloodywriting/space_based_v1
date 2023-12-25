using UnityEngine;

public static class GM
{
    //// Static class maintaing all static variables persistent across scripts and scenes
    
    // Game variables
    public static int ShipsAcross;
    public static int AlienInvaders;
    public static int CurrentLevel;
    public static bool InitBool;

    // Spawning variables
    public static int Ship1Spawned;
    public static int Ship2Spawned;
    public static int Ship3Spawned;
    public static float LastShip1SpawnTime;
    public static float LastShip2SpawnTime;
    public static float LastShip3SpawnTime;
    public static float Ship1SpawnCooldown;
    public static float Ship2SpawnCooldown;
    public static float Ship3SpawnCooldown;

    // Ship variables
    public static int Ship1ArmorStat;
    public static float Ship1SpeedStat;
    public static int Ship2ArmorStat;
    public static float Ship2SpeedStat;
    public static float Ship3GrowthStat;

    public static void InitGame()
    {
        // Game variables
        ShipsAcross = 0;
        AlienInvaders = 0;
        CurrentLevel = 0;

        // Spawning variables
        Ship1Spawned = 0;
        Ship2Spawned = 0;
        Ship3Spawned = 0;
        LastShip1SpawnTime = 0;
        LastShip2SpawnTime = 0;
        LastShip3SpawnTime = 0;
        Ship1SpawnCooldown = 0;
        Ship2SpawnCooldown = 0;
        Ship3SpawnCooldown = 0;

        // Ship variables
        Ship1ArmorStat = 0;
        Ship1SpeedStat = 0;
        Ship2ArmorStat = 0;
        Ship2SpeedStat = 0;
        Ship3GrowthStat = 0;

        // Skill variables
        S1Armor = false;
        S1ArmorPlus = false;
        S1Speed = false;
        S1SpeedPlus = false;
        S2Armor = false;
        S2ArmorPlus = false;
        S2Speed = false;
        S2SpeedPlus = false;
        S3Fork = false;
        S3Grow = false;
        Ship1Skill1Obtained = false;
        Ship1Skill2Obtained = false;
        Ship2Skill1Obtained = false;
        Ship2Skill2Obtained = false;
        Ship3Skill1Obtained = false;
        Ship3Skill2Obtained = false;

        // Once set to to true, Init will not be called again on each scene load after level 1
        InitBool = true;
    }

    //// Game variables
    public static void shipsAcross(int points)
    {
        ShipsAcross += points;
    }
    public static void alienInvaded(int points)
    {
        AlienInvaders += points;
    }
    public static void currentLevel(int points)
    {
        CurrentLevel += points;
    }
    public static void initBool(bool value)
    {
        InitBool = value;
    }

    //// Spawning variables
    public static void ship1Spawned(int points)
    {
        Ship1Spawned += points;
    }
    public static void ship2Spawned(int points)
    {
        Ship2Spawned += points;
    }
    public static void ship3Spawned(int points)
    {
        Ship3Spawned += points;
    }
    public static void lastShip1SpawnTime(float points)
    {
        LastShip1SpawnTime += points;
    }
    public static void lastShip2SpawnTime(float points)
    {
        LastShip2SpawnTime += points;
    }
    public static void lastShip3SpawnTime(float points)
    {
        LastShip3SpawnTime += points;
    }
    public static void ship1SpawnCooldown(float points)
    {
        Ship1SpawnCooldown += points;
    }
    public static void ship2SpawnCooldown(float points)
    {
        Ship2SpawnCooldown += points;
    }
    public static void ship3SpawnCooldown(float points)
    {
        Ship3SpawnCooldown += points;
    }

    //// Ship variables
    public static void ship1ArmorStat(int points)
    {
        Ship1ArmorStat += points;
    }
    public static void ship1SpeedStat(float points)
    {
        Ship1SpeedStat += points;
    }
    public static void ship2ArmorStat(int points)
    {
        Ship2ArmorStat += points;
    }
    public static void ship2SpeedStat(float points)
    {
        Ship2SpeedStat += points;
    }
    public static void ship3GrowthStat(float points)
    {
        Ship3GrowthStat += points;
    }


    //// Skill bools

    public static void s1Armor(bool value)
    {
        S1Armor = value;
    }
    public static void s1ArmorPlus(bool value)
    {
        S1ArmorPlus = value;
    }
    public static void s1Speed(bool value)
    {
        S1Speed = value;
    }
    public static void s1SpeedPlus(bool value)
    {
        S1SpeedPlus = value;
    }
    public static void s2Armor(bool value)
    {
        S2Armor = value;
    }
    public static void s2ArmorPlus(bool value)
    {
        S2ArmorPlus = value;
    }
    public static void s2Speed(bool value)
    {
        S2Speed = value;
    }
    public static void s2SpeedPlus(bool value)
    {
        S2SpeedPlus = value;
    }
    public static void s3Fork(bool value)
    {
        S3Fork = value;
    }
    public static void s3Grow(bool value)
    {
        S3Grow = value;
    }

    private static bool _s1Speed;
    public static bool S1Speed
    {
        get { return _s1Speed; }
        set
        {
            _s1Speed = value;
            UpdateBoolArray();
        }
    }

    private static bool _s1Armor;
    public static bool S1Armor
    {
        get { return _s1Armor; }
        set
        {
            _s1Armor = value;
            UpdateBoolArray();
        }
    }

    private static bool _s1ArmorPlus;
    public static bool S1ArmorPlus
    {
        get { return _s1ArmorPlus; }
        set
        {
            _s1ArmorPlus = value;
            UpdateBoolArray();
        }
    }

    private static bool _s1SpeedPlus;
    public static bool S1SpeedPlus
    {
        get { return _s1SpeedPlus; }
        set
        {
            _s1SpeedPlus = value;
            UpdateBoolArray();
        }
    }

    private static bool _s2Armor;
    public static bool S2Armor
    {
        get { return _s2Armor; }
        set
        {
            _s2Armor = value;
            UpdateBoolArray();
        }
    }

    private static bool _s2ArmorPlus;
    public static bool S2ArmorPlus
    {
        get { return _s2ArmorPlus; }
        set
        {
            _s2ArmorPlus = value;
            UpdateBoolArray();
        }
    }

    private static bool _s2Speed;
    public static bool S2Speed
    {
        get { return _s2Speed; }
        set
        {
            _s2Speed = value;
            UpdateBoolArray();
        }
    }

    private static bool _s2SpeedPlus;
    public static bool S2SpeedPlus
    {
        get { return _s2SpeedPlus; }
        set
        {
            _s2SpeedPlus = value;
            UpdateBoolArray();
        }
    }

    private static bool _s3Fork;
    public static bool S3Fork
    {
        get { return _s3Fork; }
        set
        {
            _s3Fork = value;
            UpdateBoolArray();
        }
    }

    private static bool _s3Grow;
    public static bool S3Grow
    {
        get { return _s3Grow; }
        set
        {
            _s3Grow = value;
            UpdateBoolArray();
        }
    }

    //// Skill Emblem bools

    public static void ship1Skill1Obtained(bool value)
    {
        Ship1Skill1Obtained = value;
    }
    public static void ship1Skill2Obtained(bool value)
    {
        Ship1Skill2Obtained = value;
    }
    public static void ship2Skill1Obtained(bool value)
    {
        Ship2Skill1Obtained = value;
    }
    public static void ship2Skill2Obtained(bool value)
    {
        Ship2Skill2Obtained = value;
    }
    public static void ship3Skill1Obtained(bool value)
    {
        Ship3Skill1Obtained = value;
    }
    public static void ship3Skill2Obtained(bool value)
    {
        Ship3Skill2Obtained = value;
    }

    private static bool _ship1Skill1Obtained;
    public static bool Ship1Skill1Obtained
    {
        get { return _ship1Skill1Obtained; }
        set
        {
            _ship1Skill1Obtained = value;
            UpdateSkillDisplayArray();
        }
    }

    private static bool _ship1Skill2Obtained;
    public static bool Ship1Skill2Obtained
    {
        get { return _ship1Skill2Obtained; }
        set
        {
            _ship1Skill2Obtained = value;
            UpdateSkillDisplayArray();
        }
    }

    private static bool _ship2Skill1Obtained;
    public static bool Ship2Skill1Obtained
    {
        get { return _ship2Skill1Obtained; }
        set
        {
            _ship2Skill1Obtained = value;
            UpdateSkillDisplayArray();
        }
    }

    private static bool _ship2Skill2Obtained;
    public static bool Ship2Skill2Obtained
    {
        get { return _ship2Skill2Obtained; }
        set
        {
            _ship2Skill2Obtained = value;
            UpdateSkillDisplayArray();
        }
    }

    private static bool _ship3Skill1Obtained;
    public static bool Ship3Skill1Obtained
    {
        get { return _ship3Skill1Obtained; }
        set
        {
            _ship3Skill1Obtained = value;
            UpdateSkillDisplayArray();
        }
    }

    private static bool _ship3Skill2Obtained;
    public static bool Ship3Skill2Obtained
    {
        get { return _ship3Skill2Obtained; }
        set
        {
            _ship3Skill2Obtained = value;
            UpdateSkillDisplayArray();
        }
    }

    //// Static arrays declared

    // The array representing the current state of static skill bools (index of 9)
    public static bool[] skillBoolArray = { S1Armor, S1ArmorPlus, S1Speed, S1SpeedPlus, S2Armor, S2ArmorPlus, S2Speed, S2SpeedPlus, S3Fork, S3Grow };

    // The array representing the current state of static bools (index of 6)
    public static bool[] skillDisplayArray = { Ship1Skill1Obtained, Ship1Skill2Obtained, Ship2Skill1Obtained, Ship2Skill2Obtained, Ship3Skill1Obtained, Ship3Skill2Obtained };

    // The array representing which skills habe been unlocked (index up to 9)
    public static int[] unlockedSkills = new int[9];


    //// Methods to update static arrays 

    // Method to update the boolArray when static bools change
    private static void UpdateBoolArray()
    {
        skillBoolArray = new bool[] { S1Armor, S1ArmorPlus, S1Speed, S1SpeedPlus, S2Armor, S2ArmorPlus, S2Speed, S2SpeedPlus, S3Fork, S3Grow };
    }

    // Method to update the boolArray when static bools change
    private static void UpdateSkillDisplayArray()
    {
        skillDisplayArray = new bool[] { Ship1Skill1Obtained, Ship1Skill2Obtained, Ship2Skill1Obtained, Ship2Skill2Obtained, Ship3Skill1Obtained, Ship3Skill2Obtained };
    }

    // Method to update the unlockedSkills array
    public static void AddUnlockedSkill(int index, int newSkill)
    {
        if (index >= 0 && index < unlockedSkills.Length)
        {
            unlockedSkills[index] = newSkill;
        }
        else
        {
            Debug.Log("Invalid index assigned to unlocked skill array");
        }
    }
    // 0-3 S1, 4-7 S2, 8-9 S3
}
