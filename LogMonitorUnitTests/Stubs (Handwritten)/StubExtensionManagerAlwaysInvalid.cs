namespace LogMonitor.UnitTests.Stubs__Handwritten_
{
    internal sealed class StubExtensionManagerAlwaysInvalid : IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            return false;
        }
    }
}