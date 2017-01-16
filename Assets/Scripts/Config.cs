using UnityEngine;
using System.Collections;

public class Config {

  public const int BoardWidth = 39;
  public const int BoardHeight = 54;

  public const float BallInitialVelocity = 50f;
  public static Vector3 BallMaxVelocity = new Vector3(35, 0, 35);

  public const float PaddleVelocity = 2f;

  public const float MouseThreshold = 1.5f;

}
