using UnityEngine;

namespace RIQAudio.Unity
{
    public class RIQAudioSource : MonoBehaviour
    {
        AudioStream stream;

        private void Start()
        {
            stream = RIQDLL.riq_init(Application.streamingAssetsPath + "/mudstep_atomicbeats_old.wav");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                RIQDLL.riq_play();
        }

        private void OnDestroy()
        {
            RIQDLL.riq_dispose(stream);
        }
    }
}
