using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Visualisation
{
    public class Window:GameWindow
    {
        private const string Title = "Visualization";
        private readonly List<Tuple<double, double, double>> list;

        public Window(List<Tuple<double,double,double>> list )
            :base(800,800,GraphicsMode.Default, Title,GameWindowFlags.Default,DisplayDevice.Default)
        {
            this.list = list;
        }
        
        public void ShowWindow()
        {
            Run();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 2, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
            Matrix4 modelview = Matrix4.LookAt(new Vector3(0, 0, 0), new Vector3(0, 5, 0),Vector3.UnitZ);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            var r = Matrix4.CreateRotationZ(0.001f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.MultMatrix(ref r);

            GL.Begin(PrimitiveType.Points);

            foreach (var coord in list)
            {
                GL.Vertex3(coord.Item1, coord.Item2, coord.Item3);
            }

            GL.End();

            SwapBuffers();
        }


    }
}
