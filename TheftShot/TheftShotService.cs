using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheftShot
{
    class TheftShotService
    {
        public Camera camera;
        public TheftShotService() {
            this.camera = new Camera();
        }
        public void Start() { }
        public void Stop() { }
    }
}
