using ChoroidXR.Extentions;
using UnityEngine;

/// <summary>
/// usage: put this script on any transform to detect it's velocity without using rigidbody using translation movement
/// </summary>
public class VelocityEstimator : MonoBehaviour
{
    public Vector3 EstimatedVelocity { get; private set; }
    public float Speed;

    private Vector3 _positoinFirstFrame;
    private Vector3 _positoinSecondFrame;
    private bool _firstFrame = true;

    void Awake()
    {
        _positoinFirstFrame = transform.localPosition;
        _positoinSecondFrame = transform.localPosition;
    }

    void FixedUpdate()
    {
        if (_firstFrame)
        {
            _positoinFirstFrame = transform.localPosition;
            _firstFrame = false;
        }
        else
        {
            _positoinSecondFrame = transform.localPosition;
            _firstFrame = true;
            EstimatedVelocity = new Vector3(
                (_positoinSecondFrame.x - _positoinFirstFrame.x) / Time.deltaTime,
                (_positoinSecondFrame.y - _positoinFirstFrame.y) / Time.deltaTime,
                (_positoinSecondFrame.z - _positoinFirstFrame.z) / Time.deltaTime);
        }
        Speed = EstimatedVelocity.magnitude;
    }
}
