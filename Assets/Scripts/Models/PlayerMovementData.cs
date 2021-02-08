using System;
[Serializable]
public class PlayerMovementData 
{
    public float speed = 3f;
    public float turnSmootVelocity;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.25f;
    public float turnSmoothTime = 0.1f;
}
