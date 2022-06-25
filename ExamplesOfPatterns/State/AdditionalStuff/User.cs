using ExamplesOfPatterns.Common;

namespace State.AdditionalStuff
{
    public class User : UserBase
    {
        public bool IsOwnerOfDocument { get; set; }
        public bool IsEditor { get; set; }
    }
}