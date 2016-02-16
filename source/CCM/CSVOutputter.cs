using CCMEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CCM
{
  class CSVOutputter : CCMOutputter
  {
    public override void Output(TextWriter Stream, List<ccMetric> metrics, List<ErrorInfo> errors, bool verbose)
    {
      if (metrics.Count() > 0)
      {
        Stream.WriteLine("Method name,Complexity,Testability,Category,Filename,Start line,End line,SLoC");

        metrics.ForEach(m =>
          {
            Stream.WriteLine("\"{0}\",{1},{2},{3},{4},{5},{6},{7}",
              m.Unit, m.CCM, m.Testability, m.Classification, m.Filename, m.StartLineNumber, m.EndLineNumber,
              (m.EndLineNumber - m.StartLineNumber));
          }
        );
      }

      if (verbose)
        foreach (ErrorInfo error in errors)
          Console.WriteLine("Error in file '{0}' : {1}", error.File, error.Message);
    }

  }
}
