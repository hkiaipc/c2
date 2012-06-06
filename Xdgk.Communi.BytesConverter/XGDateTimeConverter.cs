using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi.Interface;
using System.Diagnostics;

namespace Xdgk.Communi
{
    public class XGDateTimeConverter : IBytesConverter 
    {
        #region IBytesConverter 成员

            private const int YEAR_POS = 7,
            MONTH_POS   = 6,
            DAY_POS     = 5,
            HOUR_POS    = 4,
            MINUTE_POS  = 3,
            SECOND_POS  = 2,
            CARD_ID_BEGIN_POS   = 8,
            CARD_ID_DATA_LENGTH = 8;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public object ConvertToObject(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException("bytes");

            if (bytes.Length < 8)
                throw new ArgumentException("xgdatatime bytes length must >= 8");

            BCDConverter c = new BCDConverter();
            int year   = (int)c.ConvertToObject( bytes[ YEAR_POS   ] );
            int month  = (int)c.ConvertToObject( bytes[ MONTH_POS  ] );
            int day    = (int)c.ConvertToObject( bytes[ DAY_POS    ] );
            int hour   = (int)c.ConvertToObject( bytes[ HOUR_POS   ] );
            int minute = (int)c.ConvertToObject( bytes[ MINUTE_POS ] );
            int second = (int)c.ConvertToObject( bytes[ SECOND_POS ] );
            year += 2000;
            return new DateTime(year, month, day, hour, minute, second);

            //byte[] cardIdDatas = new byte[ CARD_ID_DATA_LENGTH ];
            //Array.Copy( datas, CARD_ID_BEGIN_POS, cardIdDatas, 0, CARD_ID_DATA_LENGTH );
            //string cardId = MakeCardId( cardIdDatas );
            //return new Record( year, month, day, hour, minute, second, cardId );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] ConvertToBytes(object obj)
        {
            BCDConverter c = new BCDConverter();
            DateTime dt = Convert.ToDateTime(obj);
            byte[] bs = new byte[8];
            int y = dt.Year % 100;
            bs[YEAR_POS] = c.ConvertToBytes(y)[0];
            bs[MONTH_POS] = c.ConvertToBytes(dt.Month)[0];
            bs[DAY_POS] = c.ConvertToBytes(dt.Day)[0];
            bs[HOUR_POS] = c.ConvertToBytes(dt.Hour)[0];
            bs[MINUTE_POS] = c.ConvertToBytes(dt.Minute)[0];
            bs[SECOND_POS ]=c.ConvertToBytes(dt.Second)[0];
            return bs;
        }

        #endregion
    }
}
