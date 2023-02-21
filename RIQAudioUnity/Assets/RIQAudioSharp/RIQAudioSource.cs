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

            RIQDLL.RiqInitAudioDevice();

            // Should return true if RiqInitAudioDevice worked.
            Debug.Log(RIQDLL.IsRiqReady());
        }

        private void Update()
        {
        }

        private void OnDestroy()
        {
            RIQDLL.RiqCloseAudioDevice();
        }
    }
}
