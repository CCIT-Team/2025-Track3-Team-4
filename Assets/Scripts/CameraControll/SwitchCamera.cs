using System.Collections;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _targets = null;

    private GameObject _nowFllowingTarget;

    private float _dt = 0;

    [SerializeField]
    private float _moveTime = 5;

    private bool _isFollowing = false;

    void Awake()
    {
        if (_targets == null)
        {
            _targets = new GameObject[0];
            return;
        }
        _nowFllowingTarget = _targets[0];
    }

    private IEnumerator MoveToNewCamera()
    {
        _isFollowing = true;
        while (true)
        {
            _dt += Time.fixedDeltaTime;
            float nowStep = _dt / _moveTime;
            transform.position = Vector3.Lerp(transform.position, _nowFllowingTarget.transform.position, nowStep);
            transform.rotation = Quaternion.Lerp(transform.rotation, _nowFllowingTarget.transform.rotation, nowStep);
            if (nowStep >= 1)
            {
                break;
            }
            yield return null;
        }
        _isFollowing = false;
        transform.SetParent(_nowFllowingTarget.transform);
    }

    public void SwitchToFollwingCamera()
    {
        _dt = 0;
        if (_isFollowing == false)
        {
            StartCoroutine(MoveToNewCamera());
        }
    }

    public void ChangeFollwingTarget(uint index)
    {
        if (_targets != null || index < _targets.Length)
        {
            _nowFllowingTarget = _targets[index];
            SwitchToFollwingCamera();
        }
    }
}
