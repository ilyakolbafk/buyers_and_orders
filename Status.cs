using System;

namespace Buyers_and_orders
{
    /// <summary>
    /// Enum of product statuses.
    /// </summary>
    
    [Flags]
    public enum Status
    {
        Default = 0,
        Processed = 1,
        Paid = 2,
        Shipped = 4,
        Executed = 8
    }
}