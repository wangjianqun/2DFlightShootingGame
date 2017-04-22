using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    //该脚本实现读取录音音量大小
    //public AudioSource audioSource;
    
    public float volume;
    private Vector3 vec;
    public float moveSpeed = 1;
    private AudioClip audioClip;
    private string device;
    private bool isInitialized;

    //初始化麦克风设备
    void InitMicrophone()
    {
        if (device==null)
        {
            device = Microphone.devices[0];
        }
        audioClip = Microphone.Start(null, true, 999, 44100);

    }

    private int sample = 128;
    //获取当前音量
    float CurrentVolume()
    {
        float currentMaxVolume = 0;
        float[] waveData=new float[sample];
        int micPosition = Microphone.GetPosition(null) - (sample + 1);
        if (micPosition<0)
        {
            return 0;
        }
        audioClip.GetData(waveData, micPosition);
        for (int i = 0; i < sample; i++)
        {
            float wavePeak = waveData[i]*waveData[i];
            if (currentMaxVolume<wavePeak)
            {
                currentMaxVolume = wavePeak; //在一段音频数据中获取峰值，作为当前的音量值
            }
        }
        return currentMaxVolume;

    }

    // Use this for initialization
    void Start ()
	{

        
	    
        //int lastPos = Microphone.GetPosition(null);
        //float[] samples = new float[10];
        //audioSource.clip.GetData(samples, 0);
        //foreach (float sample in samples)
        //{
        //    volume += sample;
        //    Debug.Log(sample);
        //}
        //volume = volume / 10;
        //Debug.Log("声音音量为：" + volume.ToString());
        //Debug.Log("声音音量："+audioSource.volume);
        //audioSource.Play();
        //print("ksbf");

    }
	
	// Update is called once per frame
	void Update ()
	{
	    float sam;
	    volume = CurrentVolume();
	    volume = volume*100;
        //print("声音音量："+volume);
        sam = VolumeToValue(volume);


        
	    if (transform.position.y<=5.2)
	    {
            vec = Vector3.up * Time.deltaTime * (sam - 1);

        }
	    else
	    {
	        vec = Vector3.down*Time.deltaTime;
	        
	    }

        transform.Translate(vec);

        //   print(vec.y);
        //if (vec.y>=5)
        //{
        //    vec.y = 5;
        //       transform.Translate(vec);
        //       print("限制了高度");
        //   }
        //else
        //{
        //       transform.Translate(vec);
        //   }


        //   vec=Vector3.down*Time.deltaTime;
        //   transform.Translate(vec);
        //   float[] samples = new float[1];
        //float sam;
        //if (audioClip)  //确认麦克风是否在工作
        //{
        //    int lastPos = Microphone.GetPosition(null);  //获取实时录音的位置

        //       //for (int i = 0; i < 10; i++)
        //       //{

        //       audioClip.GetData(samples, lastPos);  //获取录音的音量大小（可能为负值）
        //    samples[0] = Mathf.Abs(samples[0]);  //取绝对值
        //    sam = samples[0]*100;
        //       Debug.Log("采样结果："+sam);
        //    //}
        //sam = VolumeToValue(sam);
        //vec = Vector3.up * Time.deltaTime * sam;
        //       transform.Translate(vec);
        //}
        //else
        //{
        //    Debug.Log("没有采样");
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //       //transform.Translate(new Vector3(1, moveSpeed * 2, 1));
        //vec = Vector3.up * Time.deltaTime * 2;
        //transform.Translate(vec);
        //       //this.GetComponent<Rigidbody2D>().AddForce(Vector2.up);

        //   }

    }

    void OnEnable()  //OnEnable函数在update()函数前执行
    {
        InitMicrophone();
        isInitialized = true;
    }

    void StopMicrophone()
    {
        Microphone.End(device);
    }

    void OnDestroy()
    {
        StopMicrophone();
    }


    //make sure the mic gets started & stopped when application gets focused
    //确保程序在运行时麦克风能够正常打开和停止
    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            if (!isInitialized)
            {
                InitMicrophone();
                isInitialized = true;
            }
        }
        if (!focus)
        {
            StopMicrophone();
            isInitialized = false;
        }
    }

    #region 将声音数据分级
    
    public float VolumeToValue(float volume)
    {
        if (volume < 0.1)
        {
            return 0;
        }
        else if (0.1 <= volume && volume < 1)
        {
            return 1f;
        }
        else if (1 <= volume && volume < 5)
        {
            return 1.5f;
        }
        else if (5 <= volume && volume < 10)
        {
            return 2f;
        }
        else if (10 <= volume && volume < 20)
        {
            return 2.5f;
        }
        else if (volume >= 20)
        {
            return 3f;
        }
        return 0;

    }


    #endregion









}
