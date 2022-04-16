using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace BunnyGame
{
    public interface ICamera
    {
        /// <summary>
        /// View matrix
        /// </summary>
        Matrix View { get; }

        /// <summary>
        /// Projection matrix
        /// </summary>
        Matrix Projection { get;  }

    }
}
