using System.Numerics;

namespace JeremyAnsel.DirectX.DirectSound;

public struct Ds3dBufferDesc
{
    public int dwSize;
    public Vector3 vPosition;
    public Vector3 vVelocity;
    public int dwInsideConeAngle;
    public int dwOutsideConeAngle;
    public Vector3 vConeOrientation;
    public int lConeOutsideVolume;
    public float flMinDistance;
    public float flMaxDistance;
    public Ds3dMode dwMode;
}
