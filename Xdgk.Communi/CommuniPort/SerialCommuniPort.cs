using System.IO.Ports;
using Xdgk.Common;
using System;

namespace Xdgk.Communi
{
    /// <summary>
    /// 
    /// </summary>
    public class SerialCommuniPort : CommuniPort
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="parity"></param>
        /// <param name="dataBits"></param>
        /// <param name="stopBits"></param>
        public SerialCommuniPort( string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            _serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            _serialPort.Open();
            this.CommuniPortState = new SerialCommuniPortReadyState(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool CanOpen
        {
            get { return true; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsOpened
        {
            get { return this.SerialPort.IsOpen; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Open()
        {
            this.SerialPort.Open();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Close()
        {
            this.SerialPort.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public SerialPort SerialPort
        {
            get { return _serialPort; }
        } private SerialPort _serialPort;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override byte[] Read()
        {
            int readCount = this.SerialPort.BytesToRead;
            if (readCount > 0)
            {
                byte[] buffer = new byte[this.SerialPort.BytesToRead];
                this.SerialPort.Read(buffer, 0, readCount);
                return buffer;
            }
            else
            {
                return new byte[0];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public override bool Write(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            this.SerialPort.Write(bytes, 0, bytes.Length);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public override SerialPortSetting SerialPortSetting
        {
            get
            {
                if (SerialPortSettingEnabled)
                {
                    return new SerialPortSetting(
                        this.SerialPort.BaudRate,
                        this.SerialPort.Parity,
                        this.SerialPort.DataBits,
                        this.SerialPort.StopBits);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (SerialPortSettingEnabled)
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("SerialPortSetting");
                    }
                    this.SerialPort.Close();

                    this.SerialPort.BaudRate = value.BaudRate;
                    this.SerialPort.Parity = value.Parity;
                    this.SerialPort.DataBits = value.DataBits;
                    this.SerialPort.StopBits = value.StopBits;

                    this.SerialPort.Open();
                }
                else
                {

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="communiType"></param>
        /// <returns></returns>
        public override bool Match(CommuniType communiType)
        {
            if( communiType == null )
                throw new ArgumentNullException ("communiType" );

            if (communiType is SerialCommuniType)
            {
                SerialCommuniType sct = communiType as SerialCommuniType;
                bool b = StringHelper.Equal(sct.PortName, this.SerialPort.PortName) &&
                    sct.BaudRate == this.SerialPort.BaudRate &&
                    sct.Parity == this.SerialPort.Parity &&
                    sct.DataBits == this.SerialPort.DataBits &&
                    sct.StopBits == this.SerialPort.StopBits;

                return b;
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialPortSetting"></param>
        /// <returns></returns>
        public override bool MatchSerialPortSetting(SerialPortSetting serialPortSetting)
        {
            if (SerialPortSettingEnabled)
            {
                if (serialPortSetting == null)
                {
                    throw new ArgumentNullException("serialPortSetting");
                }
                bool b = serialPortSetting.BaudRate == this.SerialPort.BaudRate &&
                    serialPortSetting.Parity == this.SerialPort.Parity &&
                    serialPortSetting.DataBits == this.SerialPort.DataBits &&
                    serialPortSetting.StopBits == this.SerialPort.StopBits;
                return b;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool SerialPortSettingEnabled
        {
            get
            {
                return true;
            }
            set
            {
                // do nothing
                //
            }
        }
    }
}