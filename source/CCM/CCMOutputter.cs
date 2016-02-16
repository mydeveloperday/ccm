using System;
using System.Collections.Generic;
using System.Text;
using CCMEngine;
using System.IO;

namespace CCM
{
  public abstract class CCMOutputter
  {
    public static string XmlOutputType = "XML";
    public static string TextOutputType = "Text";
    public static string TabbedOutputType = "Tabbed";
    public static string CSVOutputType = "CSV";

    public abstract void Output(TextWriter sr,List<ccMetric> metrics, List<ErrorInfo> errors, bool verbose);
  }
}
