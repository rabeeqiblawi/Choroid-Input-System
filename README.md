# Choroid Input System

A Unity package for handling input in a flexible and modular way.

## Dependencies

- [Unity Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@latest/)

## Installation

To install this package, open your Unity project's package manager (menu: Window > Package Manager) and add the following package repository URL:
https://github.com/Choroid-Studio/Choroid-Input-System

Usage
To use the Choroid Input System, follow these steps:

Add the InputSystemController component to your main camera or a game object in your scene.
Add input actions and maps to the InputSystemController using the Unity Input System.
Use the InputSystemController to retrieve input values and bind input events in your scripts.
For example, you can bind an input event like this:

Copy code
InputSystemController.Instance.actions["Jump"].performed += ctx => Jump();
You can also retrieve input values like this:

Copy code
float moveX = InputSystemController.Instance.actions["Move"].ReadValue<float>().x;
Documentation
For more detailed documentation, see the Wiki.

Support
For support, please open an issue on the GitHub repository.

Contributions
Contributions are welcome! Please see the Contribution Guidelines for more information.




Rabee Qiblawi
show me the raw file 
Copy code
# Choroid Input System

A Unity package for handling input in a flexible and modular way.

## Dependencies

- [Unity Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@latest/)

## Installation

To install this package, open your Unity project's package manager (menu: Window > Package Manager) and add the following package repository URL:

https://github.com/Choroid-Studio/Choroid-Input-System

Copy code

Then, select the Choroid Input System package from the package manager and click "Install".

## Usage

To initialise the system.

1. add the script ChoroidInputManager.cs to any object in the scene.
2. drag and drop the HMD transform, the rightController transform, and the LeftController tansfor to there respective slots in the inspecter while selecting the object that has the ChoroidInputManager component.
3. add VelocityEstimator.cs to the devices to aid detecting gestures. ignore this step if you are just using the system to detect "Poses".

To create a VR Pose, follow these steps:

1. Vreate a new class and extexted VRPose class.
2. Override the getter of the inhereted member "PoseCondition".
3. Use the exposed transforms HMD, RightController, LeftController to create the desired condition for the pose based on the differnce in distance and angles between those transforms.
4. Return the boolean condition that is based on the prior calcualtions in the getter of "PoseCondition"




