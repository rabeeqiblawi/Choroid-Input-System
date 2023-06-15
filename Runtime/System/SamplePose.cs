using ChoroidXR.VRposeInputMapper;

public class SamplePose : VRPose
{
    public override bool PoseCondition
    {
        //when the right controller is above the headset for a certain amount of time a pose is registered.
        get { return RightController.transform.position.y > Hmd.transform.position.y; }
    }
}
