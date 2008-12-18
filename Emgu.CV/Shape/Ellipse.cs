using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Emgu.CV.Structure;

namespace Emgu.CV
{
   ///<summary>
   ///An ellipse
   ///</summary>
   public class Ellipse
   {
      private MCvBox2D _box2D;

      /// <summary>
      /// The MCvBox2D representation of this ellipse
      /// </summary>
      public MCvBox2D MCvBox2D
      {
         get { return _box2D; }
         set { _box2D = value; }
      }

      ///<summary> 
      ///Create an ellipse with default parameters
      ///</summary>
      public Ellipse()
      {
      }

      ///<summary>
      ///Create an ellipse with specific parameters
      ///</summary>
      ///<param name="center"> The center of the ellipse</param>
      ///<param name="size"> The width and height of the ellipse</param>
      ///<param name="angle"> The rotation angle in radian for the ellipse</param>
      public Ellipse(PointF center, SizeF size, float angle)
      {
         _box2D = new MCvBox2D(center, size, angle);
      }

      /// <summary>
      /// Create an ellipse from the specific MCvBox2D
      /// </summary>
      /// <param name="box2d">The MCvBox2D representation of this ellipse</param>
      public Ellipse(MCvBox2D box2d)
      {
         _box2D = box2d;
      }
   }
}
