using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DemoPlayer : MonoBehaviour
{
    #region Singleton

    public static DemoPlayer Instance;

    DemoPlayer(){
        Instance = this;
    }

    #endregion

    public VideoClip[] VideoClipArray;
    private VideoPlayer videoPlayer;
    private float timeToNextVideo;
    // Start is called before the first frame update

    void Awake(){
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Pause();
    }
    void Start()
    {
        timeToNextVideo = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextVideo -= Time.deltaTime;
        if (timeToNextVideo <= 0f ){
            videoPlayer.clip = VideoClipArray[Random.Range(0,VideoClipArray.Length)];
            timeToNextVideo =(float)videoPlayer.clip.length +1f;
            videoPlayer.Play();
        }
    }
}
