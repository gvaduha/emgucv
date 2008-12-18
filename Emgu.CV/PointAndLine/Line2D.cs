using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Emgu.CV
{
   ///<summary> A 2D line </summary>
   public class Line2D
   {
      ///<summary> A point on the line </summary>
      private Point _p1;
      ///<value> An other point on the line </value>
      private Point _p2;

      ///<summary>
      ///Create a default line
      ///</summary>
      public Line2D()
      {
         _p1 = new Point();
         _p2 = new Point();
      }

      ///<summary> 
      ///Create a line by specifing two points on the line
      ///</summary>
      ///<param name="p1"> A point on the line </param>
      ///<param name="p2"> An other point on the line </param>
      public Line2D(Point p1, Point p2)
      {
         _p1 = p1;
         _p2 = p2;
      }

      ///<summary> A point on the line </summary>
      public Point P1 { get { return _p1; } set { _p1 = value; } }

      ///<summary> An other point on the line </summary>
      public Point P2 { get { return _p2; } set { _p2 = value; } }

      ///<summary> The direction of the line, the norm of which is 1 </summary>
      public PointF Direction
      {
         get
         {
            int dx = P1.X - P2.X;
            int dy = P1.Y - P2.Y;
            float dist = (float)Math.Sqrt(dx * dx + dy * dy);

            return new PointF(dx / dist, dy / dist);
         }
      }

      /*
      ///<summary> Obtain the Y value from the X value</summary>
      ///<param name="x">The X value</param>
      ///<returns>The Y value</returns>
      public float YByX(float x)
      {
         Point2D<double> p1 = _p1.Convert<double>();
         Point2D<double> dir = Direction;
         return (T)System.Convert.ChangeType((System.Convert.ToDouble(x) - p1.X) / dir.X * dir.Y + p1.Y, typeof(T));
      }*/

      /// <summary>
      /// Determin which side of the line the 2D point is at
      /// </summary>
      /// <param name="point">the point</param>
      /// <returns>
      /// 1 if on the right hand side;
      /// 0 if on the line;
      /// -1 if on the left hand side;
      /// </returns>
      public int Side(Point point)
      {
         float res = (P1.X - P1.X) * (point.Y - P1.Y) - (point.X - P1.X) * (P2.Y - P1.Y);
         return res > 0.0f ? 1 :
            res < 0.0f ? -1 : 0;
      }

      /// <summary>
      /// Get the exterior angle between this line and <paramref name="otherLine"/>
      /// </summary>
      /// <param name="otherLine">The other line</param>
      /// <returns>The exterior angle between this line and <paramref name="otherLine"/></returns>
      public double GetExteriorAngleDegree(Line2D otherLine)
      {
         PointF direction1 = Direction;
         PointF direction2 = otherLine.Direction;
         double radianAngle = System.Math.Atan2(direction2.Y, direction2.X) - System.Math.Atan2(direction1.Y, direction1.X);
         double degreeAngle = radianAngle * 180.0 / System.Math.PI;
         return
             degreeAngle <= -180.0 ? degreeAngle + 360 :
             degreeAngle > 180.0 ? degreeAngle - 360 :
             degreeAngle;
      }
   }
}
