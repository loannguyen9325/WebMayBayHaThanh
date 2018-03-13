using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Data;

namespace MayBayHaThanh.Utilities
{
    public class FilterHelper
    {
        public static DataTable FilterDatatable(DataTable dt, FilterContainer filter)
        {
            string filters = "";
            string logic;
            string condition = "";
            int c = 1;

            for (int i = 0; i < filter.filters.Count; i++)
            {
                logic = filter.logic;
                if (filter.filters[i].@operator == "eq")
                {
                    condition = " = '" + filter.filters[i].value + "' ";
                }
                if (filter.filters[i].@operator == "neq")
                {
                    condition = " != '" + filter.filters[i].value + "' ";
                }
                if (filter.filters[i].@operator == "startswith")
                {
                    condition = " Like '" + filter.filters[i].value + "%' ";
                }
                if (filter.filters[i].@operator == "contains")
                {
                    condition = " Like '%" + filter.filters[i].value + "%' ";
                }
                if (filter.filters[i].@operator == "doesnotcontains")
                {
                    condition = " Not Like '%" + filter.filters[i].value + "%' ";
                }
                if (filter.filters[i].@operator == "endswith")
                {
                    condition = " Like '%" + filter.filters[i].value + "' ";
                }
                filters += filter.filters[i].field + condition;
                if (filter.filters.Count > c)
                {
                    filters += logic;
                    filters += " ";
                }
                c++;
            }
            if (filter.filters.Count != 0)
            {
                dt = new DataView(dt, filters, "", DataViewRowState.CurrentRows).ToTable();
            }

            return dt;
        }
    }
}
