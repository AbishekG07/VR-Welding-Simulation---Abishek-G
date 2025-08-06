# 🔧 VR Welding Simulator (Unity)

This project is a **VR-based industrial welding simulator** built using **Unity** and **XR Interaction Toolkit**. Users can pick up a welding torch, activate it using VR hand triggers, and interact with metal plates by creating realistic spark effects and thermite residue — simulating real-world welding behavior.

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

## 🚀 Getting Started

1. Clone this repository  
   ```bash
   git clone https://github.com/YourUsername/VR-Welding-Simulator.git
