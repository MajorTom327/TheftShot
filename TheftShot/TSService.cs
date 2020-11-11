using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TheftShot
{
    class TSService
    {
        private string _filePath = Path.Combine(TSConstants.BaseDir, "sessions.txt");
        public TSCamera camera;
        public TSService() {
            
        }
        public void Start() {
            Console.WriteLine("TheftShotService created");

            (new FileInfo(TSConstants.BaseDir)).Directory.Create();

            using (var f = System.IO.File.AppendText(_filePath))
            {
                f.WriteLine($"Session start: {DateTime.Now.ToString("s")}");
            }
            Thread th = new Thread(new ThreadStart(AskScreenShot));
            th.Start();
        }
        public void Stop() {
            using (var f = System.IO.File.AppendText(_filePath))
            {
                f.WriteLine($"Session close: {DateTime.Now.ToString("s")}");
            }
        }

        private void AskScreenShot()
        {
            Task.Delay(60_000).ContinueWith(t => {
                this.camera = new TSCamera();
                this.camera.TakePicture();
            });
        }
    }
}
