using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RapportCQRS.Model.Helpers
{
    public class EncryptedConverter : ValueConverter<string, string>
    {
        public EncryptedConverter(ConverterMappingHints mappingHints = default)
            : base(EncryptExpr, DecryptExpr, mappingHints)
        { }

        static Expression<Func<string, string>> DecryptExpr = x => new string(x.Reverse().ToArray());
        static Expression<Func<string, string>> EncryptExpr = x => new string(x.Reverse().ToArray());
    }
}
