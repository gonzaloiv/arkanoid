using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Config {

  public const float BoardWidth = 32;
  public const float BoardHeight = 27;
 
  public const float BallInitialVelocity = 35f;
  public static Vector3 BallInitialPosition = new Vector3(0, .5f, -16);
  public static Vector3 BallInitialDirection = new Vector3(.5f + Random.Range(-.2f, .2f), 0, 1); 

  public const float PaddleVelocity = 1.5f;

  public const float MouseThreshold = 1.5f;

  public const int InitialPiecePoolAmount = 20;

  public const int InitialPaddleLives = 3;

  public const int MaxLevelNumber = 10;

  public static Vector3 PieceSize = new Vector3(4, 1, 1.5f);
  public static Vector3 SpawnPieceGridOrigin = new Vector3(-BoardWidth / 2 - PieceSize.x / 2, 0, -PieceSize.z * 4.5f); // bottom left

}
