using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Vector2 firePoint, Vector2 targetPosition)
    {
        Vector2 toTarget = targetPosition - firePoint;
        Quaternion bulletRotation = Quaternion.FromToRotation(Vector2.left, toTarget);

        Instantiate(BulletPrefab, firePoint, bulletRotation);
    }
}
