using UnityEngine;

namespace RIQAudio.Unity
{
    public class RIQAudioSource : MonoBehaviour
    {
        AudioStream stream;
        public string testFileLoc;

        private void Start()
        {
            testFileLoc = Application.streamingAssetsPath + "/mudstep_atomicbeats_old.wav";

            RIQDLL.riq_init_audio_device(testFileLoc);

            // Should return true if RiqInitAudioDevice worked.
            Debug.Log(RIQDLL.riq_is_ready());
        }

        private void Update()
        {
        }

        private void OnDestroy()
        {
            RIQDLL.riq_close_audio_device();
        }
    }
}
