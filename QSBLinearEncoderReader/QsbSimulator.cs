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
        static Random rand = new Random();

        private DateTime _lastTick;
        private uint _lastTimestamp;

        public QsbSimulator()
        {
            _lastTick = DateTime.Now;
            _lastTimestamp = (uint)rand.Next();
        }

        public void ReadEncoderCount(out int encoderCount, out uint timestamp)
        {
            _lastTimestamp = _lastTimestamp + 1;
            _lastTick = _lastTick.AddMilliseconds(1.953125);

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
