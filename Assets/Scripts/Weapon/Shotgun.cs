using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int _primaryBulletsCount;
    [SerializeField] private Bullet _secondaryBulletPrefab;
    [Space]
    [SerializeField] private float _spreadY;
    [SerializeField] private float _randomSpreadAngle;

    private Vector2 _bulletSpreadY;

    private void OnValidate()
    {
        _bulletSpreadY = new Vector2(0, _spreadY / 2);
    }

    public override void Shoot(Vector2 firePoint, Vector2 targetPosition)
    {
        Vector2 toTarget = targetPosition - firePoint;
        Quaternion minBulletRotation = Quaternion.FromToRotation(Vector2.left, toTarget - _bulletSpreadY);
        Quaternion maxBulletRotation = Quaternion.FromToRotation(Vector2.left, toTarget + _bulletSpreadY);

        Quaternion primaryBulletRotation;
        int _primaryBulletAnglesCount = _primaryBulletsCount + 1;
        for (int i = 1; i < _primaryBulletAnglesCount; i++)
        {
            primaryBulletRotation = Quaternion.Lerp(minBulletRotation, maxBulletRotation, (float)i / _primaryBulletAnglesCount);
            Instantiate(BulletPrefab, firePoint, primaryBulletRotation);
        }

        Quaternion secondaryBulletRotation;
        int _secondaryBulletAnglesCount = _primaryBulletAnglesCount - 1;
        for (int i = 1; i < _secondaryBulletAnglesCount; i++)
        {
            secondaryBulletRotation = Quaternion.Lerp(minBulletRotation, maxBulletRotation, (float)i / _secondaryBulletAnglesCount);
            Instantiate(_secondaryBulletPrefab, firePoint, secondaryBulletRotation);
        }
    }
}
