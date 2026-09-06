using System.Numerics;

namespace JeremyAnsel.DirectX.DirectSound;

public struct Ds3dListenerDesc
{
    public int dwSize;
    public Vector3 vPosition;
    public Vector3 vVelocity;
    public Vector3 vOrientFront;
    public Vector3 vOrientTop;
    public float flDistanceFactor;
    public float flRolloffFactor;
    public float flDopplerFactor;
}
