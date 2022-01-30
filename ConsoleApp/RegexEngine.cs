using System;
using System.Linq;
using System.Linq.Expressions;
using Core;
using Core.Models;

namespace ConsoleApp
{
    public class RegexEngine : AstVisitor<Func<string, Tuple<string, bool>>>
    {
        public override Func<string, Tuple<string, bool>> Visit(AnyToken anyToken)
        {
            return _ => new Tuple<string, bool>(string.Empty, true);
        }

        public override Func<string, Tuple<string, bool>> Visit(ConcatenationToken concatenationToken)
        {
            var probes = concatenationToken.Tokens.Select(Visit).ToList();
            return buffer =>
            {
                foreach (var probe in probes)
                {
                    var (remaining, success) = probe(buffer);
                    if (!success)
                    {
                        return new Tuple<string, bool>(null, false);
                    }

                    buffer = buffer[..remaining.Length];
                }

                return new Tuple<string, bool>(buffer, true);
            };
        }

        public override Func<string, Tuple<string, bool>> Visit(EosToken eosToken)
        {
            return buffer => new Tuple<string, bool>(string.Empty, buffer.Length == 0);
        }

        public override Func<string, Tuple<string, bool>> Visit(GroupToken groupToken)
        {
            throw new NotImplementedException();
        }

        public override Func<string, Tuple<string, bool>> Visit(MetaCharToken metaCharToken)
        {
            return buffer =>
            {
                
            };
        }

        public override Func<string, Tuple<string, bool>> Visit(NegativeToken negativeToken)
        {
            throw new NotImplementedException();
        }

        public override Func<string, Tuple<string, bool>> Visit(NonMetaCharToken nonMetaCharToken)
        {
            throw new NotImplementedException();
        }

        public override Func<string, Tuple<string, bool>> Visit(PlusToken plusToken)
        {
            var probe = Visit(plusToken.Token);
            return buffer =>
            {
                var anySuccess = false;
                while (string.IsNullOrEmpty(buffer))
                {
                    var (remaining, success) = probe(buffer);
                    switch (success)
                    {
                        case false when !anySuccess:
                            return new Tuple<string, bool>(null, false);
                        case false:
                            return new Tuple<string, bool>(buffer, true);
                        default:
                            anySuccess = true;
                            buffer = buffer![..remaining.Length];
                            break;
                    }
                }
                
                return new Tuple<string, bool>(buffer, true);
            };
        }

        public override Func<string, Tuple<string, bool>> Visit(PositiveToken positiveToken)
        {
            throw new NotImplementedException();
        }

        public override Func<string, Tuple<string, bool>> Visit(RangeToken rangeToken)
        {
            throw new NotImplementedException();
        }

        public override Func<string, Tuple<string, bool>> Visit(SetItems setItems)
        {
            throw new NotImplementedException();
        }

        public override Func<string, Tuple<string, bool>> Visit(StarToken starToken)
        {
            var probe = Visit(starToken.Token);
            return buffer =>
            {
                while (string.IsNullOrEmpty(buffer))
                {
                    var (remaining, success) = probe(buffer);
                    if (!success)
                    {
                        return new Tuple<string, bool>(buffer, true);
                    }

                    buffer = buffer![..remaining.Length];
                }
                
                return new Tuple<string, bool>(buffer, true);
            };
        }

        public override Func<string, Tuple<string, bool>> Visit(UnionToken unionToken)
        {
            throw new NotImplementedException();
        }
    }
}