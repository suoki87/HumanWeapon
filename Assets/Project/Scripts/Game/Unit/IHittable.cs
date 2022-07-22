

using Actor;



public interface IHittable
{
    void OnHit(Unit attacker, float damage, HitType hitType = HitType.Normal);
}