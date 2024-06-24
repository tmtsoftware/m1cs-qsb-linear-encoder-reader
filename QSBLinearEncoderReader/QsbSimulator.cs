using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
    internal class QsbSimulator
    {
        private object _lock = new object();

        static Random rand = new Random();

        private DateTime _lastTick;
        private uint _lastTimestamp;

        private ulong _readCount = 0;

        /// <summary>
        /// This class simulates a simulated QSB-D encoder reader.
        /// This class is thread-safe. Public methods and members can
        /// be called or accessed from multiple threads.
        /// </summary>
        public QsbSimulator()
        {
            _lastTick = DateTime.Now;
            _lastTimestamp = (uint)rand.Next();
        }

        public void Connect()
        {
            _readCount = 0;
            var t = Task.Run(async delegate { await Task.Delay(2000); });
            t.Wait();
        }

        public void Disconnect()
        {
            var t = Task.Run(async delegate { await Task.Delay(1000); });
            t.Wait();
        }

        public void ReadEncoderCount(out int encoderCount, out uint timestamp)
        {
            lock (_lock)
            {
                _lastTimestamp = _lastTimestamp + 1;
                _lastTick = _lastTick.AddMilliseconds(1.953125);

                _readCount += 1;
                if (_readCount == 1024 ||
                    _readCount == 2048 ||
                    _readCount == 2049 ||
                    _readCount == 4096 ||
                    _readCount == 4097 ||
                    _readCount == 4098)
                {
                    throw new UnexpectedResponseException("Test of UnexpectedResponseException");
                }

                TimeSpan diff = DateTime.Now - _lastTick;
                if (diff.TotalMilliseconds < 1.953125)
                {
                    Thread.Sleep(2);
                }

                encoderCount = rand.Next(-1000, 1000);
                timestamp = _lastTimestamp;
            }
        }
    }
}
