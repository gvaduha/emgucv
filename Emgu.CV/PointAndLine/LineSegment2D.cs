using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Emgu.CV
{
   /// <summary> 
   /// A line segment 
   /// </summary>
   public class LineSegment2D : Line2D
   {
      /// <summary> 
      /// Create a line segment with the specific starting point and end point 
      /// </summary>
      /// <param name="p1">The first point on the line segment</param>
      /// <param name="p2">The second point on the line segment</param>
      public LineSegment2D(Point p1, Point p2) : base(p1, p2) { }

      /// <summary> 
      /// Get the length of the line segment 
      /// </summary>
      public double Length
      {
         get
         {
            int dx = P1.X - P2.X;
            int dy = P1.Y - P2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
         }
      }
   }
}
