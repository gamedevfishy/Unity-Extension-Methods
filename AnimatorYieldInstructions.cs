using UnityEngine;

/// <summary>
/// Waits for the specified Animator state to be entered and then
/// waits until that state has finished playing (normalizedTime >= 1).
/// </summary>
public class WaitForAnimatorState : CustomYieldInstruction
{
    private readonly Animator animator;
    private readonly int layer;
    private readonly string stateName;
    private bool stateEntered;

    public WaitForAnimatorState(Animator animator, string stateName, int layer = 0)
    {
        this.animator = animator;
        this.stateName = stateName;
        this.layer = layer;
    }

    public override bool keepWaiting
    {
        get
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layer);

            if (!stateEntered)
            {
                if (stateInfo.IsName(stateName))
                    stateEntered = true;

                return true;
            }

            return stateInfo.IsName(stateName) && stateInfo.normalizedTime < 1f;
        }
    }
}

/// <summary>
/// Waits until the Animator enters the specified state.
/// Useful after calling Play(), CrossFade(), or setting a trigger.
/// </summary>
public class WaitForAnimatorStateEnter : CustomYieldInstruction
{
    private readonly Animator animator;
    private readonly int layer;
    private readonly string stateName;

    public WaitForAnimatorStateEnter(Animator animator, string stateName, int layer = 0)
    {
        this.animator = animator;
        this.stateName = stateName;
        this.layer = layer;
    }

    public override bool keepWaiting
    {
        get
        {
            return !animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName);
        }
    }
}

/// <summary>
/// Waits until the specified Animator state is no longer active.
/// Useful when a state may transition out before reaching its end.
/// </summary>
public class WaitForAnimatorStateExit : CustomYieldInstruction
{
    private readonly Animator animator;
    private readonly int layer;
    private readonly string stateName;

    public WaitForAnimatorStateExit(Animator animator, string stateName, int layer = 0)
    {
        this.animator = animator;
        this.stateName = stateName;
        this.layer = layer;
    }

    public override bool keepWaiting
    {
        get
        {
            return animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName);
        }
    }
}

/// <summary>
/// Captures the Animator's current state when created and waits
/// until that state has finished playing.
/// Does not require knowing the state's name.
/// </summary>
public class WaitForCurrentAnimatorState : CustomYieldInstruction
{
    private readonly Animator animator;
    private readonly int layer;
    private readonly int stateHash;

    public WaitForCurrentAnimatorState(Animator animator, int layer = 0)
    {
        this.animator = animator;
        this.layer = layer;
        stateHash = animator.GetCurrentAnimatorStateInfo(layer).fullPathHash;
    }

    public override bool keepWaiting
    {
        get
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layer);

            return stateInfo.fullPathHash == stateHash &&
                   stateInfo.normalizedTime < 1f;
        }
    }
}