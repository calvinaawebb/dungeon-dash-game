using UnityEngine;
using System.Collections;

// Basic demonstration of a music system that uses PlayScheduled to preload and sample-accurately
// stitch two AudioClips in an alternating fashion.  The code assumes that the music pieces are
// each 16 bars (4 beats / bar) at a tempo of 140 beats per minute.
// To make it stitch arbitrary clips just replace the line
//   nextEventTime += (60.0 / bpm) * numBeatsPerSegment
// by
//   nextEventTime += clips[flip].length;

[RequireComponent(typeof(AudioSource))]
public class Audio_Controller : MonoBehaviour
{
    public float bpm = 95;
    public int numBeatsPerSegment = 124;
    public AudioSource[] audioSources = new AudioSource[2];

    private double nextEventTime;
    public bool running = true;
    private int flip = 0;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Audio").Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        nextEventTime = AudioSettings.dspTime + 0.4f;
    }

    void Update()
    {
        if (!running)
        {
            return;
        }

        double time = AudioSettings.dspTime;

        if (time + 0.5f > nextEventTime)
        {
            // We are now approx. 0.5 second before the time at which the sound should play,
            // so we will schedule it now in order for the system to have enough time
            // to prepare the playback at the specified time. This may involve opening
            // buffering a streamed file and should therefore take any worst-case delay into account.
            audioSources[flip].PlayScheduled(nextEventTime);

            Debug.Log("Scheduled audio " + flip + " to start at time " + nextEventTime);

            // Place the next event 16 beats from here at a rate of 140 beats per minute
            nextEventTime += (60.0f / bpm) * numBeatsPerSegment;

            // Flip between two audio sources so that the loading process of one does not interfere with the one that's playing out
            flip = 1 - flip;

            if (flip == 0)
            {
                running = false;
            }
        }
    }
}
