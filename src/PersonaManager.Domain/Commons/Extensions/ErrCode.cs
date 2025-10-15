using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Commons.Extensions
{
    public enum ErrCode
    {
        EMPTY_VALUE,
        INVALID_VALUE,
        NOT_GUID,
        NEGATIVE_VALUE,
        INDEX_OUT_OF_RANGE,
        NOT_IN_ENUM
    }
}