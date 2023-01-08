using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickables : MonoBehaviour
{
	public abstract int Index { get; set; }
	public abstract int Value { get; set; }
}
