using System.Linq;
using LeanWork.Infrastructure.CrossCutting.Utilities.Extension;

namespace LeanWork.Infrastructure.CrossCutting.Utilities
{
    public static class SequenceHelper
    {
        public static string GetSequenceName<T>(T entity)
        {
            return ((SqlFilter)entity.GetType().GetCustomAttributes(typeof(SqlFilter), true).First()).SequenceName;
        }
    }
}
