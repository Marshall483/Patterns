using System.IO;
using State.AdditionalStuff;

namespace State
{
    public interface IDocumentState
    {
        void Edit(string changes);
        
        void Attach(AttachmentType attachmentType, Stream attachmentContent);

        string Open();
        
        void ChangeState(IDocumentState newState);

        void ToModerationState();

        void ToPublishedState();
    }
}