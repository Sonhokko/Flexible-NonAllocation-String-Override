public static class MemCmpExtensions
{
  public static unsafe bool MemCmpCompare<T>(this ref T a, ref T b) where T : unmanaged
  {
    fixed (T* ptr1 = &a)
      fixed(T* ptr2 = &b)
        return UnsafeUtility.MemCmp(ptr1, ptr2, UnsafeUtility.SizeOf<T>()) == 0;
  }
}
