// Copyright © John Gietzen. All Rights Reserved. This source is subject to the MIT license. Please see license.md for more information.

namespace Pegasus.Workbench.Pipeline.Model
{
    using Pegasus.Common.Tracing;
    using Pegasus.Compiler;
    using Pegasus.Expressions;

    public sealed class ExportedRuleEntrypoint : ParserEntrypoint
    {
        private readonly object parser;

        public ExportedRuleEntrypoint(object parser, Rule rule)
            : base("Exported." + PublicRuleFinder.GetPublicName(rule), rule)
        {
            this.parser = parser;
        }

        public override object Parse(string subject, string filename, ITracer tracer = null)
        {
            if (this.parser == null)
            {
                return null;
            }

            this.parser.GetType().GetProperty("Tracer").SetValue(this.parser, tracer);
            return "Not supported.";
        }
    }
}
