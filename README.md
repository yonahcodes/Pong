# Pong - 2D Multiplayer Game

## Description
This project was developed as part of an **Introduction to Video Game Programming** course. The game is a modern take on the classic `Pong` game, featuring multiple game modes and enhanced mechanics. Developed in `Unity`, the project integrates class concepts such as interactive menus, sound effects, multiplayer gameplay, and AI-based paddle movement, all implemented using custom `C#` scripts.

## Key Features

### Main Menu
- **Interactive Start Screen**:
  - Includes background music.
  - Features 3 buttons:
    - **Human vs Human**: Starts a multiplayer game.
    - **Human vs Machine**: Starts a game against an AI opponent.
    - **Start!**: Launches the selected game mode.
  - The menu seamlessly manages the transitions between the game modes and reactivates the menu after a game ends.

### Game Modes
#### Solo Mode
- Plays a sound whenever the player loses a point.
- The ball's speed increases by **10%** every time the player loses a point.

#### Multiplayer Mode (Human vs Human)
- Adds the following features on top of solo mode:
  - **Interface**:
    - Displays scores for both players.
    - Each player controls their paddle:
      - **Left Paddle**: Controlled using `W` (up) and `S` (down).
      - **Right Paddle**: Controlled using `O` (up) and `L` (down).
  - **Scoring System**:
    - Each player's score starts at zero.
    - A point is awarded to a player when the ball crosses their opponent's side.
    - The ball resets direction towards the losing player after a score.
    - The game ends when a player reaches the **maximum score** (configurable with `pointageMaximal`).
    - Once the game ends, the menu screen is reactivated.

#### Human vs AI Mode
- Extends the multiplayer mode with the following:
  - The **left paddle** is controlled by a basic **AI system**:
    - The paddle automatically adjusts its vertical position to follow the ball.
  - The **right paddle** is controlled by the player using:
    - `W` to move up.
    - `S` to move down.

### Animations and Audio
- Background music for different game states (menu and gameplay).
- Sound effects trigger based on specific game events, like scoring or collisions.

### Controls
- **Main Menu**:
  - Navigate the menu using the mouse.
  - Click buttons to start a selected game mode.
- **Solo Mode**:
  - Use `W` to move the paddle up.
  - Use `S` to move the paddle down.

- **Multiplayer Mode (Human vs Human)**:
  - **Player 1 (Left Paddle)**:
    - Use `W` to move the paddle up.
    - Use `S` to move the paddle down.
  - **Player 2 (Right Paddle)**:
    - Use `O` to move the paddle up.
    - Use `L` to move the paddle down.

- **Human vs AI Mode**:
  - The right paddle is controlled using `W` and `S` (as in solo mode).
  - The left paddle moves automatically based on the ball's position.

### C# Scripting
- **Main Menu Management**:
  - Handles transitions between the main menu and gameplay modes.
- **Game Logic**:
  - Implements scoring, game restarts, and ball speed adjustments.
- **Paddle Controls**:
  - Custom scripts manage paddle movement for both players and the AI.
- **Audio Management**:
  - Scripts handle background music and sound effects, syncing them with gameplay events.

## Requirements
- **Unity Version**: `LTS 2022.3.40f1`
- Free or personally created assets (no copyrighted media).

## How to Play
Clone the repository:
   ```bash
   git clone https://github.com/yonahcodes/Pong.git
   ```
