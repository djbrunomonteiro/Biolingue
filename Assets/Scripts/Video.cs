using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;


    void Start()
    {
        StartCoroutine(playVideo());
    }

IEnumerator playVideo()
{
videoPlayer.Prepare();
WaitForSeconds waitForSeconds = new WaitForSeconds(0.3f);
while (!videoPlayer.isPrepared)
{
    yield return waitForSeconds;
    break;
}
rawImage.texture = videoPlayer.texture;
videoPlayer.Play();
}
   
}
