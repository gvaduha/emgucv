using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Emgu.Util;

namespace Emgu.CV.Structure
{
   /// <summary>
   /// Managed structure equivalent to CvScalar 
   /// </summary>
   [StructLayout(LayoutKind.Sequential)]
   public struct MCvScalar : ICodeGenerable, IEquatable<MCvScalar>
   {
      /// <summary>
      /// The scalar value
      /// </summary>
      public double v0, v1, v2, v3;

      /// <summary>
      /// The scalar values as a vector (of size 4)
      /// </summary>
      public double[] ToArray()
      {
         return new double[4] { v0, v1, v2, v3 };
      }

      /// <summary>
      /// Create a new MCvScalar structure using the specific values
      /// </summary>
      /// <param name="values"></param>
      public MCvScalar(params double[] values)
      {
         v0 = values.Length > 0 ? values[0] : 0.0;
         v1 = values.Length > 1 ? values[1] : 0.0;
         v2 = values.Length > 2 ? values[2] : 0.0;
         v3 = values.Length > 3 ? values[3] : 0.0;
      }

      #region ICodeGenerable Members
      /// <summary>
      /// Return the code to generate this MCvScalar from specific language
      /// </summary>
      /// <param name="language">The programming language to generate code from</param>
      /// <returns>The code to generate this MCvScalar from specific language</returns>
      public string ToCode(Emgu.Util.TypeEnum.ProgrammingLanguage language)
      {
         return (language == Emgu.Util.TypeEnum.ProgrammingLanguage.CSharp || language == Emgu.Util.TypeEnum.ProgrammingLanguage.CPlusPlus) ?
            String.Format("new MCvScalar({0}, {1}, {2}, {3})", v0, v1, v2, v3) :
            ToString();
      }

      #endregion

      #region IEquatable<MCvScalar> Members
      /// <summary>
      /// Return true if the two MCvScalar equals
      /// </summary>
      /// <param name="other">The other MCvScalar to compare with</param>
      /// <returns>true if the two MCvScalar equals</returns>
      public bool Equals(MCvScalar other)
      {
         return v0 == other.v0 && v1 == other.v1 && v2 == other.v2 && v3 == other.v3;
      }

      #endregion
   }
}
