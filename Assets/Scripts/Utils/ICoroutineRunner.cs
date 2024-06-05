using System.Collections;
using UnityEngine;

namespace Utils
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}