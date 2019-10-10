# Abstract 

Project name: Recipe Slave -- Mountain and Sea 

Owner: Jiaji Gong (jg17339)

# How to run this project?

1. Download the whole project 
2. Launch Unity, Open Project, select the "capstore_project"folder. 
3. Select a scene, click "play" button to run the game. 

# How to play?
Movement:
- left and right arrow key to move horizontally
- space button to jump. Hold the space longer to jump higher. 
- Jump again on the wall to perform "Ninja" jump
- "F" to dash

Combat:
- "J" to perform noral melee attack
- "G" to throw stone (Range attack)
- "N" to cast skill#1
- "M" to cast skill#2
- "I" tp cast ultimate skill (not yet implemented)

Inventory:
- Click buttons "0001" "0002" "0003" to use items
- collect loop, automatically add it to the inventory. 

Cook:
move close enough to a stove, press up arrow key to open the cook panel.
Click "cook recipe#X" to cook. Then click Food#X to eat the food. 

## Scenes
Scenes are in *Asset/Scene* folder.
- Town: The start up scene. 
- Tutorial Level: A tutorial level to guild player though playing.
- Level1:The first level ---  zhaoyao mountain. The first complete playable level. 

# Files

All the work stored in *Assets* folder
Other folders in the first layer is created by Unity engine. 
In the *Assets* folder
- Animation: all animations for game objects
- Scenes: all game scenes
- Scripts: all the codings, divied to some subfolders by functionality
- Sprites: the sprites, pictures, artworks get from many resources
- Prefabs: the game object prefabs
- Gizmos: Contains the Cinemachine to implement advanced camera functions. 
- Tilemap: The tiles that I might be used in the project. 

The assets folders, original source and how did I use the assets:
- 2D_Stone age world: Download from Unity asset store. It contains multiple stone age assets, 
I take the character as my player, as well as the animations sprites. 
And also the enemy#1 and several food sprites.
- BayatGames: It contains a bunch of free platform game assets in png format.
I use the tiles to make ground and walls, and some other sprites. 
- HD-2D background art suibokuga: some Chinese sytel ink drawing, currently not in use. 
- IGL Free TileSet: some brick wall sprites, I use it for decoration. 
- Sunny land: contains some simple sprites, the boss#1 comes from this package. 

# Scripts:
Brifely explain what is the functionality of each script:
Character/Combat folder: scipts about character combat system 
- CollectLoot: detect collision between player and loot. perform action. 
- EnergyController: manage the energy points of player. 
- MeleeAttack: Count down the cooldown timer, perform "hit" animation. Collide with enemy. Perform actions. 
- MovingFireball: (Skill 1) The initial state of fireball, collide with enemy, perform actions. Destory self in seconds.
- MovingFireball2: (Skill 2) similar with above script. 
- RangeAttack: Player throw stone towards enemy. 
- RangeHitEnemy: Stone collides with enemy. Perform actions.
- Skill1: Cast skill1
- Skill2: Cast skill2
- TakeDamages: What happend if hit by enemy. such as The invinciable animation, lose hp method

Character/Movement folder: scipts to control movement of character
- AfterDeath: The hehaviour after player died. 
- Dash: Dash movment of player. 
- Jump: basic jump and advanced jump function. Hold longer, jump higher. Fall speed > jump speed. 
- Move Horizontal: The basic move left and right. Animations. 

Character folder: the other functions
- CharController: The main controller of the character, a center class controls everything of character. such as hp, ep, attacks, skills...
Access this class to perform actions related to the character.

Enemy folder: manage the enemy behaviour
- EnemyController: The main controller of the enemy, every enemy has this script attached. 
It checks the alive state, control drop loot function, detect collision with player, and update HP. 
Access this script to modify enemy state. 
- Patrol: A path finding algorithm that allow enemy move patrol on the ground, avoid fall from the platforms. 

Script floder: Ungrouped scripts
- BagManager: Most important script to manage the inventory system. 
Add, lose, display, cook and use the items in the inventory. 
- DisplayTutorialText: Made for tutorial level. Display tutorial message at proper time. 
- Item: A template class stores variables of item object. such as name, id, descriptions. Also manage collisions. 
- OpenTheDoor: The function that player could go inside/outside the door. (in town map)

Asset floder: Unsorted scripts
- CollidePlayer: If player fall, kill player. 
- Cook: Half cook function. Might need rework
- DestorySmock: control the smock of hidden place
- FadeAnimation: The fade in and fade out animation when switch between scenes. 
- MovingPlatform: The unstable platform will disappear if player stand on it for x seconds. 
- NextScene: Connect the scenes. Player could travel between scenes. 
- RemoveHideenIMG: Remove the cover image of hidden place if player move into the place. 
- StoveManager: Update the last stove position. Restore player's hp, ep (not yet implement)

# Declearation

All the work, except the assets in *sprites* folder, are done by myself alone. 

All the items in the *sprites* folder are FREE from internet. 