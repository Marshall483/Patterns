using System;
using System.Collections.Generic;
using System.IO;
using State.AdditionalStuff;
using State.Providers;

namespace State.ConcreteStates
{
    public abstract class DocumentStateBase : IDocumentState
    {
        public Document Document { get; set; }

        private protected Dictionary<AttachmentType, Action<Stream>> AttachmentActionMap;

        public DocumentStateBase(Document document)
        {
            Document = document;
            
            AttachmentActionMap = new Dictionary<AttachmentType, Action<Stream>>
            {
                {AttachmentType.Link, AttachLink},
                {AttachmentType.Image, AttachImage}
            };
        }
        
        public virtual void Edit(string changes)
        {
            if (IsCurrentUserAllowedToEdit())
            {
                Document.DocumentContent += changes;
            }
        }

        public virtual void Attach(AttachmentType attachmentType, Stream attachmentContent)
        {
            if (IsCurrentUserAllowedToEdit())
            {
                AttachmentActionMap[attachmentType](attachmentContent);
            }
        }

        public virtual string Open()
        {
            if (IsCurrentUserAllowedToEdit())
            {
                return Document.DocumentContent;
            }

            return null;
        }

        public virtual void ChangeState(IDocumentState newState)
        {
            Document.State = newState;
        }

        public abstract void ToModerationState();
        public abstract void ToPublishedState();

        private void AttachLink(Stream attachment)
        {
            // Attaching link
        }
        
        private void AttachImage(Stream attachment)
        {
            // Attaching Image
        }
        
        private bool IsCurrentUserAllowedToEdit()
        {
            return UserProvider.GetCurrentUser().IsEditor 
                   || UserProvider.GetCurrentUser().IsOwnerOfDocument;
        }
    }
}