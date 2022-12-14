using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Client
{
    public abstract class  PacketSender
    {
        private MemoryStream mstream;

        protected internal void Init()
        {
            mstream = new MemoryStream();
        }

        protected internal void PWriteBytes(byte[] value)
        {
            mstream.Write(value, 0, value.Length);
        }

        protected internal void PWriteInt32(int value)
        {
            PWriteBytes(BitConverter.GetBytes(value));
        }

        protected internal void PWriteInt16(short val)
        {
            PWriteBytes(BitConverter.GetBytes(val));
        }

        protected internal void PWriteUInt16(UInt16 val)
        {
            PWriteBytes(BitConverter.GetBytes(val));
        }
        protected internal void PWriteUInt32(UInt32 val)
        {
            PWriteBytes(BitConverter.GetBytes(val));
        }

        protected internal void PWriteByte(byte value)
        {
            mstream.WriteByte(value);
        }

        protected internal void PWriteDouble(double value)
        {
            PWriteBytes(BitConverter.GetBytes(value));
        }

        protected internal void PWriteInt64(long value)
        {
            PWriteBytes(BitConverter.GetBytes(value));
        }

        protected internal void PWriteString(string value)
        {
            if (value != null)
            {
                PWriteBytes(Encoding.ASCII.GetBytes(value));
                PWriteInt16(0);
            }
        }

        protected internal void PWriteStrinP(string value)
        {
            if (value != null)
            {
                PWriteBytes(Encoding.ASCII.GetBytes(value));
            }
        }

        protected internal void PWriteStringH(string value)
        {
            if (value != null)
            {
                PWriteInt32(value.Length);
                PWriteBytes(Encoding.ASCII.GetBytes(value));
            }
        }

        protected internal void PWriteStringL(string name, int count)
        {
            if (name != null)
            {
                PWriteBytes(Encoding.GetEncoding(1251).GetBytes(name));
                PWriteBytes(new byte[count - name.Length]);
            }
        }

        public byte[] ToByteArray()
        {
            return mstream.ToArray();
        }

        public long Length
        {
            get { return mstream.Length; }
        }

        protected internal abstract void Write();
    }
}
