using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Progress;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}




// Weapon.cs
public enum WeaponType { Sword, Axe, Bow, MagicStaff, Dagger, Hammer, Spear }

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;
    public float damage;
    public float attackSpeed;
    public string weaponName;

    public virtual void Attack()
    {
        // Definice základního útoku
        Debug.Log("Attacking with " + weaponName);
    }
}

public class Sword : Weapon
{
    public float powerStrikeDamage;

    public override void Attack()
    {
        base.Attack();
        Debug.Log("Power Strike with sword, extra damage: " + powerStrikeDamage);
    }
}

public class Bow : Weapon
{
    public int arrowCount;

    public override void Attack()
    {
        base.Attack();
        Debug.Log("Shooting " + arrowCount + " arrows.");
    }
}



// Armor.cs
public enum ArmorType { Light, Medium, Heavy, Magical }

public class Armor : MonoBehaviour
{
    public ArmorType armorType;
    public float protectionValue;
    public string armorName;

    public virtual void Equip()
    {
        Debug.Log("Equipping " + armorName);
    }
}

public class LightArmor : Armor
{
    public override void Equip()
    {
        base.Equip();
        Debug.Log("Light armor equipped. Speed increased!");
    }
}

public class HeavyArmor : Armor
{
    public override void Equip()
    {
        base.Equip();
        Debug.Log("Heavy armor equipped. Defense increased!");
    }
}



// OffhandItem.cs
public enum OffhandType { Shield, Book, Amulet }

public class OffhandItem : MonoBehaviour
{
    public OffhandType offhandType;
    public string itemName;

    public virtual void Use()
    {
        Debug.Log("Using " + itemName);
    }
}

public class Shield : OffhandItem
{
    public float blockValue;

    public override void Use()
    {
        base.Use();
        Debug.Log("Blocking with shield, block value: " + blockValue);
    }
}

public class MagicBook : OffhandItem
{
    public void CastSpell()
    {
        Debug.Log("Casting spell from the magic book.");
    }
}



// Mount.cs
public enum MountType { Horse, Dragon, Mechanical, Unicorn }

public class Mount : MonoBehaviour
{
    public MountType mountType;
    public float speed;
    public string mountName;

    public virtual void MountUp()
    {
        Debug.Log("Mounting " + mountName);
    }
}

public class HorseMount : Mount
{
    public override void MountUp()
    {
        base.MountUp();
        speed = 10f;
        Debug.Log("Speed increased to " + speed + " on Horse!");
    }
}

public class DragonMount : Mount
{
    public override void MountUp()
    {
        base.MountUp();
        speed = 20f;
        Debug.Log("Flying with Dragon! Speed: " + speed);
    }
}



// Potion.cs
public enum PotionType { Health, Mana, Strength }

public class Potion : MonoBehaviour
{
    public PotionType potionType;
    public string potionName;

    public virtual void Use()
    {
        switch (potionType)
        {
            case PotionType.Health:
                Debug.Log("Using Health Potion");
                break;
            case PotionType.Mana:
                Debug.Log("Using Mana Potion");
                break;
            case PotionType.Strength:
                Debug.Log("Using Strength Potion");
                break;
        }
    }
}

// Artifact.cs
public class Artifact : MonoBehaviour
{
    public string artifactName;

    public virtual void ActivateEffect()
    {
        Debug.Log("Activating " + artifactName + " effect.");
    }
}

public class AmuletOfPower : Artifact
{
    public override void ActivateEffect()
    {
        base.ActivateEffect();
        Debug.Log("Increasing strength for a limited time.");
    }
}

public class EyeOfDetection : Artifact
{
    public override void ActivateEffect()
    {
        base.ActivateEffect();
        Debug.Log("Revealing hidden items.");
    }
}




// InventoryManager.cs
public class InventoryManager : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();
    public List<Armor> armors = new List<Armor>();
    public List<OffhandItem> offhandItems = new List<OffhandItem>();
    public List<Mount> mounts = new List<Mount>();
    public List<Potion> potions = new List<Potion>();
    public List<Artifact> artifacts = new List<Artifact>();

    public void EquipWeapon(Weapon weapon)
    {
        Debug.Log("Equipped weapon: " + weapon.weaponName);
    }

    public void EquipArmor(Armor armor)
    {
        Debug.Log("Equipped armor: " + armor.armorName);
    }

    public void UseOffhandItem(OffhandItem offhandItem)
    {
        offhandItem.Use();
    }

    public void MountUp(Mount mount)
    {
        mount.MountUp();
    }

    public void UsePotion(Potion potion)
    {
        potion.Use();
    }

    public void ActivateArtifact(Artifact artifact)
    {
        artifact.ActivateEffect();
    }
}



// Zone.cs
public enum ZoneType { SafeZone, CombatZone, WarZone, AbyssZone, DungeonZone }

public class Zone : MonoBehaviour
{
    public ZoneType zoneType;

    public void EnterZone(Player player)
    {
        switch (zoneType)
        {
            case ZoneType.SafeZone:
                Debug.Log("Entering Safe Zone. PvP is disabled.");
                break;
            case ZoneType.CombatZone:
                Debug.Log("Entering Combat Zone. PvP allowed with penalties.");
                break;
            case ZoneType.WarZone:
                Debug.Log("Entering War Zone. Full PvP enabled.");
                break;
            case ZoneType.AbyssZone:
                Debug.Log("Entering Abyss Zone. Dangerous, full loot.");
                break;
            case ZoneType.DungeonZone:
                Debug.Log("Entering Dungeon Zone. PvP is situational.");
                break;
        }
    }

    public void HandleDeath(Player player, ZoneType deathZone)
    {
        switch (deathZone)
        {
            case ZoneType.SafeZone:
                player.Respawn();
                player.LoseXP(20);
                break;
            case ZoneType.CombatZone:
                player.Respawn();
                player.LoseXP(20);
                player.LoseItems();
                break;
            case ZoneType.WarZone:
                player.Respawn();
                player.LoseXP(20);
                player.LoseAllItems();
                break;
            case ZoneType.AbyssZone:
                player.Respawn();
                player.LoseAllXP();
                player.LoseAllItems();
                break;
            case ZoneType.DungeonZone:
                player.Respawn();
                // Specific dungeon respawn logic
                break;
        }
    }
}

// Player.cs
public class Player : MonoBehaviour
{
    public int xp;
    public List<Item> inventory;

    public void LoseXP(int percentage)
    {
        xp -= (xp * percentage) / 100;
        Debug.Log("Lost " + percentage + "% XP.");
    }

    public void LoseItems()
    {
        inventory.Clear();
        Debug.Log("Lost all items.");
    }

    public void LoseAllItems()
    {
        inventory.Clear();
        Debug.Log("Lost all items and equipment.");
    }

    public void LoseAllXP()
    {
        xp = 0;
        Debug.Log("Lost all XP.");
    }

    public void Respawn()
    {
        Debug.Log("Player respawned.");
        // Respawn player at nearest spawnpoint
    }
}


// FullLootSystem.cs
public class FullLootSystem : MonoBehaviour
{
    public void DropLoot(Player player)
    {
        // Drop all items from the player's inventory when they die
        foreach (Item item in player.inventory)
        {
            Debug.Log("Loot dropped: " + item.itemName);
        }

        player.LoseAllItems();
    }

    public void PickupLoot(Player player, Item item)
    {
        player.inventory.Add(item);
        Debug.Log("Picked up item: " + item.itemName);
    }
}



// FirstKillSystem.cs
public class FirstKillSystem : MonoBehaviour
{
    public delegate void FirstKillEvent(Player player, Enemy enemy);
    public static event FirstKillEvent OnFirstKill;

    private void OnKill(Player player, Enemy enemy)
    {
        if (OnFirstKill != null)
        {
            OnFirstKill.Invoke(player, enemy);
        }
    }

    public void RegisterFirstKill(Player player, Enemy enemy)
    {
        bool isFirstKill = CheckFirstKill(enemy);

        if (isFirstKill)
        {
            Debug.Log("First kill by " + player.name + " on enemy: " + enemy.name);
            // Give first kill reward or bonus to player
        }
    }

    private bool CheckFirstKill(Enemy enemy)
    {
        // Check if this is the first kill of this enemy type (could involve database or kill counters)
        return !enemy.hasBeenKilledBefore;
    }
}



// Quest.cs
public enum QuestType { PvP, PvE, Exploration, Collect }

public class Quest : MonoBehaviour
{
    public QuestType questType;
    public string questName;
    public string questDescription;
    public bool isCompleted;

    public void CompleteQuest(Player player)
    {
        isCompleted = true;
        player.RewardQuest(this);
        Debug.Log("Quest completed: " + questName);
    }

    public void StartQuest(Player player)
    {
        isCompleted = false;
        Debug.Log("Quest started: " + questName);
    }
}



// ReputationSystem.cs
public class ReputationSystem : MonoBehaviour
{
    public enum Reputation { Neutral, Friendly, Hostile }

    public Reputation playerReputation;

    public void UpdateReputation(Player player, bool isHostile)
    {
        if (isHostile)
        {
            playerReputation = Reputation.Hostile;
            Debug.Log("Player is now Hostile.");
        }
        else
        {
            playerReputation = Reputation.Friendly;
            Debug.Log("Player is now Friendly.");
        }
    }

    public void ApplyReputationPenalty(Player player)
    {
        if (playerReputation == Reputation.Hostile)
        {
            Debug.Log("Hostile reputation, penalties applied.");
            // Apply penalties (XP loss, item loss, etc.)
        }
    }
}



// TournamentSystem.cs
public class TournamentSystem : MonoBehaviour
{
    public delegate void TournamentStartEvent();
    public static event TournamentStartEvent OnTournamentStart;

    public void StartTournament()
    {
        if (OnTournamentStart != null)
        {
            OnTournamentStart.Invoke();
        }
        Debug.Log("Tournament started!");
    }
}



// Shop.cs
public class Shop : MonoBehaviour
{
    public List<Item> availableItems;
    public float shopDiscount; // Sleva pro hráèe, kteøí mají vysokou reputaci u obchodu

    public void BuyItem(Player player, Item item)
    {
        if (player.Gold >= item.price)
        {
            player.Gold -= item.price;
            player.inventory.Add(item);
            Debug.Log("Purchased item: " + item.itemName);
        }
        else
        {
            Debug.Log("Not enough gold to buy " + item.itemName);
        }
    }

    public void SellItem(Player player, Item item)
    {
        if (player.inventory.Contains(item))
        {
            player.inventory.Remove(item);
            player.Gold += item.price;
            Debug.Log("Sold item: " + item.itemName);
        }
        else
        {
            Debug.Log("Item not found in inventory.");
        }
    }
}

// Item.cs
public class Item : MonoBehaviour
{
    public string itemName;
    public float price;
    public ItemType itemType;

    public enum ItemType
    {
        Weapon,
        Armor,
        Potion,
        Artifact,
        Mount
    }
}




// EventManager.cs
public class EventManager : MonoBehaviour
{
    public delegate void WorldEvent();
    public static event WorldEvent OnMonsterInvasion;
    public static event WorldEvent OnPvPTournament;

    public void TriggerMonsterInvasion()
    {
        if (OnMonsterInvasion != null)
        {
            OnMonsterInvasion.Invoke();
        }
    }

    public void TriggerPvPTournament()
    {
        if (OnPvPTournament != null)
        {
            OnPvPTournament.Invoke();
        }
    }

    public void StartEvent(string eventType)
    {
        switch (eventType)
        {
            case "MonsterInvasion":
                TriggerMonsterInvasion();
                break;
            case "PvPTournament":
                TriggerPvPTournament();
                break;
            default:
                Debug.Log("Unknown event type.");
                break;
        }
    }
}



// SkillSystem.cs
public class SkillSystem : MonoBehaviour
{
    public enum SkillType { Combat, Crafting, Magic, Gathering }

    public class Skill
    {
        public SkillType skillType;
        public int level;
        public float experience;

        public void GainExperience(float amount)
        {
            experience += amount;
            if (experience >= 100)
            {
                level++;
                experience = 0;
                Debug.Log("Skill leveled up: " + skillType + " to level " + level);
            }
        }
    }

    public Dictionary<SkillType, Skill> skills = new Dictionary<SkillType, Skill>();

    public void InitializeSkills()
    {
        skills[SkillType.Combat] = new Skill { skillType = SkillType.Combat, level = 1, experience = 0 };
        skills[SkillType.Crafting] = new Skill { skillType = SkillType.Crafting, level = 1, experience = 0 };
        skills[SkillType.Magic] = new Skill { skillType = SkillType.Magic, level = 1, experience = 0 };
        skills[SkillType.Gathering] = new Skill { skillType = SkillType.Gathering, level = 1, experience = 0 };
    }

    public void GainSkillExperience(SkillType skillType, float experience)
    {
        if (skills.ContainsKey(skillType))
        {
            skills[skillType].GainExperience(experience);
        }
        else
        {
            Debug.Log("Skill not found: " + skillType);
        }
    }
}


// DailyChallenge.cs
public class DailyChallenge : MonoBehaviour
{
    public string challengeName;
    public string challengeDescription;
    public bool isCompleted;
    public float rewardXP;

    public void StartChallenge()
    {
        isCompleted = false;
        Debug.Log("Challenge started: " + challengeName);
    }

    public void CompleteChallenge(Player player)
    {
        if (!isCompleted)
        {
            isCompleted = true;
            player.GainXP(rewardXP);
            Debug.Log("Challenge completed: " + challengeName);
        }
    }
}

// Player.cs (Extended)
public class Player : MonoBehaviour
{
    public float xp;
    public int gold;

    public void GainXP(float amount)
    {
        xp += amount;
        Debug.Log("Gained XP: " + amount);
    }

    public void GainGold(int amount)
    {
        gold += amount;
        Debug.Log("Gained Gold: " + amount);
    }
}



// Achievement.cs
public class Achievement : MonoBehaviour
{
    public string achievementName;
    public string description;
    public bool isUnlocked;

    public void Unlock()
    {
        if (!isUnlocked)
        {
            isUnlocked = true;
            Debug.Log("Achievement unlocked: " + achievementName);
            // Grant player a reward for unlocking the achievement
        }
    }
}

// AchievementManager.cs
public class AchievementManager : MonoBehaviour
{
    public List<Achievement> achievements = new List<Achievement>();

    public void CheckForAchievement(Player player)
    {
        foreach (var achievement in achievements)
        {
            if (!achievement.isUnlocked)
            {
                // Check specific conditions for unlocking achievements
                achievement.Unlock();
            }
        }
    }
}



// EnemyAI.cs
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float attackRange = 2f;
    public int damage = 10;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            if (distance <= attackRange)
            {
                AttackPlayer();
            }
            else
            {
                ChasePlayer();
            }
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        // Implement attack logic (e.g., damage player)
        Debug.Log("Attacking player for " + damage + " damage.");
    }
}



// QuestManager.cs
public class QuestManager : MonoBehaviour
{
    public enum QuestStatus { InProgress, Completed, Failed }

    public class Quest
    {
        public string questName;
        public QuestStatus status;
        public string description;
        public bool isMainQuest;

        public void CompleteQuest()
        {
            status = QuestStatus.Completed;
            Debug.Log("Quest " + questName + " completed!");
        }

        public void FailQuest()
        {
            status = QuestStatus.Failed;
            Debug.Log("Quest " + questName + " failed.");
        }
    }

    private List<Quest> quests = new List<Quest>();

    public void StartQuest(string questName, bool isMainQuest, string description)
    {
        Quest quest = new Quest { questName = questName, isMainQuest = isMainQuest, description = description, status = QuestStatus.InProgress };
        quests.Add(quest);
        Debug.Log("Quest started: " + questName);
    }

    public void CheckQuestStatus(string questName)
    {
        Quest quest = quests.Find(q => q.questName == questName);
        if (quest != null)
        {
            Debug.Log("Quest " + quest.questName + " is " + quest.status);
        }
        else
        {
            Debug.Log("Quest not found.");
        }
    }
}




// MagicEffect.cs
using UnityEngine;

public class MagicEffect : MonoBehaviour
{
    public ParticleSystem magicParticle;

    public void CastSpell(Vector3 targetPosition)
    {
        magicParticle.transform.position = targetPosition;
        magicParticle.Play();
        Debug.Log("Spell casted at: " + targetPosition);
    }
}




// WeatherManager.cs
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public enum WeatherType { Sunny, Rainy, Snowy, Stormy }

    private WeatherType currentWeather;

    public void ChangeWeather(WeatherType newWeather)
    {
        currentWeather = newWeather;
        UpdateWeatherEffects();
    }

    void UpdateWeatherEffects()
    {
        switch (currentWeather)
        {
            case WeatherType.Sunny:
                Debug.Log("Weather is sunny.");
                break;
            case WeatherType.Rainy:
                Debug.Log("Weather is rainy.");
                // Trigger rain effects (e.g., particles)
                break;
            case WeatherType.Snowy:
                Debug.Log("Weather is snowy.");
                // Trigger snow effects
                break;
            case WeatherType.Stormy:
                Debug.Log("Weather is stormy.");
                // Trigger storm effects (e.g., lightning, high winds)
                break;
        }
    }
}




// EconomySystem.cs
public class EconomySystem : MonoBehaviour
{
    public float baseItemPrice = 100;
    public float supplyDemandMultiplier = 1.2f;

    public float GetItemPrice(Item item)
    {
        return baseItemPrice * supplyDemandMultiplier;
    }

    public void AdjustPricesBasedOnSupplyAndDemand()
    {
        // Dynamically adjust item prices based on in-game events or player actions
        supplyDemandMultiplier = Random.Range(0.8f, 1.5f);
    }
}



// DayNightCycle.cs
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight; // Hlavní svìtelný zdroj (slunce)
    public float dayLength = 480f; // Délka dne v minutách (8 hodin reálného èasu = 480 minut)
    private float timeOfDay = 0f; // Èas ve høe
    private float currentTimeInGame = 0f; // Aktuální èas v reálném svìtì

    public Material skyboxDay;
    public Material skyboxNight;

    public AudioSource dayAmbience;
    public AudioSource nightAmbience;

    void Start()
    {
        // Nastavíme poèáteèní nastavení (denní èas)
        UpdateLighting();
    }

    void Update()
    {
        // Každý snímek aktualizujeme èas hry
        currentTimeInGame += Time.deltaTime;
        if (currentTimeInGame >= 60f) // Každá minuta reálného èasu
        {
            currentTimeInGame = 0f;
            timeOfDay += 10f; // Každá minuta reálného èasu = 10 minut herního èasu

            if (timeOfDay >= dayLength) // Když projde celý herní den
            {
                timeOfDay = 0f; // Reset na zaèátek dne
            }

            UpdateLighting();
        }
    }

    void UpdateLighting()
    {
        float normalizedTime = timeOfDay / dayLength;

        // Nastavení svìtla na základì èasu dne (pøechod od dne do noci)
        directionalLight.transform.rotation = Quaternion.Euler((normalizedTime * 360f) - 90f, 170f, 0f);

        // Vizuální zmìna na základì èasu
        if (normalizedTime < 0.75f) // Den
        {
            RenderSettings.skybox = skyboxDay;
            if (!dayAmbience.isPlaying)
            {
                dayAmbience.Play();
                if (nightAmbience.isPlaying) nightAmbience.Stop();
            }
        }
        else // Noc
        {
            RenderSettings.skybox = skyboxNight;
            if (!nightAmbience.isPlaying)
            {
                nightAmbience.Play();
                if (dayAmbience.isPlaying) dayAmbience.Stop();
            }
        }
    }
}
