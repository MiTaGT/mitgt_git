using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class Save : MonoBehaviour {

    public string text = "";

	// Use this for initialization
	void Start () {

        string filePath = Application.dataPath + @"\Scripts\File\test.txt";
        //　ファイルが存在しなければ作成
        if (!File.Exists(filePath))
        {
            Debug.Log("ファイルが見つかりません");
            Debug.Log("ファイルを生成します");
            using (File.Create(filePath))
            {
            }
        }
        using (FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            using (StreamReader streamReader = new StreamReader(fileStream))
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                string preString = streamReader.ReadToEnd();
                streamWriter.WriteLine("文字列の追加");
                fileStream.Position = 0;
                streamWriter.WriteLine(preString);
            }
        }
        using (StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8))
        {
            while (!streamReader.EndOfStream)
            {
                Debug.Log("ストリームで読み込み：" + streamReader.Read());
            }
        }


    }

    // Update is called once per frame
    void Update () {
        string filePath = Application.dataPath + @"\Scripts\File\test.txt";
        if (Input.GetKeyDown("z"))
        {
            using (StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8))
            {
                while (!streamReader.EndOfStream)
                {
                    Debug.Log("ストリームで読み込み：" + streamReader.Read());
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            using (FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    string preString = streamReader.ReadToEnd();
                    streamWriter.WriteLine(text);
                    fileStream.Position = 0;
                    streamWriter.WriteLine(preString);
                }
            }
        }
    }
}
