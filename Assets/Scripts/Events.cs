using UnityEngine.Events;

#region Game Events

public class StartGame : UnityEvent {}
public class GameOver : UnityEvent {}
public class EndGame : UnityEvent {}

#endregion

#region Level Events

public class EndLevel : UnityEvent {}
public class NextLevel : UnityEvent {}

#endregion

#region Level Mechanics Events

public class MovePaddleLeft : UnityEvent {}
public class MovePaddleRight : UnityEvent {}
public class PaddleMiss : UnityEvent {}
public class PieceHit : UnityEvent {}

#endregion