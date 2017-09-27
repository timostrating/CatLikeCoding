using UnityEngine;

public class FPSCounter : MonoBehaviour {

    public int AvarageFPS { get; private set; }
    public int HighestFPS { get; private set; }
    public int LowestFPS { get; private set; }

    [SerializeField]
    private int frameRange = 60;

    int[] fpsBuffer;
    int fpsBufferIndex;

    void InitializeBuffer () {
        if (frameRange < 1)
            frameRange = 1;

        fpsBuffer = new int[frameRange];
        fpsBufferIndex = 0;
    }

    void Update () {
        if (fpsBuffer == null || fpsBuffer.Length != frameRange)
            InitializeBuffer ();

        UpdateBuffer ();
        CalculateFPS ();
    }

    void UpdateBuffer () {
        fpsBuffer[fpsBufferIndex++] = (int) (1f / Time.unscaledDeltaTime);
        if (fpsBufferIndex >= frameRange)
            fpsBufferIndex = 0;
    }

    void CalculateFPS () {
        int sum = 0;
        int highest = 0;
        int lowest = int.MaxValue;
        for (int i = 0; i < frameRange; i++) {
            int fps = fpsBuffer[i];
            sum += fps;
            if (highest < fps) {
                highest = fps;
            }
            if (lowest > fps) {
                lowest = fps;
            }
        }

        AvarageFPS = sum / frameRange;
        HighestFPS = highest;
        LowestFPS = lowest;
    }
}