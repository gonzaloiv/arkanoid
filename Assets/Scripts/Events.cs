using UnityEngine;
using UnityEngine.Events;

#region Game Events

// Listeners: Game
// Triggers: GameOverScreen, GameWinScreen, OpeningScreen
public class StartGame : UnityEvent {}

// Listeners: Game
// Triggers: Paddle
public class GameOver : UnityEvent {}

// Listeners: Game
// Triggers: Level
public class EndGame : UnityEvent {}

#endregion

#region Level Events

// Listeners: Level
// Triggers: PlayLevelState
public class EndLevel : UnityEvent {}

// Listeners: Level
// Triggers: NextLevelScreen
public class NextLevel : UnityEvent {}

#endregion

#region Level Mechanics Events

// Listeners: Paddle
// Triggers: InputManager
public class MovePaddleLeft : UnityEvent {}

// Listeners: Paddle
// Triggers: InputManager
public class MovePaddleRight : UnityEvent {}

// Listeners: Paddle, LevelHUD
// Triggers: Ball
public class PaddleMiss : UnityEvent {}

// Listeners: PlayLevelState
// Triggers: Piece
public class PieceHit : UnityEvent {}

// Listeners: SoundManager
// Triggers: Ball
public class BallHit : UnityEvent {}


#endregion