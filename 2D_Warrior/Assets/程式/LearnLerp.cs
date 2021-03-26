using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    public float a = 0;
    public float b = 100;

    public Vector2 V2A = new Vector2(0, 0);
    public Vector2 V2B = new Vector2(100, 100);

    private void Start()
    {
        float result = Mathf.Lerp(0, 100, 0.5f);
        print("0.100差值結果" + result);

    }

    private void Update()
    {
        a = Mathf.Lerp(a, b, 0.5f);

        V2A = Vector2.Lerp(V2A, V2B, 0.5f);
    }


}
