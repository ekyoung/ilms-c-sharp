using System;
using System.Collections.Generic;
using System.Data;

namespace EthanYoung.PersonalWebsite.ImageManipulation
{


    partial class ImagesDataSet
    {
        private List<ImagesRow> GetImagesSorted(string sort)
        {
            if (string.IsNullOrEmpty(sort))
            {
                throw new ArgumentException("Argument cannot be null or empty.", "sort");
            }

            DataView dv = new DataView(Images);
            dv.Sort = sort;

            List<ImagesRow> result = new List<ImagesRow>(dv.Count);

            foreach (DataRowView item in dv)
	        {
                result.Add((ImagesRow)item.Row);
	        }

            return result;
        }

        public List<ImagesRow> GetImagesSortedByDateTaken()
        {
            return GetImagesSortedByDateTaken("ASC");
        }

        public List<ImagesRow> GetImagesSortedByDateTaken(string direction)
        {
            string sort = Images.DateTakenColumn.ColumnName + " " + direction;
            return GetImagesSorted(sort);
        }

        public List<ImagesRow> GetImagesSortedByTitle()
        {
            return GetImagesSortedByTitle("ASC");
        }

        public List<ImagesRow> GetImagesSortedByTitle(string direction)
        {
            string sort = Images.TitleColumn.ColumnName + " " + direction;
            return GetImagesSorted(sort);
        }
    }
}
