# 2D-Platformer-Game
An 2D Platformer Math Problem Solver Game made for Kids for interactive and Fun Learning

For more Details Go Through https://github.com/aniket96999/2D-Platformer-Game/blob/main/Math%20Explorer.pdf

#Product Functions:

The major functions of the system include:

Character Customization
  Cycle through different outfits and accessories.
  Randomize the character’s appearance.
  Real-time visual feedback of changes on the main character sprite.


Player Movement
  Walk and jump within a 2D environment.
  Respond to user input (keyboard or touch).
  Collision detection with interactive objects such as question boxes or enemies.


Math Question System
  Generate random math problems (Addition, Subtraction, Multiplication, Division).
  Provide multiple-choice answers and validate user selections.
  Maintain a timer for each question and display feedback.


UI and Feedback
  Display question panels, win/lose feedback, and level dialogs.
  Provide score updates and progress tracking.
  Support simple menus and in-game HUD for player information.


Audio and Effects
  Background music that loops throughout gameplay.
  Sound effects for interactions, correct/wrong answers, and events.


# Functional Requirements
  
These describe what the system must do:

1 Player Movement
  The player character must move left or right using keyboard or on-screen controls.
  The player character must be able to jump, only when grounded.
  Animations must reflect movement speed and direction.
  Collision detection must be enabled for ground, enemies, and question boxes.


2 Character Customization (OutfitChanger)
  Players can cycle through outfits using Next and Prev buttons.
  Players can randomize the outfit with a Randomize button.
  Current outfit must be visually updated immediately on the character sprite.
  The system must prevent index overflow/underflow in sprite lists.


3.1.3 Math Question System (QuestionManager)
  The system must generate random math problems: Addition, Subtraction, Multiplication, Division.
  Each question must have 4 multiple-choice answers, with one correct answer.
  A timer (default 30 seconds) is displayed for each question.
  If the timer runs out, the question is marked incorrect, and feedback is displayed.
  Correct answers increment player score; incorrect answers do not.
  Feedback (win/lose) must be shown using UIhandler panels.


4 UI and Feedback (UIhandler)
  Display question panel when a player interacts with a question box.
  Show Win/Lose images based on correctness of answer.
  Display score and timer during gameplay.
  Allow Restart Level and Next Level functionality.
  Ensure all panels are visible and responsive on supported platforms.


5 Audio Management (AudioManager)
  Background music must loop continuously during gameplay.
  Sound effects must play for the following events:
  Correct answer
  Wrong answer
  Player collision with objects
  Level transitions
  Audio playback must not interfere with game performance.

6 Level Progression
  The game must have at least 5 levels.
  Completing a level (solving required questions) allows the player to advance to the next level.
  Level progression must be persistent only for current session (no cloud save in current version).



