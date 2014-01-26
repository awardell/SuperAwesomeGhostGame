using UnityEngine;
using System.Collections;

public class EnemyMirror : EnemyMove {

	public bool mirrorX = false;
	public bool mirrorY = false;
	public float speed = 1;

	public bool everyOther = false;
	private bool isOther = false;

	public bool repeatedlyFlip = false;
	public float flipTimer = 3f;

	private PlayerController pc;

	// Use this for initialization
	void Start () {
		pc = player.GetComponent<PlayerController> ();
		if (repeatedlyFlip) { StartFlipping (); }
	}

	private IEnumerator flipMirrors()
	{
		yield return new WaitForSeconds (flipTimer);
		mirrorX = !mirrorX;
		mirrorY = !mirrorY;
		StartCoroutine ("flipMirrors");
	}

	private void StartFlipping()
	{
		StartCoroutine ("flipMirrors");
	}

	// Update is called once per frame\
	protected void Update () {
		if (everyOther && pc.direction != pc.prevDirection) { isOther = !isOther; }
		UpdatePrev ();
		if (!isOther) {
			this.rigidbody2D.velocity = new Vector3(
				player.rigidbody2D.velocity.x * (mirrorX ? -1 : 1) * speed,
				player.rigidbody2D.velocity.y * (mirrorY ? -1 : 1) * speed
			);
		}
	}
}
