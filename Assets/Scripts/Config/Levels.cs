using UnityEngine;
using System.Collections;

public class Levels {

  public static Color[] PieceColors = new Color[] { Color.blue, Color.green, Color.red, Color.yellow, Color.black };
 
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
 
}

