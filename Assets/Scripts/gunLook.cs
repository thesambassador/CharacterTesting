using UnityEngine;
using System.Collections;
using SmoothMoves;

public class gunLook : MonoBehaviour {

    public BoneAnimation boneAnimation;

    private Transform _armTransform;
    private Vector3 _armRotation;
    private Vector3 _mouseOffset;
    private Vector3 _transformScreenPosition;

	// Use this for initialization
	void Start () {
        _armTransform = boneAnimation.GetBoneTransform("arms");

        boneAnimation.Play("stand");
        

        //_armRotation = _armTransform.rotation.

	}
	
	// Update is called once per frame
    void Update()
    {
        boneAnimation.Play("stand");
    }

	void LateUpdate () {

        //get the angle between the mouse and the player's gun
        //0 = pointing straight to the right, 180 = pointing straight to the left
        Vector2 mousePos = Input.mousePosition;
        Vector2 playerScreenPos = Camera.main.WorldToScreenPoint(_armTransform.position);

        _mouseOffset = (mousePos - playerScreenPos);

        _armRotation.z = Mathf.Atan2(_mouseOffset.y, _mouseOffset.x) * Mathf.Rad2Deg;

        //flip the character if your mouse is to the right of the character
        Vector2 newScale = new Vector2(-1, 1);

        if (mousePos.x < playerScreenPos.x)
        {
            newScale.x = 1;
        }
        else
        {
            newScale.x = -1;
            _armRotation.z = 180 - _armRotation.z;
        }

        Debug.Log(_armRotation.z);

        this.transform.localScale = newScale;
        _armTransform.eulerAngles = _armRotation;


	}
}
