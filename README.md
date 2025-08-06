# 🔧 VR Welding Simulator (Unity)

This project is a **VR-based industrial welding simulator** built using **Unity** and **XR Interaction Toolkit**. Users can pick up a welding torch, activate it using VR hand triggers, and interact with metal plates by creating spark effects and thermite residue — simulating real-world welding behavior.
---
## 🛠 Features

- ✅ VR hand tracking and grab interaction
- 🔥 Spark effects with particle system
- 🧱 Thermite residue that sticks to metal surfaces
- 🎮 Trigger-based welding activation
- 🎛️ UI controls to:
  - Toggle welding torch power (ON/OFF)
  - Adjust residue size in real-time
- 🧠 Logical safety: Torch works **only when power is ON**
---
## 📁 Project Structure
Assets/
├── Scripts/
│ ├── WeldingTool.cs # Core welding logic (trigger, residue, sparks)
│ ├── TorchPowerButton.cs # Handles ON/OFF buttons
│ ├── ResidueSliderDisplay.cs # Updates UI text based on slider value
├── Prefabs/
│ ├── ResiduePrefab # Clay-like residue blob
│ ├── WeldingTorch # XR-grabbable torch object
├── UI/
│ ├── TorchControlCanvas # World-space canvas with buttons + slider
│ ├── OnButton, OffButton # Torch toggle controls
│ ├── ResidueSizeSlider # Adjusts residue size
---
## 🎮 Controls

| Action                     | Input                                |
|---------------------------|---------------------------------------|
| Grab Welding Torch        | Grip Button (Left or Right Hand)     |
| Activate Welding (Sparks) | Trigger Button (while holding torch) |
| Toggle Power              | Press ON or OFF button in UI         |
| Adjust Residue Size       | Move slider in UI                    |

> 💡 *UI is world-space, placed on the cylinder for immersive interaction*
---
## 📦 Dependencies

- Unity 2022.3 or newer
- XR Interaction Toolkit (via Package Manager)
- Input System (enabled in Project Settings)
- Optional: TextMeshPro (for UI)

---
🧠 Development Approach
I followed a modular, iterative approach to simulate an industrial welding experience using Unity’s XR Toolkit. Below is the step-by-step breakdown of how the project was developed:
1. Project Setup
Started with the Unity XR Interaction Toolkit Template (3D URP) for better rendering control and XR-ready structure.

Integrated Input System and XR Plugin Management for cross-device support (OpenXR).

Configured XR Device Simulator for quick in-editor testing without a VR headset.
2. VR Interaction & Grabbing System
Implemented XR Grab Interactable on the welding torch to allow the player to pick it up using VR controllers.

Snapped the torch to the correct hand pose using attach points and proper pivot alignment.

Ensured grip detection through selectEntered and selectExited events.

3. Trigger-Based Spark & Welding Logic
Used InputActionReference to detect the trigger press from the XR controller.

Played a spark particle system and audio while the trigger is held.

Ensured welding behavior only happens when torch is being held.

4. Thermite Residue Mechanic
Created a residue prefab (clay-like effect) that instantiates on the metal plate during welding.

Used Raycasting from the torch tip to detect collisions with metal.

Positioned and rotated the residue blobs based on surface normals.

Made the residue stick to the target mesh using SetParent() on hit object.

5. Torch Power Control UI (ON/OFF Buttons)
Designed a world-space canvas mounted on the gas cylinder with two buttons:

🔘 ON: Activates the torch

🔘 OFF: Disables the torch entirely

Buttons update a torchPowerOn flag which gates all welding logic.

Disabled sparks and residue generation when power is OFF.

6. Residue Size UI Slider
Added a slider UI next to the buttons to control the spawned residue size.

Slider value is displayed in real-time using TextMeshProUGUI.

onValueChanged updates a public residueScale value used during residue instantiation.

7. Polishing & Testing
Verified interaction using XR Device Simulator and actual VR headset (Quest 2).

Adjusted particle emission rate, rotation, and residue spacing for realism.

Ensured everything was modular, easy to tweak, and optimized for VR use.
👨‍🔧 Challenges I Solved
⚠ UI Not Interacting with VR Ray → Fixed by using XR UI Input Module + proper canvas layers.
⚠ Trigger Input Not Detected → Solved by setting up InputActionReference properly.
⚠ Residue not spawning on metal → Solved with raycast + tag filtering + surface parenting.
⚠ Hands not visible in scene → Fixed XR rig configuration and controller prefab setup.

## 🚀 Getting Started

1. Clone this repository  
   ```bash
   git clone https://github.com/YourUsername/VR-Welding-Simulator.git
