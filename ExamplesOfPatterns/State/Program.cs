using System.IO;
using System.Text;
using State.AdditionalStuff;
using State.ConcreteStates;

namespace State
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var document = new Document();
            
            document.Edit("Hello, world!");
            document.Attach(AttachmentType.Image, File.Open("/path/to/img", FileMode.Open));
            document.Attach(
                AttachmentType.Link, 
                new MemoryStream(Encoding.ASCII.GetBytes("www.pornhub.com")));
            document.Edit("Goodbye, world!");
            
            document.Save();
            
            document.ToModerationState();
            
            document.Edit("Alex Jordan moderated and said its OK.");
            
            document.ToPublishedState();

            document.Open();
        }
    }
}