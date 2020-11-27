using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SaveAndLoad
{

    public static void Save(Timer time)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GameData.dariush";

        FileStream stream = new FileStream(path, FileMode.Create);

        Datas data = new Datas(time);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static Datas Load()
    {
        string path = Application.persistentDataPath + "/GameData.dariush";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Datas data = formatter.Deserialize(stream) as Datas;

            stream.Close();

            return data;
        }

        else
        {
            Debug.LogError("Save File Not Found in " + path);

            return null;
        }

    }

    //______________________________________________________________________________________
    public static void Save_Sound(Slider slider)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GameData_Sound.dariush";

        FileStream stream = new FileStream(path, FileMode.Create);

        SoundData soundData = new SoundData(slider);

        formatter.Serialize(stream, soundData);
        stream.Close();
    }

    public static SoundData Load_Sound()
    {
        string path = Application.persistentDataPath + "/GameData_Sound.dariush";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SoundData soundData = formatter.Deserialize(stream) as SoundData;

            stream.Close();

            return soundData;
        }

        else
        {
            Debug.LogError("Save Data Sound File Not Found in " + path);

            return null;
        }

    }

}
