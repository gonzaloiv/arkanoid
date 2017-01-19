using UnityEngine;
using System.Collections;

public class Config {

  public const int BoardWidth = 32; // 8 pieces width
  public const int BoardHeight = 42;
 
  public const float BallInitialVelocity = 35f;
  public static Vector3 BallInitialPosition = new Vector3(0, 0, -16);
  public static Vector3 BallInitialDirection = new Vector3(.5f + Random.Range(-.2f, .2f), 0, 1); 

  public const float PaddleVelocity = 1.5f;

  public const float MouseThreshold = 1.5f;

  public const int InitialPiecePoolAmount = 20;

  public const int InitialPaddleLives = 3;

  // Level generation
  public const int MaxLevelNumber = 30;

  public static Vector3 SpawnPieceGridOrigin = new Vector3(-14, 0, -6); // bottom left
  public static Vector3 PieceSize = new Vector3(4, 0, .75f);
  public const int HorizontalMaxPieces = 8;
  public const int VerticalMaxPieces = 32;

  public const int MinPieceAmount = 40;
  public const int MaxPieceAmount = 64;

}


