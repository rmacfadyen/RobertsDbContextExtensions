namespace RobertsDbContextExtensions
{
    internal class ReaderStream : Stream
    {
        private readonly IDataReader dataReader;
        private bool disposed;
        private long currentPosition;

        public ReaderStream(IDataReader adataReader)
        {
            dataReader = adataReader;
            dataReader.Read();
        }

        /// <summary>
        /// Not supported
        /// </summary>
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Not supported
        /// </summary>
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int index, int count)
        {
            var returned = dataReader.GetBytes(0, currentPosition, buffer, index, count);

            if (returned > 0)
            {
                currentPosition += returned;
            }

            return (int)returned;
        }

        /// <summary>
        /// Not supported
        /// </summary>
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override long Length
        {
            get { throw new NotSupportedException(); }
        }

        public override long Position
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (dataReader != null)
                    {
                        dataReader.Dispose();
                    }
                    disposed = true;
                }
            }
            base.Dispose(disposing);
        }

        public override void Flush()
        {
            throw new NotSupportedException();
        }
    }
}
