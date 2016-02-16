using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CCMEngine;

namespace CCM
{
  class XmlOutputter : CCMOutputter
  {
    public string XmlStyleSheet
    {
        get; set;
    }
    
    public XmlOutputter(string style)
    {
            XmlStyleSheet = style;
    }
    private static string XmlAdjust(string text)
    {
      return System.Security.SecurityElement.Escape(text);
    }

    public override void Output(TextWriter Stream, List<ccMetric> metrics, List<ErrorInfo> errors, bool verbose)
    {
      Stream.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
      if (!string.IsNullOrEmpty(XmlStyleSheet))
      {
           Stream.WriteLine("<?xml-stylesheet type=\"text/xsl\" href=\"" + XmlStyleSheet + "\"?>");
      }
      Stream.WriteLine("<ccm>");

      foreach (ccMetric metric in metrics)
      {
        Stream.WriteLine("  <metric>");
        Stream.WriteLine("    <complexity>{0}</complexity>", metric.CCM);
        Stream.WriteLine("    <unit>{0}</unit>", XmlOutputter.XmlAdjust(metric.Unit));
        Stream.WriteLine("    <testability>{0}</testability>", metric.Testability);
        Stream.WriteLine("    <classification>{0}</classification>", metric.Classification);
        Stream.WriteLine("    <file>{0}</file>", metric.Filename);
        Stream.WriteLine("    <startLineNumber>{0}</startLineNumber>", metric.StartLineNumber);
        Stream.WriteLine("    <endLineNumber>{0}</endLineNumber>", metric.EndLineNumber);
        Stream.WriteLine("    <SLOC>{0}</SLOC>", (metric.EndLineNumber - metric.StartLineNumber).ToString());
        Stream.WriteLine("  </metric>");
      }

      if (verbose && (errors.Count > 0))
      {
        Stream.WriteLine("    <errors>");

        foreach (ErrorInfo error in errors)
        {
          Stream.WriteLine("      <error>");
          Stream.WriteLine("        <file>{0}</file>", error.File);
          Stream.WriteLine("        <message>{0}</message>", error.Message);
          Stream.WriteLine("      </error>");
        }
        Stream.WriteLine("    </errors>");
      }

      Stream.WriteLine("</ccm>");

    }
  }
}
