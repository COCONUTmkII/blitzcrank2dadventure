using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Blitzcrank.Managers
{
    class System
    {
        void Start()
        {
            Debug.Log("Display size:"+ Screen.width + "x" + Screen.height);
            Debug.Log("Battety level:" + SystemInfo.batteryLevel);
        }
    }
}
