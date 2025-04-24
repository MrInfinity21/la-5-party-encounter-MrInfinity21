class program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Select Your Warrior: ");

        Weapon daggers = new Weapon("Dual Daggers", 15, "Magical Daggers");
        Weapon blades = new Weapon("Blades of Chaos", 22, "Rage and Fire");
        Weapon gun = new Weapon("Pistol", 12, "Regular Bullets");
        Weapon beans = new Weapon("Bare Fists", 10, "Just Hands");


        Character newPlayer = new Character(100, "Luke", daggers, "Elf");
        Character newPlayer2 = new Character(100, "Velu", blades, "Cleric");
        Character newPlayer3 = new Character(100, "Dylan", gun, "Thief");
        Character newPlayer4 = new Character(100, "William", beans, "Ranger");

        Enemy newEnemy = new Enemy("Orc 1", 110, 12, "Chief");
        Enemy newEnemy2 = new Enemy("Orc 2", 120, 13, "Warlord 1");
        Enemy newEnemy3 = new Enemy("Orc 3", 130, 15, "Warlord Bodygurad");
        Enemy newEnemy4 = new Enemy("Orc 4", 150, 20, "Overlord");


        Character[] playerList = { newPlayer, newPlayer2, newPlayer3, newPlayer4 };
        Enemy[] enemyList = { newEnemy, newEnemy2, newEnemy3, newEnemy4 };

        Console.WriteLine("You encounter a group of Orcs");
        Console.WriteLine("You and your party members draw weapons and face off the Orcs");
        int currentEnemyIndex = 0; // Start with the first enemy
        bool allEnemiesDefeated = false;
        bool allPlayersDefeated = false;

        // Main Battle Loop
        while (!allEnemiesDefeated && !allPlayersDefeated)
        {
            // Display status of players and enemies
            Console.WriteLine("\nEnemies Remaining:");
            foreach (var enemy in enemyList)
            {
                if (enemy.Health > 0)
                    Console.WriteLine($"{enemy.Name}: {enemy.Health} HP");
            }

            Console.WriteLine("\nPlayers Remaining:");
            foreach (var player in playerList)
            {
                if (player.Health > 0)
                    Console.WriteLine($"{player.Name}: {player.Health} HP");
            }

            // Check if all enemies are defeated
            if (currentEnemyIndex >= enemyList.Length || allEnemiesDefeated)
            {
                allEnemiesDefeated = true;
                break;
            }

            // Prompt player to choose a character to attack
            Console.WriteLine("\nChoose a player to attack the enemy (enter a number):");
            for (int i = 0; i < playerList.Length; i++)
            {
                if (playerList[i].Health > 0) // Only show players who are still alive
                {
                    Console.WriteLine($"{i + 1}: {playerList[i].Name} - Health: {playerList[i].Health}");
                }
            }

            int playerChoice;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out playerChoice) && playerChoice >= 1 &&
                    playerChoice <= playerList.Length && playerList[playerChoice - 1].Health > 0)
                {
                    break; // Valid choice, exit loop
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose a valid player number.");
                }
            }

            Character chosenPlayer = playerList[playerChoice - 1];

            // Player attacks the current enemy
            Console.WriteLine($"\n{chosenPlayer.Name} attacks {enemyList[currentEnemyIndex].Name}!");
            chosenPlayer.Attack(enemyList[currentEnemyIndex]);

            // Check if the current enemy is defeated
            if (enemyList[currentEnemyIndex].Health <= 0)
            {
                Console.WriteLine($"{enemyList[currentEnemyIndex].Name} has been defeated!");
                currentEnemyIndex++; // Move to the next enemy
                if (currentEnemyIndex >= enemyList.Length)
                {
                    allEnemiesDefeated = true; // All enemies are defeated
                }
            }

            // Check if all enemies are defeated
            if (allEnemiesDefeated)
            {
                Console.WriteLine("All enemies have been defeated. You win!");
                break;
            }

            // Enemy attacks back
            Enemy currentEnemy = enemyList[currentEnemyIndex];
            Console.WriteLine($"\n{currentEnemy.Name} attacks back!");
            currentEnemy.Attack(chosenPlayer);

            // Check if any player is defeated
            bool allPlayersDefeatedCheck = true;
            foreach (var player in playerList)
            {
                if (player.Health > 0)
                {
                    allPlayersDefeatedCheck = false;
                    break;
                }
            }

            if (allPlayersDefeatedCheck)
            {
                allPlayersDefeated = true;
                Console.WriteLine("All players have been defeated. You lose!");
                break;
            }
        }
    }
}


// Ask the player which player character they want to act with
// Get input from player based on number of party member 4 in this case
// Get player to choose which ability they want to use
// IF something to use on enemy get player to choose an enemy to attack/act on
// ELSE IF Ability was something to use on party member, choose which party member to act on
