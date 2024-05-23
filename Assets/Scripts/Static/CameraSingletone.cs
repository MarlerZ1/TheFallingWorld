using UnityEngine;

public class CameraSingletone : MonoBehaviour
{
    private static Camera _cm;

    private void Awake()
    {
        _cm = GetComponent<Camera>();
    }

    public static Camera GetMainCamera()
    {
        return _cm;
    }
};
