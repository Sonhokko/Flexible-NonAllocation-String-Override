# FlexibleNonAllocationExtencions
1.Simple implementation non allocation string override.
Example will be used at Unity 3D Engine, with Text Component. You can use it with any Text, TMP etc.
A good solution would be to use this whenever you have frequently changing text. Example:
HP Bar, EXP Bar, Currency counter etc.

2.NonAllocation Compare
Extension for utilizing unallocated invocation and processing the comparison of two types. Works only in Unity 3D, as UnsafeUtility is used.

```csharp
using LurkingNinja.PlayerLoop;
using UnityEngine;

public class TestPlayerLoop : IUpdate
{
    [RuntimeInitializeOnLoadMethod]
    private static void Awake()
    {
        var testPlayerLoop = new TestPlayerLoop();
        PlayerLoop.AddListener(testPlayerLoop);
    }

    public void OnUpdate() => Debug.Log("Update");
}
```
