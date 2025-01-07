
public class HpEnemy : HpBase
{
	protected override void Death()
	{
		base.Death();
		gameObject.SetActive(false);
	}
}
