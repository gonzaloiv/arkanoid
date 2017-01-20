using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelConfig {

  // Test Level
  public static int[][] TestLevel = new int[][] {
    new int[] { 0, 0, 0 }
  };

  // 4x8 Regular
  public static int[][] Level1 = new int[][] {
    new int[] { -12, 0, 0 }, new int[] { -4, 0, 0 }, new int[] { 4, 0, 0 }, new int[] { 12, 0, 0 },
    new int[] { -12, 2, 1 }, new int[] { -4, 2, 1 }, new int[] { 4, 2, 1 }, new int[] { 12, 2, 1 },
    new int[] { -12, 4, 2 }, new int[] { -4, 4, 2 }, new int[] { 4, 4, 2 }, new int[] { 12, 4, 2 },
    new int[] { -12, 6, 3 }, new int[] { -4, 6, 3 }, new int[] { 4, 6, 3 }, new int[] { 12, 6, 3 },
    new int[] { -12, 8, 4 }, new int[] { -4, 8, 4 }, new int[] { 4, 8, 4 }, new int[] { 12, 8, 4 },
    new int[] { -12, 10, 2 }, new int[] { -4, 10, 2 }, new int[] { 4, 10, 2 }, new int[] { 12, 10, 2 },
    new int[] { -12, 12, 3 }, new int[] { -4, 12, 3 }, new int[] { 4, 12, 3 }, new int[] { 12, 12, 3 },
    new int[] { -12, 14, 4 }, new int[] { -4, 14, 4 }, new int[] { 4, 14, 4 }, new int[] { 12, 14, 4 }
  };

  /// Level generation
  public static Dictionary<PieceType, PieceInfo> PieceTypes = new Dictionary<PieceType, PieceInfo>() {
    { PieceType.OneHitPiece, new PieceInfo(PieceType.OneHitPiece, Color.green, 10, 1) },
    { PieceType.TwoHitPiece, new PieceInfo(PieceType.TwoHitPiece, Color.magenta, 2, .5f) },
    { PieceType.NoHitsPiece, new PieceInfo(PieceType.NoHitsPiece, Color.cyan, 2, .3f) }
  };

}

public enum PieceType {
  None,
  OneHitPiece,
  TwoHitPiece,
  NoHitsPiece
}

public struct PieceInfo {

  public PieceType type;
  public Color color;
  public float amount;
  public float increaseAmount;

  public PieceInfo(PieceType type, Color color, float initialAmount, float increaseAmount) {
    this.type = type;
    this.color = color;
    this.amount = initialAmount;
    this.increaseAmount = increaseAmount;
  }

  public void IncreaseAmount(){
    this.amount += increaseAmount;
  }

}