using CCMEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CCM
{
  class TabbedOutputter : CCMOutputter
  {
    public override void Output(TextWriter Stream, List<ccMetric> metrics, List<ErrorInfo> errors, bool verbose)
    {
      if (metrics.Count() > 0)
      {
        Console.WriteLine("Method name\tComplexity\tTestability\tCategory\tFilename\tStart line\tEnd line\tSLoC");

        metrics.ForEach(m =>
          {
            Stream.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",
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
