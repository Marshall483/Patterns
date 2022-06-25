using System;
using System.Collections.Generic;
using System.IO;
using State.AdditionalStuff;
using State.Providers;

namespace State.ConcreteStates
{
    public class DraftState : DocumentStateBase
    {
        public DraftState(Document document) : base(document)
        { }

        public override void ToModerationState()
        {
            Document.State = new ModerationState(Document);
        }

        public override void ToPublishedState()
        {
            throw new Exception("Cannot publish without moderation");
        }
    }
}