using System.Collections;
using UnityEngine;

public class SwungWeapon : Weapon
{
    public float swingSpeed;
    public float swingDegrees;

    public override void Attack()
    {
        transform.localEulerAngles = new Vector3(0, 0, -swingDegrees);
        EnableWeapon();
        StartCoroutine(Swing());
    }

    private IEnumerator Swing()
    {
        float degrees = 0;
        while (degrees < swingDegrees * 2)
        {
            transform.Rotate(Vector3.forward, swingSpeed * Time.deltaTime);
            degrees += swingSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        DisableWeapon();
    }

}