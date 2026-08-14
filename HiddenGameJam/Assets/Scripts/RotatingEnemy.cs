using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class RotatingEnemy : MonoBehaviour
{
    public int RotationDegrees = 180;
    public float[] rotations;
    
    public int DegreesPerSecond = 30;
    public float WaitSec = 2f;


    private Rigidbody2D _rb2d;
    private float _currentRotation;
    private int rotationNum;
    private bool direction = false;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        direction= false;
        rotationNum = 0;
        StartCoroutine(Spin());
    }

    void FixedUpdate()
    {
        _rb2d.MoveRotation(_currentRotation);
    }

    private IEnumerator Spin()
    {
        _currentRotation = _rb2d.rotation;
        float nextRotation;
        if (rotations != null)
        {
            nextRotation = rotations[rotationNum];
        }
        else
        {
            nextRotation = _currentRotation + RotationDegrees;
        }

        while (true)
        {
            _currentRotation = Mathf.MoveTowards(_currentRotation, nextRotation, DegreesPerSecond * Time.deltaTime);
            if (_currentRotation == nextRotation)
            {
                yield return new WaitForSeconds(WaitSec);

                _currentRotation %= 360f;

                if (rotations != null)
                {
                    if (!direction)
                    {
                        rotationNum++;
                    }
                    else
                    {
                        rotationNum--;
                    }

                    if (rotationNum >= rotations.Length)
                    {
                        direction = true;
                        rotationNum -= 2;
                    }
                    if (rotationNum < 0)
                    {
                        direction = false;
                        rotationNum += 2;
                    }  
                    nextRotation = rotations[rotationNum];
                }
                else
                {
                    nextRotation = _currentRotation + RotationDegrees;
                }
            }
            else
            {
                yield return null;
            }
        }
    }
}
