using System;
using System.Linq;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Features.ObservableExtensions.AnimatorExtensions
{
    public static class AnimatorExtensions
    {
        public static IObservable<Unit> WaitUntilAnimationEndsAsObservable(this Animator animator, int state,
                                                                           int layerIndex = 0, float normalizedTimeOffset = 0f)
        {
            return animator.WaitUntilAnimationEnds(state, layerIndex, normalizedTimeOffset).ToObservable();
        }

        private static IEnumerator WaitUntilAnimationEnds(this Animator animator, int state, int layerIndex = 0,
                                                          float normalizedTimeOffset = 0f)
        {
            yield return animator.WaitUntilAnimationEnds(new[] {state}, layerIndex, normalizedTimeOffset);
        }

        private static IEnumerator WaitUntilAnimationEnds(this Animator animator, int[] states, int layerIndex,
                                                          float normalizedTimeOffset)
        {
            yield return animator.WaitUntilAnimationIsPlayed(states, layerIndex);

            while (animator != null && states.Contains(animator.GetCurrentAnimatorStateInfo(layerIndex).fullPathHash)
                && !animator.IsInTransition(layerIndex) &&
                   animator.GetCurrentAnimatorStateInfo(layerIndex).normalizedTime <=
                   (0.95f - normalizedTimeOffset))
                yield return null;
        }
        
        private static IEnumerator WaitUntilAnimationIsPlayed(this Animator animator, int[] states, int layerIndex = 0)
        {
            yield return null;

            while (animator != null && IsInTransition())
                yield return null;
            
            bool IsInTransition() => (!states.Contains(animator.GetCurrentAnimatorStateInfo(layerIndex).fullPathHash)|| animator.IsInTransition(layerIndex));
        }
    }
}