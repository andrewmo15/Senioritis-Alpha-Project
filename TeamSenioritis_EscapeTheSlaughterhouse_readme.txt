TEAM NAME:		Team Senioritis
GAME NAME:		Escape the Slaughterhouse
MEMBERS:		Seonghun Kang, Andrew Mo, Amy Truong, Won Yang, Meiling Zhao
START SCENE:	Scenes/StartMenu

# HOW TO PLAY:

## Butcher Enemy ##
The Butcher enemy will patrol the hallway area outside of the rooms.
If the player is within his detection range (10 game units), he will chase them, triggering a Game Over if caught.
If 10 seconds pass without getting caught, the Butcher will get tired and return to patrolling.
There will be a 5 second cooldown period afterwards where the player cannot get chased again.

## Room 1 Objective ##
The floor of this room will flash colors in a particular order.
You must press the buttons in the order of the colors that are flashed on the floor.

## Room 2 Objective ##
The words on the wall reveal a code. Decipher the code and enter it into the keypad to get a clue.

## Room 3 Objective ##
There are 4 butchers that will throw axes at you. Dodge them for 15 seconds to get the code!

## Room 4 Objective ##
The floor of this room will have a security code under a ball out of 16 balls.
You must push the balls to find the security code on the ground.

# PROBLEM AREAS:
	* If the Butcher enters a room during a chase and then gets tired,
	  he will phase through walls to return to the hallway.
	* Butcher can only detect and chase players when the player is in the hallway.
	  However, the hallway intrudes on each room’s door entrance area,
	  which can lead to surprise attacks as players try to exit a room.
	* Room 3 may be too difficult for less experienced gamers.
	* The chicken falls after exiting the final door.

# MANIFESTS:

## Amy Truong ##
* Created StartMenu, PauseMenu, and GameOver scenes
* Programmed AI and animation for Butcher enemy
* Assets Implemented
	* AnimationControllers/Butcher.controller
	* Sounds/Dangerous.mp3
* Scripts Implemented
	* Scripts/Navigation/ButcherAI.cs
	* Scripts/Navigation/ButcherAnimation.cs
		* Based on https://docs.unity3d.com/Manual/nav-CouplingAnimationAndNavigation.html
	* Scripts/Utility/AreaReporter.cs
	* Scripts/Utility/CreditsToggler.cs
	* Scripts/Utility/PauseMenuToggler.cs
	* Scripts/Utility/GameStarter.cs
		* Based on Milestone 3
	* Scripts/Utility/GameQuitter.cs
		* Based on Milestone 3
	* Scripts/Navigation/ButcherChase.cs (used only for testing purposes)
	* Scripts/Navigation/ButcherClickToMove.cs (used only for testing purposes)

## Meiling Zhao ##
* Designed and created Room 1
* Added background music to start scene, main scene, and game over scene
* Assets Implemented
	* AnimationControllers/Blue_Button.controller
	* AnimationControllers/Green_Button.controller
	* AnimationControllers/Red_Button.controller
	* AnimationControllers/Yellow_Button.controller
	* Animations/Blue_Button.anim
	* Animations/Green_Button.anim
	* Animations/Red_Button.anim
	* Animations/Yellow_Button.anim
	* Materials/Textures/Eight
	* Materials/Eight
	* Materials/Blue
	* Materials/Green
	* Materials/Red
	* Materials/Yellow
	* Sounds/Holiday_Weasel
	* Sounds/kl-peach-game-over-iii-142453
	* Sounds/jazzyfrenchy
* Scripts Implemented
	* Scripts/TriggerButton.cs
	* Scripts/ButtonManager.cs
	* Scripts/FloorColorChange.cs
	* Scripts/ClickTarget.cs (used only for testing purposes)
	* Scripts/ClicksManager.cs (used only for testing purposes)

## Andrew Mo ##
* Created layout of scene, including the walls and ground
* Created room 2 design and functionality of the scene
* Scripts implemented
	* Scripts/buttonStatus.cs
	* Scripts/buttonTouch.cs

## Won Yang ##
* Designed and created room 3 (the room with the axe-throwing butchers)
* Merged all the rooms into the MainScene
* Polished up the look and functionality of the ground, walls, text inputs, and more
* Animated the chicken’s movement
* Programmed the 3rd person camera that follows the chicken
* Assets Implemented
	* Animations/Door_Close.anim
	* Animations/Door_Open.anim
	* Materials/Textures/5.jpg
	* Materials/Ground.mat
	* Materials/Wall.mat
	* Materials/Five.mat
* Scripts Implemented
	* Scripts/AxeController.cs
	* Scripts/Camera/CameraController.cs
		* Referenced https://code.tutsplus.com/tutorials/unity3d-third-person-cameras--mobile-11230
	* Scripts/Camera/CameraTargetController.cs
	* Scripts/CharacterInputController.cs
		* Referenced milestones from this class
	* Scripts/ChickenController.cs
		* Referenced milestones from this class
	* Scripts/DoorController.cs
	* Scripts/ProjectileLauncher.cs
		* Referenced:
			* https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
			* https://learn.unity.com/tutorial/using-c-to-launch-projectiles?uv=2020.1

## Seonghun Kang ##
* Created room4 and the main door to finish this game. 
* Assets Implemented
	* Materials/Textures/V
	* Materials/GroundMaterial
	* Materials/LetterMaterial
* Scripts implemented
	* Scripts/DoorController
	* Scripts/DoorSecurity
