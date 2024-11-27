# SHIKAKU-LEV
This is a Shikaku puzzle game built using Unity with clean, scalable architecture and robust design patterns to ensure maintainability and flexibility.
---

## Features
- Puzzle Grid: A grid-based puzzle with numbers to guide rectangle formation.
- Simple Controls: Drag to select areas for rectangle creation.
- Scoring System: Earn points for each correctly formed rectangle.
---
## PLAY ON
  https://yashvardhan1.itch.io/shikakulev
---
## Patterns Used
- MVC (Model-View-Controller) Architecture: The core architecture of the game is based on MVC. The Model manages the game state (e.g., grid and numbers), the View handles UI updates and user interaction, and the Controller processes the game logic, separating concerns for easier maintenance and testing.

- Service Locator Pattern: This pattern is used to manage access to various services like game state management and UI updates. The service locator makes it easier to locate and use services throughout the game without tight coupling, ensuring a modular design.

- Singleton Pattern: A singleton is used for game-wide services (like the GameManager), ensuring that only one instance of a service exists and can be accessed globally. This pattern ensures that services like score management or game state are consistent throughout the game.
---
## SCREENSHOTS
<img src="https://github.com/user-attachments/assets/27400665-af1c-42c7-81c6-f1b36288e036" alt="Screenshot 2024-10-19 201112" width="400" height="600" style="margin: 20px;">
&nbsp;&nbsp;&nbsp;&nbsp;
<img src="https://github.com/user-attachments/assets/fd6baeba-c650-433a-9022-132ad813afff" alt="Screenshot 2024-10-19 201126" width="400" height="600">
<br><br>
<img src="https://github.com/user-attachments/assets/911f7a68-5cfe-4caa-ad9a-b8e54661d838" alt="Screenshot 2024-10-19 201135" width="400" height="600">
