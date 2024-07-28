using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class CoroutineExtensions
{
    private static Dictionary<float, WaitForSeconds> _wfsDict;

    private static WaitForEndOfFrame _wfef;
    private static WaitForEndOfFrame wfef => _wfef ?? new WaitForEndOfFrame();

    public static WaitForSeconds GetCachedWFS(float s)
    {
        _wfsDict ??= new();

        if (_wfsDict.TryGetValue(s, out var wfs))
            return wfs;
        else
        {
            wfs = new WaitForSeconds(s);
            _wfsDict.Add(s, wfs);
            return wfs;
        }
    }

    public static IEnumerator ExecuteAfterSeconds(float s, Action action)
    {
        yield return GetCachedWFS(s);

        action?.Invoke();
    }

    public static IEnumerator ExecuteOnEndOfFrame(Action action)
    {
        yield return wfef;

        action?.Invoke();
    }
}
