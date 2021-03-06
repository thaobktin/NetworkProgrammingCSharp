using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskParallelization
{
    public class ParallelSender
    {
        private readonly IList<string> _contents;
        //private readonly ErrorLogger _errorLogger;

        public ParallelSender(IList<string> contents)
        {
            _contents = contents;
            //_errorLogger = new ErrorLogger();
        }

        public void Send()
        {
            Console.WriteLine("Sending {0} contents...", _contents.Count);

            var sendingTasks = _contents.Select(
                    content =>
                        {
                            //var senderTask = new SenderTask(content, _errorLogger);
                            var senderTask = new SenderTask(content);

                            return Task.Factory.StartNew(() => senderTask.Do());
                        }
                );

            //var dumpingLogTask = Task.Factory.ContinueWhenAll(
             //                           sendingTasks.ToArray()//,
                                        //completedSendingTasks => _errorLogger.Dump()
             //                       );

            //dumpingLogTask.Wait();

            Console.WriteLine("All contents were sent with sucess");
        }
    }
}