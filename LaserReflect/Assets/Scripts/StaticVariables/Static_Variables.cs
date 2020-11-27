using UnityEngine;

public class Static_Variables : MonoBehaviour
{
    //This LEVEL_NUMBERS is qual with game Scenes
    public static readonly int LEVEL_NUMBERS = 21; //Yes This is HardCoding I know that :(
    //Current Level Index
    public static int currentLevelIndex;
    //index 0 is nothing and Game Level Records Start from index 1
    public static float[] level_Time = new float[LEVEL_NUMBERS];
    //Sound_Volume
    public static float sound_Volume = 0.7f;
}
