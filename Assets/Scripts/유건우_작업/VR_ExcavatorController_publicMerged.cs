using UnityEngine;

public class VR_ExcavatorController_publicMerged : MonoBehaviour
{
    [Header("Excavator Parts")]
    public Transform swing;   // 차체 회전
    public Transform boom;    // 붐
    public Transform arm;     // 암
    public Transform bucket;  // 버킷

    [Header("Rotation Settings")]
    public float swingSpeed = 30f;
    public float boomSpeed = 30f;
    public float armSpeed = 30f;
    public float bucketSpeed = 30f;

    [Header("Rotation Angle Limits")]
    public float minSwingAngle = -135f, maxSwingAngle = 135f;
    public float minBoomAngle = -45f, maxBoomAngle = 45f;
    public float minArmAngle = -90f, maxArmAngle = 90f;
    public float minBucketAngle = -90f, maxBucketAngle = 90f;

    float swingAngle, boomAngle, armAngle, bucketAngle;
    Quaternion initSwing, initBoom, initArm, initBucket;

    void Start()
    {
        initSwing = swing.localRotation;
        initBoom = boom.localRotation;
        initArm = arm.localRotation;
        initBucket = bucket.localRotation;
    }

    void Update() => ApplyRotation();

    // === VR에서 스틱 값 주입 (input ∈ [-1, 1]) ===
    public void DriveSwing(float input) =>
        swingAngle = Mathf.Clamp(swingAngle + input * swingSpeed * Time.deltaTime, minSwingAngle, maxSwingAngle);
    public void DriveBoom(float input) =>
        boomAngle = Mathf.Clamp(boomAngle + input * boomSpeed * Time.deltaTime, minBoomAngle, maxBoomAngle);
    public void DriveArm(float input) =>
        armAngle = Mathf.Clamp(armAngle + input * armSpeed * Time.deltaTime, minArmAngle, maxArmAngle);
    public void DriveBucket(float input) =>
        bucketAngle = Mathf.Clamp(bucketAngle + input * bucketSpeed * Time.deltaTime, minBucketAngle, maxBucketAngle);

    void ApplyRotation()
    {
        swing.localRotation = initSwing * Quaternion.AngleAxis(swingAngle, Vector3.forward);
        boom.localRotation = initBoom * Quaternion.AngleAxis(boomAngle, Vector3.right);
        arm.localRotation = initArm * Quaternion.AngleAxis(armAngle, Vector3.right);
        bucket.localRotation = initBucket * Quaternion.AngleAxis(bucketAngle, Vector3.right);
    }
}

