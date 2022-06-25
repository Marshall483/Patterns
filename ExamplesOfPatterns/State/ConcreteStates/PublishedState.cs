using System;
using System.IO;
using State.AdditionalStuff;

namespace State.ConcreteStates
{
    public class PublishedState: DocumentStateBase
    {
        public PublishedState(Document document) : base(document)
        { }

        public override void Edit(string changes)
        {
            throw new Exception("Cannot edit a Published document");
        }

        public override void Attach(AttachmentType attachmentType, Stream attachmentContent)
        {
            throw new Exception("Cannot Attach to a Published document");
        }
        
        public override void ToModerationState()
        {
            Document.State = new ModerationState(Document);
        }

        public override void ToPublishedState()
        {
            // Do nothing.
        }
    }
}