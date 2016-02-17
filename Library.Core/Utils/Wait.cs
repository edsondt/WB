using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Core.Utils
{
    public class Wait
    {
        private readonly    Func<bool>[]    _functions;
        private readonly    int             _timeoutInSeconds;

        private             Timer           _timer;
        private             bool            _success            = false;

        private Wait(int timeoutInSeconds, params Func<bool>[] functions)
        {
            _functions          = functions;
            _timeoutInSeconds   = timeoutInSeconds;
        }

        public static void Until(params Func<bool>[] functions)
        {
            Until(30, functions);
        }

        public static void Until(int timeoutInSeconds, params Func<bool>[] functions)
        {
            new Wait(timeoutInSeconds, functions)
                .Run();
        }

        public void Run()
        {
            var waitHandle = new AutoResetEvent(false);
            _timer = new Timer(Callback, waitHandle, 1000, 500);

            waitHandle.WaitOne(1000 * _timeoutInSeconds);
            _timer.Dispose();

            if (!_success)
            {
                // For now, we are ignoring if the timeout has elapsed and none of the functions are true.
            }
        }

        private void Callback(object state)
        {
            var waitHandle = (AutoResetEvent)state;

            if (_functions.Any(f => f()))
            {
                _success = true;
                waitHandle.Set();
            }
        }
    }
}
