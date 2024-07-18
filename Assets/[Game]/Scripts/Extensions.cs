using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Extensions
{
    private static readonly Dictionary<float, WaitForSeconds> _wfsDict;

    private static readonly WaitForEndOfFrame _wfef;
    private static WaitForEndOfFrame wfef => _wfef ?? new WaitForEndOfFrame();

    public static IEnumerator ExecuteAfterSeconds(float s, Action action)
    {
        if (_wfsDict.TryGetValue(s, out var wfs))
            yield return wfs;
        else
        {
            wfs = new WaitForSeconds(s);
            _wfsDict.Add(s, wfs);
            yield return wfs;
        }

        action?.Invoke();
    }

    public static IEnumerator ExecuteOnEndOfFrame(Action action)
    {
        yield return wfef;

        action?.Invoke();
    }
}
