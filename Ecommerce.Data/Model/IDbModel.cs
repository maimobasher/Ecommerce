using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Model
{
    public interface IDbModel
    {

    }

    public interface IDbModel<TPrimaryKey> : IDbModel
    {
        public TPrimaryKey Id { get; }
    }
}
