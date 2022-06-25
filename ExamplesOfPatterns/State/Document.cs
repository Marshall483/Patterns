using System.IO;
using State.AdditionalStuff;
using State.ConcreteStates;

namespace State
{
    public class Document
    {
        public IDocumentState State { get; set; }

        public string DocumentContent { get; set; }

        public Document()
        {
            State = new DraftState(this);
        }

        public void Save()
        {
            // Save a zipped file to a database
        }

        public void Edit(string changes)
        {
            State.Edit(changes);
        }

        public void Attach(AttachmentType attachmentType, Stream attachmentContent)
        {
            State.Attach(attachmentType, attachmentContent);
        }

        public string Open()
        {
            return State.Open();
        }

        public void ChangeState(IDocumentState newState)
        {
            State.ChangeState(newState);
        }

        public void ToModerationState()
        {
            State.ToModerationState();
        }
        
        public void ToPublishedState()
        {
            State.ToPublishedState();
        }
    }
}