TEAM NAME:		Senioritis
GAME NAME:		Escape the Slaughterhouse
MEMBERS:		Seonghun Kang, Andrew Mo, Amy Truong, Won Yang, Meiling Zhao
START SCENE:	Scenes/StartMenu

# HOW TO PLAY:

## Butcher Enemy ##
The Butcher enemy will patrol the hallway area outside of the rooms.
If the player is within his detection range (10 game units), the screen will start to redden,
and the buthcer will chase them, triggering a Game Over if caught.
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

# MANIFESTS:

## Amy Truong ##
	* Created StartMenu and GameOver scenes
	* Created pause menu within MainScene
	* Programmed AI, animation, overlay effect, and chase BGM for Butcher enemy
	* Designed game logo and UI for in-game menus
	* Assets Implemented
		- AnimationControllers/Butcher.controller
		- Sounds/Dangerous.mp3
		- Images/Logo.png
		- Images/credits.png
		- Images/paused.png
		- Fonts/Another Danger - Demo.otf
		- Fonts/FranxurterTotallyMedium-gxwjp.ttf
	* Scripts Implemented
		- Scripts/Navigation/ButcherAI.cs
		- Scripts/Navigation/ButcherAnimation.cs
			* Based on https://docs.unity3d.com/Manual/nav-CouplingAnimationAndNavigation.html
		- Scripts/Navigation/ButcherChase.cs (used only for testing purposes)
		- Scripts/Navigation/ButcherClickToMove.cs (used only for testing purposes)
		- Scripts/Utility/AreaReporter.cs
		- Scripts/Utility/ButcherWarningToggler.cs
		- Scripts/Utility/CreditsToggler.cs
		- Scripts/Utility/GameQuitter.cs
			* Based on Milestone 3
		- Scripts/Utility/GameStarter.cs
			* Based on Milestone 3
		- Scripts/Utility/PauseMenuToggler.cs

## Meiling Zhao ##
	* Designed and created Room 1
	* Added background music to start scene, main scene, and game over scene
	* Added sound effects for chicken, butcher, and axe throws
	* Edited game environment to resemble slaughterhouse
	* Assets Implemented
		- AnimationControllers/Blue Button.controller
		- AnimationControllers/Green Button.controller
		- AnimationControllers/Red Button.controller
		- AnimationControllers/Yellow Button.controller
		- Animations/Blue_Button.anim
		- Animations/Green_Button.anim
		- Animations/Red_Button.anim
		- Animations/Yellow_Button.anim
		- Materials/Blue.mat
		- Materials/Green.mat
		- Materials/Red.mat
		- Materials/Yellow.mat
		- Sounds/axe_throw.wav
		- Sounds/chicken_sound.wav
		- Sounds/Holiday_Weasel.wav
		- Sounds/jazzyfrenchy.mp3
		- Sounds/kl-peach-game-over-iii-142453.mp3
		- Sounds/Zombie_sound.wav
		- Materials/Textures/Eight.jpg (deleted)
		- Materials/Eight.mat (deleted)
	* Scripts Implemented
		- Scripts/TriggerButton.cs
		- Scripts/ButtonManager.cs
		- Scripts/FloorColorChange.cs
		- Scripts/ClickTarget.cs (used only for testing purposes)
			* Referenced https://answers.unity.com/questions/1440883/how-to-click-objects-in-a-specific-order-to-change.html
		- Scripts/ClicksManager.cs (used only for testing purposes)
			* Referenced https://answers.unity.com/questions/1440883/how-to-click-objects-in-a-specific-order-to-change.html

## Andrew Mo ##
	* Created layout of scene, including the walls and ground
	* Created room 2 design and functionality of the scene + keypad
	* Created winning scene
	* Created game timer
	* Created keypad for final door
	* Scripts Implemented
		- Scripts/buttonStatus.cs
		- Scripts/buttonTouch.cs
		- Scripts/FloorColorChange.cs
		- Scripts/Keypad.cs
		- Scripts/KeypadCollider.cs
		- Scripts/Room2KeyPadCollider.cs
		- Scripts/Room2PasswordController.cs
		- Scripts/Room3Tracker.cs
		- Scripts/Timer.cs
		- Scripts/WinZone.cs

## Won Yang ##
	* Designed and created room 3 (the room with the axe-throwing butchers)
	* Merged all the rooms into the MainScene
	* Polished up the look and functionality of the ground, walls, text inputs, and more
	* Animated the chicken’s movement
	* Programmed the 3rd person camera that follows the chicken
	* Assets Implemented
		- Animations/Door_Close.anim
		- Animations/Door_Open.anim
		- Materials/Ground.mat
		- Materials/Wall.mat
		- Materials/Textures/5.jpg (deleted)
		- Materials/Five.mat (deleted)
	* Scripts Implemented
		- Scripts/AxeController.cs
		- Scripts/Camera/CameraController.cs
			* Referenced https://code.tutsplus.com/tutorials/unity3d-third-person-cameras--mobile-11230
		- Scripts/Camera/CameraTargetController.cs
		- Scripts/CharacterInputController.cs
			* Referenced milestones from this class
		- Scripts/ChickenController.cs
			* Referenced milestones from this class
		- Scripts/ProjectileLauncher.cs
			* Referenced: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
						  https://learn.unity.com/tutorial/using-c-to-launch-projectiles?uv=2020.1
		- Scripts/DoorController.cs (deleted)

## Seonghun Kang ##
	* Created room 4 design and the main door to finish this game
	* Added instructions at beginning of game
	* Assets Implemented
		- Materials/Textures/V.jpg (deleted)
		- Materials/GroundMaterial.mat (deleted)
		- Materials/LetterMaterial.mat (deleted)
	* Scripts Implemented
		- Scripts/GameInstructionController.cs
		- Scripts/InstructionController.cs
		- Scripts/DoorController.cs (deleted)
		- Scripts/DoorSecurity.cs (deleted)

** NOTE: Deleted assets and scripts may have been renamed, removed due to changes to the game, merged with other files, etc.