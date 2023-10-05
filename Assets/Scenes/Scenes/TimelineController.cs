using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector;

    private void Start()
    {
        // Tìm và gán Playable Director trong scene (bằng cách kéo thả GameObject chứa Playable Director vào trường này trong Inspector).
        playableDirector = FindObjectOfType<PlayableDirector>();
        playableDirector.Stop(); // Dừng timeline khi khởi động scene.

        // Đảm bảo bạn đã cài đặt "Loop" trong Inspector của Timeline nếu bạn muốn nó chạy liên tục.
    }

    public void PlayTimeline()
    {
        // Bắt đầu timeline.
        playableDirector.Play();
    }
}
