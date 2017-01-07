using System.Collections.Generic;

namespace VtrFramework.MetaData
{
    public interface IVtrTableRepository
    {
        List<VtrTable> GetAll(bool isAuditLogTable = false);
        List<VtrField> GetByTable(VtrTable table);
    }
}