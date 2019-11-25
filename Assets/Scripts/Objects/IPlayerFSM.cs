using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerFSM
{
    IEnumerator Idle();
    IEnumerator Walk();
    IEnumerator Jump();
    IEnumerator Attack();
    IEnumerator Hurt();
}
