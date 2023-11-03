using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.IO;

namespace RPM_Coursework
{
    public enum MessageType : int
    {
        DefaultMessage,

        ConnectMessage,
        ConnectInformMessage,

        DisconnectMessage,
        DisconnectInformMessage,

        ClientListMessage,
        ServerShutdownMessage
    }
    public enum MessageContentType : int
    {
        None,
        Text,
        Image,
        File
    }

    public class ContentTypeMismatchException : Exception { }
    public class Message
    {
        public IPEndPoint[] TargetsEndPoints { get; set; }
        public IPEndPoint SenderEndPoint { get; set; }
        public string SenderName { get; set; }
        public MessageType Type { get; set; }
        public MessageContentType ContentType { get; set; }

        private byte[] content;

        public Message(IPEndPoint[] targetsEP, MessageType type)
        {
            TargetsEndPoints = targetsEP;
            Type = type;
            content = new byte[0];
        }
        public Message(IPEndPoint[] targetsEP, MessageType type, byte[] content)
        {
            TargetsEndPoints = targetsEP;
            Type = type;
            this.content = content;
        }

        // instead of multi-function i decided to split it
        // into type-specific ones? no idea if it's efficient
        // than the other ones

        // also, the file one is simply returning the content without any
        // op, may turn it into a raw content unload method (R-CUM ) 
        public string RetrieveText()
        {
            if (ContentType != MessageContentType.Text) throw new ContentTypeMismatchException();
            return Encoding.UTF8.GetString(content);
        }
        public Bitmap RetrieveImage()
        {
            if (ContentType != MessageContentType.Image) throw new ContentTypeMismatchException();
            Bitmap result;
            using (MemoryStream ms = new MemoryStream(content))
            {
                result = new Bitmap(ms);
            }
            return result;
        }
        public byte[] RetrieveDocument()
        {
            if (ContentType != MessageContentType.File) throw new ContentTypeMismatchException();
            return content;
        }
        internal byte[] RetrieveRaw () => content;
    }
}
