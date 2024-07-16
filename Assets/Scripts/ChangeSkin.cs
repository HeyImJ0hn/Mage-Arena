using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public AnimatorOverrideController purpleAnim;
    public AnimatorOverrideController redAnim;
    public AnimatorOverrideController defaultAnim;

    private void Start() {
    }

    public void DefaultSkin() {
        GetComponent<Animator>().runtimeAnimatorController = defaultAnim as RuntimeAnimatorController;
    }
    
    public void PurpleSkin() {
        GetComponent<Animator>().runtimeAnimatorController = purpleAnim as RuntimeAnimatorController;
    }

    public void RedSkin() {
        GetComponent<Animator>().runtimeAnimatorController = redAnim as RuntimeAnimatorController;
    }

}
