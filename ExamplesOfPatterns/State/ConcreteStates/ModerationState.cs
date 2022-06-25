namespace State.ConcreteStates
{
    public class ModerationState : DocumentStateBase
    {
        public ModerationState(Document document) : base(document)
        { }
        
        public override void ToModerationState()
        {
            // Do nothing
        }

        public override void ToPublishedState()
        {
            Document.State = new PublishedState(Document);
        }
    }
}