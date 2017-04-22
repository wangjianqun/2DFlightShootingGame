using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPitchContron : MonoBehaviour
{
    //本脚本为录音脚本的试验版本，请勿使用

    public GameObject obj;
    private float mathf = 0.0f;
    private float mathf_1 = 0.0f;
    private float spe = 0.0f;
    private float spe_1 = 0.0f;
    private float spe_11 = 0.0f;
    private Vector3 FirstVec ;
    private Vector3 LastVec;
    public float volume = 0.0f;



    //Microphone myMicrophone=new Microphone();
    //public int  minF = 0;
    //public int  maxF = 0;
    //public string AudioDeviceName = null;

    //public sealed class Microphone
    //{
    //    public Microphone();
    //    public static string[] devices { get; };
    //}

    //static AudioConfiguration aud=new AudioConfiguration();
    //public int rate = aud.sampleRate;

    public  AudioSource aud ;
    

    // Use this for initialization
	void Start ()
	{
        //AudioSource aud = GetComponent<AudioSource>();
        //if (!aud)
        //{
        //    aud = gameObject.AddComponent<AudioSource>();
        //}
        //Debug.Log("开始录音");
        //aud.clip = Microphone.Start(null, true, 10, 44100);
        //Debug.Log("开始播放");
        //aud.Play();

        //Record();

    }

    

    public void Record()
    {
        Microphone.End(null);
        AudioSource aud = GetComponent<AudioSource>();
        if (!aud)
        {
            aud = gameObject.AddComponent<AudioSource>();
        }
        Debug.Log("开始录音");
        aud.clip = Microphone.Start(null, true, 10, 44100);

        volume = Volume;

        Debug.Log("声音大小：" + volume * 10);
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrum = new float[256];


        aud.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        int i = 1;
        float all = 0;

        while (i < 255)
        {
            mathf = Mathf.Log(i);
            mathf_1 = Mathf.Log(i - 1);
            spe = spectrum[i];
            spe_1 = spectrum[i - 1];
            spe_11 = spectrum[i + 1];

            FirstVec = new Vector3(2 * i - 2 + 2 * mathf_1, spe + 4 * Mathf.Log(spe_1) + spe_1, 0);
            LastVec = new Vector3(2 * i + 2 * mathf, spe_11 + 4 * Mathf.Log(spe) + spe, 0);
            Debug.DrawLine(FirstVec, LastVec, Color.yellow);


            //Debug.DrawLine(new Vector3(i-1,spectrum[i],0),new Vector3(i,spectrum[i+1],0),Color.red);
            //   Debug.DrawLine(new Vector3(i-1,Mathf.Log(spectrum[i-1]),2),new Vector3(i,Mathf.Log(spectrum[i]),2),Color.cyan);
            //   Debug.DrawLine(new Vector3(Mathf.Log(i-1), spectrum[i - 1] , 1), new Vector3(Mathf.Log(i), spectrum[i], 1), Color.green);
            //   Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);  //短，剧烈

            all = all + spectrum[i];
            i++;

        }

        //print(all * 10);
        //all = all * 10 + 1;
        Debug.Log(Volume.ToString());

    }

    public float Volume
    {
        get
        {
            if (Microphone.IsRecording(null))
            {
                Debug.Log("开始采样");
                //采样数
                int sampleSize = 128;
                float[] samples=new float[sampleSize];
                //int startPosion = Microphone.GetPosition(null) - (sampleSize+1);  //得到数据
                aud.clip.GetData(samples, 1);
                   
                //取一段录音片段的峰值     
                float levelMax = 0;
                for (int i = 0; i < sampleSize; i++)
                {
                    float wavePeak = samples[i];
                    if (levelMax<wavePeak)
                    {
                        levelMax = wavePeak;         
                    }

                }        

                return levelMax*99;
                 

            }
            return 0;
        }
    }

}
