[System.Serializable]

public class Datas
{
    //public float[] Level_Time = new float[5];
    public int LevelIndex = 0;
    //Like LEVEL_NUMBERS in Static_Variables Class index 0 is nothing and Game Level Records start from 1
    //for convenience we use array from index 1 to work with them like game level index
    public float[] _Time = new float[Static_Variables.LEVEL_NUMBERS];

    public Datas(Timer time)
    {
        LevelIndex = time.LevelIndex;
        Static_Variables.level_Time[0] = 0;

        Static_Variables.level_Time[LevelIndex] = time.RealTime;

        VarSetter();
    }

    public void VarSetter()
    {
        for (int i = 0; i < Static_Variables.LEVEL_NUMBERS; i++)
        {
            _Time[i] = Static_Variables.level_Time[i];
        }
    }

}
