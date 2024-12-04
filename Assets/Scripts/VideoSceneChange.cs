using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneChange : MonoBehaviour
{
    VideoPlayer video;

    // plays animation and checks to see if it looped once
    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }


    //after loop, plays next scene in the hierarchy (may need to change depending on where anim is put)
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }
}
